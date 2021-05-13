using Checkout.PaymentGateway.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Checkout.PaymentGateway.Services.Tests
{
    public static class ModelDataHelper
    {
        public static CardPaymentRequest GetValidCardPaymentRequest()
        {
            return new CardPaymentRequest()
            {
                Number = "1234 5678 1111 3333",
                Amount = 5000,
                Name = "Mr Test",
                ExpiryMonth = 10,
                ExpiryYear = DateTime.UtcNow.Year + 5,
                CurrencyCode = "GBP",
                Cvv = "123",
                Reference = GetRandomString(10)
            };
        }

        public static Merchant GetTestMerchant()
        {
            return new Merchant()
            {
                Id = "MK_111",
                Name = "Test Merchant"
            };
        }

        public static string GetRandomString(int length)
        {
            StringBuilder str_build = new StringBuilder();
            Random random = new Random();

            char letter;

            for (int i = 0; i < length; i++)
            {
                double flt = random.NextDouble();
                int shift = Convert.ToInt32(Math.Floor(25 * flt));
                letter = Convert.ToChar(shift + 65);
                str_build.Append(letter);
            }
            return str_build.ToString();

        }

        /// <summary>
        /// Gets a bank card request
        /// Amount 100, 200 or 300 can be used to generate a failed bank response 
        /// </summary>
        /// <param name="amount">amount of card payment</param>
        /// <returns></returns>
        public static BankCardRequest GetBankCardRequest(int amount)
        {
            return new BankCardRequest()
            {
                Amount = amount, 
                Cvv = "123",
                GatewayId = "GTW_1234",
                Reference = "MER_1111",
                CardDetail = new CardDetail()
                {
                    Name = "Mr Test",
                    Number = "1234567811112222",
                    CurrencyCode = "GBP",
                    ExpiryMonth = 9,
                    ExpiryYear = 2023
                }
            };
        }
    }
}
