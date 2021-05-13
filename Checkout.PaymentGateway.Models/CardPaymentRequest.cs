using System;

namespace Checkout.PaymentGateway.Models
{
    public class CardPaymentRequest
    {
        /// <summary>
        /// The 16 digit card number
        /// </summary>
        public string Number { get; set; }

        /// <summary>
        /// Expiry month of the card.
        /// Has to be between 1 and 12
        /// </summary>
        public int ExpiryMonth { get; set; }

        /// <summary>
        /// Expiry year of the card
        /// </summary>
        public int ExpiryYear { get; set; }

        /// <summary>
        /// The amount in lowest unit of currency. E.g. in pence for GBP etc
        /// </summary>
        public long Amount { get; set; }

        /// <summary>
        /// The three-letter ISO currency code
        /// </summary>
        public string CurrencyCode { get; set; }

        /// <summary>
        /// Name on the card
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 3 digit card varification value.
        /// Note: Some type of cards may have more than 3 digits e.g. Amex
        /// </summary>
        public string Cvv { get; set; }

        /// <summary>
        /// Merchant system reference for the request
        /// </summary>
        public string Reference { get; set; }
    }
}
