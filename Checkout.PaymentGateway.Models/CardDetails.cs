using System;
using System.Collections.Generic;
using System.Text;

namespace Checkout.PaymentGateway.Models
{
    public class CardDetail
    {
        public string Number { get; set; }

        public int ExpiryMonth { get; set; }

        public int ExpiryYear { get; set; }        

        /// <summary>
        /// The three-letter ISO currency code
        /// </summary>
        public string CurrencyCode { get; set; }

        public string Name { get; set; }

       
    }
}
