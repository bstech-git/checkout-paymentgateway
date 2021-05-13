using System;
using System.Collections.Generic;
using System.Text;

namespace Checkout.PaymentGateway.Models
{
    public class BankResponse
    {
        public string Id { get; set; }

        public BankResponseStatus Status{ get; set; }

        public string Details { get; set; }
    }

    public enum BankResponseStatus
    {
        Success,
        Failed
    }
}
