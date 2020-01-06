using System.Threading.Tasks;
using API.Core.Dtos.Mollie;
using API.Core.Dtos.Payment;
using API.Core.Entities;
using API.Web.Services;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Web.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentService _paymentService;
        private readonly IGoalService _goalService;
        private readonly IMapper _mapper;

        public PaymentController(IPaymentService paymentService, IGoalService goalService, IMapper mapper)
        {
            _paymentService = paymentService;
            _goalService = goalService;
            _mapper = mapper;
        }

        [Route("ideal")]
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> CreatePaymentIdeal([FromBody] PaymentDto paymentDto)
        {
            var goal = await _goalService.GetGoalAsync(paymentDto.GoalId);
            var subgoal = await _goalService.GetSubGoalAsync(paymentDto.SubGoalId);

            var payment = (MolliePayment) await _paymentService.CreatePayment(
                paymentDto.Amount,
                goal,
                subgoal,
                PaymentMethod.IDEAL
            );

            return Ok(new PaymentResponse { Url = payment.Response.CheckoutUrl });
        }

        [Route("paypal")]
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> CreatePaymentPaypal([FromBody] PaymentDto paymentDto)
        {
            var goal = await _goalService.GetGoalAsync(paymentDto.GoalId);
            var subgoal = await _goalService.GetSubGoalAsync(paymentDto.SubGoalId);

            var payment = (MolliePayment) await _paymentService.CreatePayment(
                paymentDto.Amount,
                goal,
                subgoal,
                PaymentMethod.PAYPAL
            );

            return Ok(new PaymentResponse { Url = payment.Response.CheckoutUrl });
        }

        [Route("webhook")]
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> ProcessWebhook([FromBody] PaymentWebhook paymentWebhook) {
            return Ok();
        }
    }
}