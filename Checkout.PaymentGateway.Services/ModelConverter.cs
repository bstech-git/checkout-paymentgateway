using Checkout.PaymentGateway.Models;
using Checkout.PaymentGateway.Models.Contexts;
using Checkout.PaymentGateway.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Checkout.PaymentGateway.Services
{
    public class ModelConverter : IModelConverter
    {
        private readonly IMaskingService _maskingService;

        public ModelConverter(IMaskingService maskingService)
        {
            _maskingService = maskingService;
        }

        /// <summary>
        /// Creates a card payment context from card payment request and merchant details
        /// </summary>
        /// <param name="cardPaymentRequest"></param>
        /// <param name="merchant"></param>
        /// <returns></returns>
        public CardPaymentContext CreateCardPaymentContext(CardPaymentRequest cardPaymentRequest, Merchant merchant)
        {
            return new CardPaymentContext()
            {
                CardDetail = new CardDetail()
                {
                    ExpiryMonth = cardPaymentRequest.ExpiryMonth,
                    ExpiryYear = cardPaymentRequest.ExpiryYear,
                    CurrencyCode = cardPaymentRequest.CurrencyCode,
                    Name = cardPaymentRequest.Name,
                    Number = cardPaymentRequest.Number.Replace("-", "").Replace(" ", "")
                },
                Amount = cardPaymentRequest.Amount,
                MerchantReference = cardPaymentRequest.Reference,
                MerchantId = merchant.Id
            };
        }

        /// <summary>
        /// Maps the internal transactoin details to the customer response
        /// </summary>
        /// <param name="transaction"></param>
        /// <returns></returns>
        public CardPaymentResponse MapToCardPaymentResponse(Transaction transaction)
        {
            return new CardPaymentResponse()
            {
                Id = transaction.TransactionId,
                Success = transaction.Status == TransactionStatus.Fulfilled,
                BankReference = transaction.BankReference,
                Amount = transaction.Amount,
                Currency = transaction.CardDetail.CurrencyCode,
                Status = transaction.Status.ToString().ToLowerInvariant(),
                ProcessedOn = transaction.ProcessedOn
            };
        }

        /// <summary>
        /// Maps the internal transaction details to the customer's reconcillation response
        /// </summary>
        /// <param name="transaction"></param>
        /// <returns></returns>
        public TransactionResponse MapToTransactionResponse(Transaction transaction)
        {
            return new TransactionResponse()
            {
                Id = transaction.TransactionId,
                Success = transaction.Status == TransactionStatus.Fulfilled,
                Status = transaction.Status.ToString().ToLowerInvariant(),
                Amount = transaction.Amount,
                CardDetail = new CardDetail()
                {
                    CurrencyCode = transaction.CardDetail.CurrencyCode,
                    Name = transaction.CardDetail.Name,
                    Number = _maskingService.Mask(transaction.CardDetail.Number),
                    ExpiryMonth = transaction.CardDetail.ExpiryMonth,
                    ExpiryYear = transaction.CardDetail.ExpiryYear
                },
                BankReference = transaction.BankReference,
                BankDetails = transaction.BankDetails,
                MerchantReference = transaction.MerchantReference,
                MerchantId = transaction.MerchantId,
                ProcessedOn = transaction.ProcessedOn,
                RequestedOn = transaction.RequestedOn
            };
        }
    }
}
