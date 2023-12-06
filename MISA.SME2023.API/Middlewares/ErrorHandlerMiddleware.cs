using MISA.SME2023.Common;
using System.Text.Json;

namespace MISA.SME2023.API
{
    /// <summary>
    /// Middleware xử lý các ngoại lệ trong ứng dụng
    /// </summary>
    public class ErrorHandlerMiddleware
    {
        #region Fields

        private readonly RequestDelegate _next;
        private readonly ILogger _logger;

        #endregion

        #region Constructors

        public ErrorHandlerMiddleware(RequestDelegate next, ILogger<ErrorHandlerMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Hàm xử lý các ngoại lệ trong ứng dụng
        /// </summary>
        /// <param name="context">Đối tượng HttpContext</param>
        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception error)
            {
                var response = context.Response;
                response.ContentType = "application/json";

                var jsonSerializerOptions = new JsonSerializerOptions()
                {
                    PropertyNamingPolicy = null,
                    Encoder = System.Text.Encodings.Web.JavaScriptEncoder.Create(System.Text.Unicode.UnicodeRanges.All)
                };

                switch (error)
                {
                    case BadRequestException e:
                        response.StatusCode = StatusCodes.Status400BadRequest;
                        await response.WriteAsJsonAsync(new BaseException()
                        {
                            ErrorCode = e.ErrorCode,
                            UserMessage = "Yêu cầu không hợp lệ",
                            DevMessage = error.Message,
                            TraceId = context.TraceIdentifier,
                            MoreInfo = error.HelpLink
                        }, jsonSerializerOptions);
                        break;

                    case NotFoundException e:
                        response.StatusCode = StatusCodes.Status404NotFound;
                        await response.WriteAsJsonAsync(new BaseException()
                        {
                            ErrorCode = e.ErrorCode,
                            UserMessage = "Không tìm thấy tài nguyên",
                            DevMessage = error.Message,
                            TraceId = context.TraceIdentifier,
                            MoreInfo = error.HelpLink
                        }, jsonSerializerOptions);
                        break;

                    case ConflictException e:
                        response.StatusCode = StatusCodes.Status409Conflict;
                        await response.WriteAsJsonAsync(new BaseException()
                        {
                            ErrorCode = e.ErrorCode,
                            UserMessage = error.Message,
                            DevMessage = error.Message,
                            TraceId = context.TraceIdentifier,
                            MoreInfo = error.HelpLink
                        }, jsonSerializerOptions);
                        break;

                    case ValidationException e:
                        response.StatusCode = StatusCodes.Status400BadRequest;
                        await response.WriteAsJsonAsync(new BaseException()
                        {
                            ErrorCode = e.ErrorCode,
                            UserMessage = error.Message,
                            DevMessage = error.Message,
                            TraceId = context.TraceIdentifier,
                            MoreInfo = error.HelpLink
                        }, jsonSerializerOptions);
                        break;

                    default:
                        // unhandled error
                        _logger.LogError(error, error.Message);
                        response.StatusCode = StatusCodes.Status500InternalServerError;
                        await response.WriteAsJsonAsync(new BaseException()
                        {
                            ErrorCode = context.Response.StatusCode,
                            UserMessage = "Lỗi hệ thống. Vui lòng liên hệ MISA để được hỗ trợ.",
                            DevMessage = error.Message,
                            TraceId = context.TraceIdentifier,
                            MoreInfo = error.HelpLink
                        }, jsonSerializerOptions);
                        break;
                }
            }
        }

        #endregion
    }
}
