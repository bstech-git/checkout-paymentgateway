using System;
using System.Collections.Generic;
using System.Text;

namespace Checkout.PaymentGateway.Models
{
    public class BankCardRequest
    {
        public CardDetail CardDetail { get; set; }

        /// <summary>
        /// 3 digit card varification value.
        /// Note: Some type of cards may have more than 3 digits e.g. Amex
        /// </summary>
       
        /// <summary>
        /// The amount in lowest unit of currency. E.g. in pence for GBP etc
        /// </summary>
        public long Amount { get; set; }
        public string Cvv { get; set; }

        public string Reference { get; set; }

        public string GatewayId { get; set; }

    }
}
