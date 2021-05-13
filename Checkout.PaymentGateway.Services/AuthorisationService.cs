using Checkout.PaymentGateway.Models;
using Checkout.PaymentGateway.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Checkout.PaymentGateway.Services
{
    public class AuthorisationService : IAuthorisationService
    {
        public async Task<AuthorisationResult> Verify(string authToken)
        {

            var dummyAuthResult = new AuthorisationResult();

            if (string.IsNullOrEmpty(authToken))
                return await Task.Run(() => dummyAuthResult);

            return authToken.ToUpperInvariant() switch
            {
                "TEST_KEY1" => await Task.Run(() => new AuthorisationResult()
                {
                    Valid = true,
                    Merchant = new Merchant() { Id = "M_1111", Name = "Merchant 1" }
                }),
                _ => await Task.Run(() => dummyAuthResult),
            };
        }
    }
}
