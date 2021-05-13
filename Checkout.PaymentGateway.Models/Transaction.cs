using System;
using System.Collections.Generic;
using System.Text;

namespace Checkout.PaymentGateway.Models
{
    public class Transaction
    {
        /// <summary>
        /// Identifier for the transaction
        /// </summary>
        public string TransactionId { get; set; }

        /// <summary>
        /// CardDetails used in the payment
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
        /// Status of the transaction
        /// </summary>
        public TransactionStatus Status { get; set; }

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

    public enum TransactionStatus
    {
        Fulfilled,
        Declined,
        Pending
    }
}
