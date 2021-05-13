using Checkout.PaymentGateway.Models;
using Checkout.PaymentGateway.Services.Interfaces;
using FluentAssertions;
using Moq;
using System;
using Xunit;

namespace Checkout.PaymentGateway.Services.Tests
{
    public class ModelConverterTests
    {

        [Fact]
        public void CardPaymentContextShouldContainNecessaryDetails()
        {
            var maskingServiceMock = new Mock<IMaskingService>();

            var modelConverter = new ModelConverter(maskingServiceMock.Object);
            var cardPaymentRequest = ModelDatHelper.GetValidCardPaymentRequest();
            var merchant = ModelDatHelper.GetTestMerchant();

            var cardContext = modelConverter.CreateCardPaymentContext(cardPaymentRequest, merchant);

            cardContext.Should().NotBeNull();
            cardContext.Amount.Should().Be(cardPaymentRequest.Amount);
            cardContext.CardDetail.Should().NotBeNull();
            cardContext.CardDetail.Name.Should().Be(cardPaymentRequest.Name);
            cardContext.CardDetail.CurrencyCode.Should().Be(cardPaymentRequest.CurrencyCode);
            cardContext.CardDetail.ExpiryMonth.Should().Be(cardPaymentRequest.ExpiryMonth);
            cardContext.CardDetail.ExpiryYear.Should().Be(cardPaymentRequest.ExpiryYear);
            cardContext.MerchantReference.Should().Be(cardPaymentRequest.Reference);
            cardContext.MerchantId.Should().Be(merchant.Id);
        }
    }
}
