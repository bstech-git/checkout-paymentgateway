using System;
using System.Collections.Generic;
using System.Text;

namespace Checkout.PaymentGateway.Models
{
    public class AuthorisationResult
    {
        public bool Valid { get; set; }

        public Merchant Merchant { get; set; }
    }
}
