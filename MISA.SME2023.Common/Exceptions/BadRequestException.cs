using Microsoft.AspNetCore.Http;

namespace MISA.SME2023.Common
{
    /// <summary>
    /// Lớp ngoại lệ thể hiện tình trạng không tìm thấy (Not Found Exception)
    /// </summary>
    public class BadRequestException : Exception
    {
        #region Properties

        /// <summary>
        /// Mã lỗi tương ứng với tình trạng không tìm thấy
        /// </summary>
        public int ErrorCode { get; set; } = StatusCodes.Status400BadRequest;

        #endregion

        #region Constructors

        /// <summary>
        /// Khởi tạo một instance mới của <see cref="BadRequestException"/>
        /// </summary>
        public BadRequestException()
        {
        }

        /// <summary>
        /// Khởi tạo một instance mới của <see cref="BadRequestException"/> với mã lỗi
        /// </summary>
        /// <param name="errorCode">Mã lỗi</param>
        public BadRequestException(int errorCode)
        {
            ErrorCode = errorCode;
        }

        /// <summary>
        /// Khởi tạo một instance mới của <see cref="BadRequestException"/> với thông điệp lỗi
        /// </summary>
        /// <param name="message">Thông điệp lỗi</param>
        public BadRequestException(string message) : base(message)
        {
        }

        /// <summary>
        /// Khởi tạo một instance mới của <see cref="BadRequestException"/> với thông điệp lỗi và mã lỗi
        /// </summary>
        /// <param name="message">Thông điệp lỗi</param>
        /// <param name="errorCode">Mã lỗi</param>
        public BadRequestException(string message, int errorCode) : base(message)
        {
            ErrorCode = errorCode;
        }

        #endregion
    }
}
