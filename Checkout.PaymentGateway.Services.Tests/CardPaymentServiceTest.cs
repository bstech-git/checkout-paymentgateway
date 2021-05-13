using Checkout.PaymentGateway.Models;
using Checkout.PaymentGateway.Models.Contexts;
using Checkout.PaymentGateway.Services.Interfaces;
using FluentAssertions;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Checkout.PaymentGateway.Services.Tests
{
    public class CardPaymentServiceTest
    {
        [Fact]
        public async Task ValidCardPaymentReturnsSuccess()
        {
            var transactionServiceMock = new Mock<ITransactionService>();
            var bankServiceMock = new Mock<IBankService>();
            var modelConverter = new ModelConverter(new MaskingService());
            var loggerMock = new Mock<ILogger<CardPaymentService>>();
                        
            var cardPaymentService = new CardPaymentService(transactionServiceMock.Object, bankServiceMock.Object, modelConverter, loggerMock.Object);
            var cardPaymentRequest = ModelDatHelper.GetValidCardPaymentRequest();
            var merchant = ModelDatHelper.GetTestMerchant();

            var cardPaymentContext = modelConverter.CreateCardPaymentContext(cardPaymentRequest, merchant);

            var transaction = new Transaction()
            {
                TransactionId = Guid.NewGuid().ToString(),
                CardDetail = cardPaymentContext.CardDetail,
                Amount = cardPaymentContext.Amount,
                MerchantId = merchant.Id,
                MerchantReference = cardPaymentContext.MerchantReference,
                RequestedOn = DateTime.UtcNow
            };

            transactionServiceMock.Setup(x => x.InitialiseTransactionAsync(It.IsAny<CardPaymentContext>())).ReturnsAsync(transaction);

            var bankResponse = new BankResponse()
            {
                Id = "BNK_111",
                Status = BankResponseStatus.Success,
                Details = "Authorised"
            };

            bankServiceMock.Setup(x => x.ExecuteAsync(It.IsAny<BankCardRequest>())).ReturnsAsync(bankResponse);

            var updatedTransaction = transaction;
            updatedTransaction.BankDetails = bankResponse.Details;
            updatedTransaction.BankReference = bankResponse.Id;
            updatedTransaction.Status = TransactionStatus.Fulfilled;
            updatedTransaction.ProcessedOn = DateTime.UtcNow;

            transactionServiceMock.Setup(x => x.UpdateTransactionAsync(transaction.TransactionId, bankResponse)).ReturnsAsync(updatedTransaction);


            var response = await cardPaymentService.ProcessAsync(cardPaymentRequest,merchant);

            response.Should().NotBeNull();
            response.Amount.Should().Be(cardPaymentRequest.Amount);
            response.Currency.Should().Be(cardPaymentRequest.CurrencyCode);
            response.Success.Should().BeTrue();
            response.Status.Should().Be("fulfilled");
            response.BankReference.Should().Be(bankResponse.Id);
        }
    }
}
