using Checkout.PaymentGateway.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Checkout.PaymentGateway.Services.Interfaces
{
    public interface IBankService
    {
        Task<BankResponse> ExecuteAsync(BankCardRequest bankCardRequest);

    }
}
