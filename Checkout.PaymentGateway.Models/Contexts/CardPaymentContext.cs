using System;
using System.Collections.Generic;
using System.Text;

namespace Checkout.PaymentGateway.Models.Contexts
{
    public class CardPaymentContext
    {
        public CardDetail CardDetail { get; set; }

        /// <summary>
        /// The amount in lowest unit of currency. E.g. in pence for GBP etc
        /// </summary>
        public long Amount { get; set; }

        /// <summary>
        /// Merchant system reference for the request
        /// </summary>
        public string MerchantReference { get; set; }

        /// <summary>
        /// MerchantId registered in the payment Gateway
        /// </summary>
        public string MerchantId { get; set; }
    }
}
