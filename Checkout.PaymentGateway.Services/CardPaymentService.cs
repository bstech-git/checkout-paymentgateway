using Checkout.PaymentGateway.Models;
using Checkout.PaymentGateway.Services.Interfaces;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace Checkout.PaymentGateway.Services
{
    public class CardPaymentService : ICardPaymentService
    {
        private readonly ITransactionService _transactionService;
        private readonly IBankService _bankService;
        private readonly IModelConverter _modelConverter;
        private readonly ILogger<CardPaymentService> _logger;

        public CardPaymentService(ITransactionService transactionService, 
            IBankService bankService, 
            IModelConverter modelConverter,
            ILogger<CardPaymentService> logger)
        {
            _transactionService = transactionService;
            _bankService = bankService;
            _modelConverter = modelConverter;
            _logger = logger;
        }

        /// <summary>
        /// Processes a card payment
        /// </summary>
        /// <param name="cardPaymentRequest">payment request from merchant</param>
        /// <param name="merchant">Merchant details</param>
        /// <returns></returns>
        public async Task<CardPaymentResponse> ProcessAsync(CardPaymentRequest cardPaymentRequest, Merchant merchant)
        {
            var cardPaymentContext = _modelConverter.CreateCardPaymentContext(cardPaymentRequest, merchant);

            _logger.LogInformation($"Initiating transaction for {cardPaymentContext.MerchantId} {cardPaymentContext.MerchantReference}");

            //Generate transaction with unique id in pending state
            var transaction = await _transactionService.InitialiseTransactionAsync(cardPaymentContext);

            _logger.LogInformation($"Transaction {transaction.TransactionId} created for {cardPaymentContext.MerchantId} {cardPaymentContext.MerchantReference}");
            
            var bankCardRequest = new BankCardRequest()
            {
                CardDetail = cardPaymentContext.CardDetail,
                Amount = cardPaymentContext.Amount,
                Cvv = cardPaymentRequest.Cvv,
                Reference = cardPaymentContext.MerchantReference,
                GatewayId = transaction.TransactionId
            };

            // go to bank and get the response
            var response = await _bankService.ExecuteAsync(bankCardRequest);

            _logger.LogInformation($"Bank response for TId={transaction.TransactionId} Bank [{response.Id} {response.Status}]");

            // Update the transaction with bank response
            var finalTransaction = await _transactionService.UpdateTransactionAsync(transaction.TransactionId, response);

            _logger.LogInformation($"TId={transaction.TransactionId} updated with bank response [{response.Id} {response.Status}]");

            return _modelConverter.MapToCardPaymentResponse(finalTransaction);
        }

        /// <summary>
        /// Gets the details of a payment made previously
        /// </summary>
        /// <param name="paymentId"></param>
        /// <returns></returns>
        public async Task<TransactionResponse> GetPaymentAsync(string paymentId)
        {            
            var transaction = await _transactionService.GetTransaction(paymentId);

            return _modelConverter.MapToTransactionResponse(transaction);
        }       
    }
}
