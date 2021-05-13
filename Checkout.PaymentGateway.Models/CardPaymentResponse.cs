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

        /// <summary>
        /// Indicates whether payment was successfull or not
        /// </summary>
        public bool Success { get; set; }

        /// <summary>
        /// Stutus of the payment request.
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// Amount requested
        /// </summary>
        public long Amount { get; set; }

        /// <summary>
        /// The currency of the payment 
        /// </summary>
        public string Currency { get; set; }

        /// <summary>
        /// Date and time of the processing of payment
        /// </summary>
        public DateTime ProcessedOn { get; set; }

        /// <summary>
        /// The reference from the acquiring bank
        /// </summary>
        public string BankReference { get; set; }

    }
}
