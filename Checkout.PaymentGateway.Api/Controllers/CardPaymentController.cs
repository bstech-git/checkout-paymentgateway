using Checkout.PaymentGateway.Models;
using Checkout.PaymentGateway.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace Checkout.PaymentGateway.Api.Controllers
{
    [Route("payments")]
    [ApiController]
    public class CardPaymentController : ControllerBase
    {
        private readonly ICardPaymentService _cardPaymentService;
        private readonly ILogger<CardPaymentController> _logger;

        public CardPaymentController(ICardPaymentService cardPaymentService, ILogger<CardPaymentController> logger)
        {
            _cardPaymentService = cardPaymentService;
            _logger = logger;
        }

        [HttpPost("")]
        public async Task<IActionResult> CardPayment([FromBody] CardPaymentRequest cardPaymentRequest)
        {
            _logger.LogInformation($"Action=CardPayment Amount={cardPaymentRequest.Amount} Currency={cardPaymentRequest.CurrencyCode} Reference={cardPaymentRequest.Reference}");

            var merchant = HttpContext.Items["Merchant"] as Merchant;

            return Ok(await _cardPaymentService.ProcessAsync(cardPaymentRequest, merchant));
        }

        [HttpGet("{paymentId}")]
        public async Task<IActionResult> GetCardPayment([FromRoute]string paymentId)
        {
            _logger.LogInformation($"Action=GetCardPayment PaymentId={paymentId}");

            var payment = await _cardPaymentService.GetPaymentAsync(paymentId);

            if (payment == null)
                return NotFound();

            return Ok(payment);
        }
    }
}
