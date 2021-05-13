using Checkout.PaymentGateway.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Checkout.PaymentGateway.Api.ModelValidators
{
    public class CardPaymentRequestValidator : AbstractValidator<CardPaymentRequest>
    {
        public CardPaymentRequestValidator()
        {
            RuleFor(x => x.Number)
                .Cascade(CascadeMode.Continue)
                .NotNull()
                .WithMessage("Card Number must be supplied")
                .NotEmpty()
                .WithMessage("Card Number must be supplied")
                .CreditCard()
                .WithMessage("Invalid Card Number")
                .WithErrorCode("INVALID_CARD")
                ;

            RuleFor(x => x.ExpiryMonth)
                .Cascade(CascadeMode.Continue)
                .InclusiveBetween(1, 12)
                .WithMessage("Expiry month not valid");

            RuleFor(x => x.ExpiryYear)
                .Cascade(CascadeMode.Continue)
                 .NotEmpty()
                .GreaterThanOrEqualTo(DateTime.UtcNow.Year)
                .LessThanOrEqualTo(DateTime.UtcNow.Year + 15)
                .WithMessage($"CardExpiryYear should be in range from {DateTime.UtcNow.Year} to {DateTime.UtcNow.Year + 15}");

            RuleFor(x => x.Amount)
                .Cascade(CascadeMode.Continue)
                .GreaterThan(0)
                .WithMessage("Amount should be greater than zero");

            RuleFor(x => x.CurrencyCode)
                .Cascade(CascadeMode.Continue)
                .NotEmpty()
                .WithMessage("Currency must be supplied")
                .Must(x => x?.ToUpperInvariant() == "GBP")
                .WithMessage("Only GBP is supported as currency");

            RuleFor(x => x.Cvv)
                .Cascade(CascadeMode.Continue)
                .NotEmpty()
                .WithMessage("Cvv must be supplied")
                .Length(3, 4)
                .WithMessage("Invalid Cvv value");
        }
    }
}
