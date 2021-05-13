using Checkout.PaymentGateway.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Checkout.PaymentGateway.Services
{
    public class MaskingService : IMaskingService
    {
        public string Mask(string input)
        {
            return string.Format($"************{input.Substring(12, 4)}");
        }
    }
}
