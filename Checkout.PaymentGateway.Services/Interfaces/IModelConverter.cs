using Checkout.PaymentGateway.Models;
using Checkout.PaymentGateway.Models.Contexts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Checkout.PaymentGateway.Services.Interfaces
{
    public interface IModelConverter
    {
        /// <summary>
        /// Creates a card payment context from card payment request and merchant details
        /// </summary>
        /// <param name="cardPaymentRequest"></param>
        /// <param name="merchant"></param>
        /// <returns></returns>
        CardPaymentContext CreateCardPaymentContext(CardPaymentRequest cardPaymentRequest, Merchant merchant);
        /// <summary>
        /// Maps the internal transactoin details to the customer response
        /// </summary>
        /// <param name="transaction"></param>
        /// <returns></returns>
        CardPaymentResponse MapToCardPaymentResponse(Transaction transaction);

        /// <summary>
        /// Maps the internal transaction details to the customer's reconcillation response
        /// </summary>
        /// <param name="transaction"></param>
        /// <returns></returns>
        TransactionResponse MapToTransactionResponse(Transaction transaction);
    }
}
