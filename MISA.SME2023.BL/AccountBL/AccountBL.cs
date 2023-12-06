using MISA.SME2023.Common;
using MISA.SME2023.DL;
using System.Text.RegularExpressions;

namespace MISA.SME2023.BL
{
    public class AccountBL : BaseBL<Account>, IAccountBL
    {
        private readonly IAccountDL _accountDL;

        public AccountBL(IBaseDL<Account> baseDL, IAccountDL accountDL) : base(baseDL)
        {
            _accountDL = accountDL;
        }

        public async Task<ServiceResult> UpdateInactiveAsync(Guid id, bool inactive, bool forceChild)
        {
            await _accountDL.UpdateInactiveAsync(id, inactive, forceChild, "Admin");
            return new ServiceResult();
        }

        override public async Task<ServiceResult> AddAsync(Account data)
        {
            IsValidAccountNumberFormat(data.account_number);

            await IsDuplicatedAccountNumberAsync(data.account_number);

            IsEmptyParentAccount(data.account_number, data.parent_account);

            IsChildAccount(data.account_number, data.parent_account);

            data.current_account_number = data.account_number;

            data.grade = await GetAccountGrade(data.parent_id);

            if (data is IEntity entity && entity.GetId() == Guid.Empty)
            {
                entity.SetId(Guid.NewGuid());
            }

            if (data is AuditableBaseEntity baseAuditEntity)
            {
                baseAuditEntity.created_by = "Admin";
                baseAuditEntity.created_date = DateTime.Now;
                baseAuditEntity.modified_by = "Admin";
                baseAuditEntity.modified_date = DateTime.Now;
            }

            await _accountDL.AddAsync(data);
            await _accountDL.UpdateIsParentAsync(data.parent_account);
            return new ServiceResult();
        }

        override public async Task<ServiceResult> UpdateAsync(Account data)
        {
            IsValidAccountNumberFormat(data.account_number);

            if (data.account_number != data.current_account_number)
                await IsDuplicatedAccountNumberAsync(data.account_number);

            IsEmptyParentAccount(data.account_number, data.parent_account);

            IsChildAccount(data.account_number, data.parent_account);

            data.current_account_number = data.account_number;

            data.grade = await GetAccountGrade(data.parent_id);

            if (data is AuditableBaseEntity baseAuditEntity)
            {
                baseAuditEntity.modified_by = "Admin";
                baseAuditEntity.modified_date = DateTime.Now;
            }

            await _accountDL.UpdateAsync(data);
            await _accountDL.UpdateIsParentAsync(data.parent_account);
            return new ServiceResult();

        }

        override public async Task<ServiceResult> DeleteAsync(Account data)
        {
            await _accountDL.DeleteAsync(data);
            await _accountDL.UpdateIsParentAsync(data.parent_account);
            return new ServiceResult();
        }

        private async Task<int> GetAccountGrade(Guid? parentId)
        {
            if (!parentId.HasValue)
                return 1;

            var result = await _accountDL.GetGradeByIdAsync(parentId.Value);
            return ++result;
        }

        private void IsValidAccountNumberFormat(string accountNumber)
        {
            // Kiểm tra xem accountNumber có đúng định dạng là chuỗi số 
            var errorMessage = "Số tài khoản không đúng định dạng. Số tài khoản chỉ được chứa chữ số.";

            if (!Regex.IsMatch(accountNumber, @"^\d+$"))
                throw new ValidationException(errorMessage, (int)ErrorCode.InvalidAccountNumberFormat);
        }

        private async Task IsDuplicatedAccountNumberAsync(string accountNumber)
        {
            var searchResult = await _accountDL.GetByNumberAsync(accountNumber);
            var errorMessage = $"Số tài khoản <{accountNumber}> đã tồn tại. Xin vui lòng kiểm tra lại.";

            if (searchResult != null)
                throw new ValidationException(errorMessage, (int)ErrorCode.DuplicatedAccountNumber);
        }

        private void IsEmptyParentAccount(string accountNumber, string parentAccount)
        {
            var errorMessage = "Số tài khoản có độ dài > 3 ký tự phải điền thông tin <Tài khoản tổng hợp>.";

            if (accountNumber.Length > 3 && string.IsNullOrEmpty(parentAccount))
                throw new ValidationException(errorMessage, (int)ErrorCode.EmptyParentAccount);
        }

        private void IsChildAccount(string childAccount, string parentAccount)
        {
            var errorMessage = "Số tài khoản không hợp lệ. Số tài khoản chi tiết phải bắt đầu bằng số của Tài khoản tổng hợp.";

            if (!string.IsNullOrEmpty(parentAccount) &&
                    !childAccount.StartsWith(parentAccount))
                throw new ValidationException(errorMessage, (int)ErrorCode.InvalidChildAccount);
        }
    }
}
