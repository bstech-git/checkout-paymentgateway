﻿using Checkout.PaymentGateway.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Checkout.PaymentGateway.Services.Tests
{
    public static class ModelDatHelper
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
    }
}
