using Microsoft.Extensions.DependencyInjection;

namespace MISA.SME2023.DL
{
    /// <summary>
    /// Lớp định nghĩa Dependency Injection cho DL
    /// </summary>
    public static class DependencyInjection
    {
        #region Methods

        /// <summary>
        /// Thêm các dịch vụ của DL vào IServiceCollection
        /// </summary>
        /// <param name="services">Danh sách dịch vụ</param>
        /// <returns>IServiceCollection</returns>
        public static IServiceCollection AddDataLayer(this IServiceCollection services)
        {
            services.AddSingleton<DbContext>();

            services.AddScoped(typeof(IBaseDL<>), typeof(BaseDL<>));
            services.AddScoped<IEmployeeDL, EmployeeDL>();
            services.AddScoped<IAccountDL, AccountDL>();
            services.AddScoped<IPaymentDL, PaymentDL>();
            services.AddScoped<IPaymentDetailDL, PaymentDetailDL>();
            return services;
        }

        #endregion
    }
}
