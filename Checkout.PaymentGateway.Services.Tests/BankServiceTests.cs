using Checkout.PaymentGateway.Models;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Checkout.PaymentGateway.Services.Tests
{
    public class BankServiceTests
    {
        [Fact]
        public async Task ValidCardReturnsSuccess()
        {
            var bankService = new BankService();

            var request = ModelDataHelper.GetBankCardRequest(500);

            var response = await bankService.ExecuteAsync(request);

            response.Should().NotBeNull();
            response.Id.Should().NotBeNullOrEmpty();
            response.Status.Should().Be(BankResponseStatus.Success);
            response.Details.Should().NotBeNullOrEmpty();

        }
        [Theory]
        [InlineData(100, "invalid amount")]
        [InlineData(200, "insufficient funds")]
        [InlineData(300, "card blocked")]
        public async Task InValidCardReturnsFailure(int amount, string bankResponse)
        {
            var bankService = new BankService();

            var request = ModelDataHelper.GetBankCardRequest(amount);

            var response = await bankService.ExecuteAsync(request);

            response.Should().NotBeNull();
            response.Id.Should().NotBeNullOrEmpty();
            response.Status.Should().Be(BankResponseStatus.Failed);
            response.Details.Should().NotBeNullOrEmpty();
            response.Details.Should().Be(bankResponse);
        }
    }
}
