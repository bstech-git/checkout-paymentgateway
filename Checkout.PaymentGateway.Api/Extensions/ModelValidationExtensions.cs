using Checkout.PaymentGateway.Api.ModelValidators;
using Checkout.PaymentGateway.Models;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Checkout.PaymentGateway.Api.Extensions
{
    public static class ModelValidationExtensions
    {
        public static IServiceCollection AddModelValidation(this IServiceCollection services)
        {
            services.AddSingleton<IValidator<CardPaymentRequest>, CardPaymentRequestValidator>();
            return services;
        }

        public static IServiceCollection AddModelValidationBehaviour(this IServiceCollection services)
        {
            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.InvalidModelStateResponseFactory = (context) =>
                {
                    var validationErrors = context.ModelState.Values.SelectMany(x => x.Errors.Select(p => p.ErrorMessage)).ToList();

                    return new BadRequestObjectResult(
                        new ErrorResponse()
                        {
                            Error = string.Join(",", validationErrors.Select(x => x))
                        });
                };
            });

            return services;
        }
    }
}
