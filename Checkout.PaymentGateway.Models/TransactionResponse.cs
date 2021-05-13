using System;
using System.Collections.Generic;
using System.Text;

namespace Checkout.PaymentGateway.Models
{
    public class TransactionResponse
    {
        public string Id { get; set; }

        public CardDetail CardDetail { get; set; }

        /// <summary>
        /// The amount in lowest unit of currency. E.g. in pence for GBP etc
        /// </summary>
        public long Amount { get; set; }

        public string MerchantReference { get; set; }

        public string MerchantId { get; set; }

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

        public DateTime RequestedOn { get; set; }

        public DateTime ProcessedOn { get; set; }
    }
}
