namespace MISA.SME2023.Common
{
    public class ErrorResult
    {
        #region Properties

        public bool IsSuccess { get; set; }

        public object Errors { get; set; }

        public string Message { get; set; } = string.Empty;

        #endregion

        public ErrorResult(object errors)
        {
            IsSuccess = false;
            Errors = errors;
        }

        public ErrorResult(object errors, string message)
        {
            IsSuccess = false;
            Errors = errors;
            Message = message;
        }
    }
}
