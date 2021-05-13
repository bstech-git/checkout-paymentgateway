using System;
using System.Collections.Generic;
using System.Text;

namespace Checkout.PaymentGateway.Models
{
    public class TransactionResponse
    {
        /// <summary>
        /// Identifier for the payment
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Card details used in the payment 
        /// </summary>
        public CardDetail CardDetail { get; set; }

        /// <summary>
        /// The amount in lowest unit of currency. E.g. in pence for GBP etc
        /// </summary>
        public long Amount { get; set; }

        /// <summary>
        /// Reference supplied by the merchant when requesting the payment
        /// </summary>
        public string MerchantReference { get; set; }

        /// <summary>
        /// Payment gateway id for the merchant
        /// </summary>

        public string MerchantId { get; set; }

        /// <summary>
        /// Indicates whether payment was successful or not
        /// </summary>
        public bool Success { get; set; }

        /// <summary>
        /// Stutus of the payment request.
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// The reference id returned from bank 
        /// </summary>
        public string BankReference { get; set; }

        /// <summary>
        /// The additional details returned from bank
        /// </summary>
        public string BankDetails { get; set; }

        /// <summary>
        /// Date and time when request was received
        /// </summary>
        public DateTime RequestedOn { get; set; }

        /// <summary>
        /// Date and time of the processing of payment
        /// </summary>
        public DateTime ProcessedOn { get; set; }
    }
}
