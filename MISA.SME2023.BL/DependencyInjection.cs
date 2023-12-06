using Microsoft.Extensions.DependencyInjection;
using MISA.SME2023.DL;
using System.Reflection;

namespace MISA.SME2023.BL
{
    /// <summary>
    /// Lớp định nghĩa Dependency Injection cho DL
    /// </summary>
    public static class DependencyInjection
    {
        #region Methods

        /// <summary>
        /// Thêm các dịch vụ của BL vào IServiceCollection
        /// </summary>
        /// <param name="services">Danh sách dịch vụ</param>
        /// <returns>IServiceCollection</returns>
        public static IServiceCollection AddBusinessLayer(this IServiceCollection services)
        {
            services.AddDataLayer();

            // Cấu hình AutoMapper để ánh xạ các đối tượng.
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            services.AddScoped(typeof(IBaseBL<>), typeof(BaseBL<>));
            services.AddScoped<IAccountBL, AccountBL>();
            services.AddScoped<IPaymentBL, PaymentBL>();
            services.AddScoped<IPaymentDetailBL, PaymentDetailBL>();
            services.AddScoped<IEmployeeBL, EmployeeBL>();
            return services;
        }

        #endregion
    }
}
