using Checkout.PaymentGateway.Models;
using Checkout.PaymentGateway.Models.Contexts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Checkout.PaymentGateway.Services.Interfaces
{
    public interface ICardPaymentService
    {
        Task<CardPaymentResponse> ProcessAsync(CardPaymentRequest cardPaymentRequest, Merchant merchant);

        Task<TransactionResponse> GetPaymentAsync(string paymentId);
    }
}
