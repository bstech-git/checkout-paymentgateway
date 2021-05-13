using System;
using System.Collections.Generic;
using System.Text;

namespace Checkout.PaymentGateway.Models
{
    /// <summary>
    /// Represents the result of an authorisation request
    /// </summary>
    public class AuthorisationResult
    {
        public bool Valid { get; set; }

        /// <summary>
        /// Merchant detail who matched the authorisation
        /// </summary>
        public Merchant Merchant { get; set; }
    }
}
