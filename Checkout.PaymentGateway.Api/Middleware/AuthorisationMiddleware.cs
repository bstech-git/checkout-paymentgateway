using Checkout.PaymentGateway.Models;
using Checkout.PaymentGateway.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Checkout.PaymentGateway.Api.Middleware
{
    public class AuthorisationMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IAuthorisationService _authorisationService;
        private readonly IDiagnosticContext _diagnosticContext;
        private readonly ILogger<AuthorisationMiddleware> _logger;

        public AuthorisationMiddleware(RequestDelegate next, 
            IAuthorisationService authorisationService, 
            IDiagnosticContext diagnosticContext, 
            ILogger<AuthorisationMiddleware> logger)
        {
            _next = next;
            _authorisationService = authorisationService;
            _diagnosticContext = diagnosticContext;
            _logger = logger;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            try
            {
                var authToken = httpContext.Request.Headers["Authorization"].FirstOrDefault();

                 var authResult = await _authorisationService.Verify(authToken);

                if (authResult.Valid == false)
                {
                    _logger.LogError("Request without Authorisation token");
                    httpContext.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                    await httpContext.Response.WriteAsync("Not authorised to perform this action");
                
                }
                else
                {
                    httpContext.Items["Merchant"] = authResult.Merchant;
                    await _next.Invoke(httpContext);
                }
            }
            catch(Exception ex)
            {
                _logger.LogCritical(ex, "");
                httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                await httpContext.Response.WriteAsync("");
            }
        }
    }
}
