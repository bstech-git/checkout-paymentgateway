using Checkout.PaymentGateway.Models;
using Checkout.PaymentGateway.Services.Interfaces;
using System;
using System.Threading.Tasks;

namespace Checkout.PaymentGateway.Services
{
    public class BankService : IBankService
    {
        public async Task<BankResponse> ExecuteAsync(BankCardRequest bankCardRequest)
        {
            var response = new BankResponse()
            {
                Id = Guid.NewGuid().ToString()
            };

            switch(bankCardRequest.Amount)
            {
                case 100:
                    response.Status = BankResponseStatus.Failed;
                    response.Details = "invalid amount";
                    break;
                case 200:
                    response.Status = BankResponseStatus.Failed;
                    response.Details = "insufficient funds";
                    break;
                case 300:
                    response.Status = BankResponseStatus.Failed;
                    response.Details = "card blocked";
                    break;
                default:
                    response.Status = BankResponseStatus.Success;
                    response.Details = "authorised";
                    break;
            }

            return await Task.Run(() => response);
        }
    }
}
