using System;
using System.Collections.Generic;
using System.Text;

namespace Checkout.PaymentGateway.Models
{
    public class Transaction
    {
        public string TransactionId { get; set; }

        public CardDetail CardDetail { get; set; }

        /// <summary>
        /// The amount in lowest unit of currency. E.g. in pence for GBP etc
        /// </summary>
        public long Amount { get; set; }

        public string MerchantReference { get; set; }

        public string MerchantId { get; set; }

        public TransactionStatus Status { get; set; }

        /// <summary>
        /// The reference id returned from bank 
        /// </summary>
        public string BankReference { get; set; }

        /// <summary>
        /// The additional details returned from bank
        /// </summary>
        public string BankDetails { get; set; }
        
        public DateTime RequestedOn { get; set; }

        public DateTime ProcessedOn { get; set; }
    }

    public enum TransactionStatus
    {
        Fulfilled,
        Declined,
        Pending
    }
}
