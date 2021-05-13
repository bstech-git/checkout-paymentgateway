using System;
using System.Collections.Generic;
using System.Text;

namespace Checkout.PaymentGateway.Models
{
    public class CardDetail
    {
        /// <summary>
        /// The 16 digit card number
        /// </summary>
        public string Number { get; set; }

        /// <summary>
        /// The expiry month of the card. Should be between 1 and 12
        /// </summary>
        public int ExpiryMonth { get; set; }

        /// <summary>
        /// The expiry year of the card.
        /// </summary>
        public int ExpiryYear { get; set; }        

        /// <summary>
        /// The three-letter ISO currency code
        /// </summary>
        public string CurrencyCode { get; set; }

        /// <summary>
        /// Name on the card
        /// </summary>
        public string Name { get; set; }

       
    }
}
