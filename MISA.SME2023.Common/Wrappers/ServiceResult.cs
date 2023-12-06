namespace MISA.SME2023.Common
{
    public class ServiceResult
    {
        #region Properties

        public bool IsSuccess { get; set; }

        public string? Message { get; set; }

        public object? Result { get; set; }

        #endregion

        public ServiceResult()
        {
            IsSuccess = true;
        }

        public ServiceResult(object result)
        {
            IsSuccess = true;
            Result = result;
        }

        public ServiceResult(object result, string message)
        {
            IsSuccess = true;
            Message = message;
            Result = result;
        }
    }
}
