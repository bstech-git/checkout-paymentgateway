using System;
using System.Collections.Generic;
using System.Text;

namespace Checkout.PaymentGateway.Models
{
    public class CardPaymentResponse
    {
        /// <summary>
        /// Unique identifier for the payment
        /// </summary>
        public string Id { get; set; }

        public bool Success { get; set; }

        /// <summary>
        /// Stutus of the payment request.
        /// </summary>
        public string Status { get; set; }

        public long Amount { get; set; }

        public string Currency { get; set; }

        public DateTime ProcessedOn { get; set; }

        public string BankReference { get; set; }

    }
}
