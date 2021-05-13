using Checkout.PaymentGateway.Models;
using Checkout.PaymentGateway.Models.Contexts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Checkout.PaymentGateway.Services.Interfaces
{
    public interface ITransactionService
    {
        Task<Transaction> InitialiseTransactionAsync(CardPaymentContext cardContext);

        Task<Transaction> UpdateTransactionAsync(string transactionId, BankResponse bankResponse);

        Task<Transaction> GetTransaction(string id);
    }
}
