using Checkout.PaymentGateway.Services;
using Checkout.PaymentGateway.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Checkout.PaymentGateway.Api.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApiServices(this IServiceCollection services)
        {
            services.AddScoped<IBankService, BankService>();
            services.AddScoped<ICardPaymentService, CardPaymentService>();
            services.AddSingleton<ITransactionService, TransactionService>();
            services.AddSingleton<IAuthorisationService, AuthorisationService>();
            services.AddScoped<IMaskingService, MaskingService>();
            services.AddScoped<IModelConverter, ModelConverter>();

            return services;

        }
    }
}
