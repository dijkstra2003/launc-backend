using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using API.Core.Dtos.Mollie;
using API.Core.Dtos.Payment;
using API.Core.Entities;
using API.Web.Services;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace API.Web.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class PaymentController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMolliePaymentService _paymentService;
        private readonly IGoalService _goalService;
        private readonly ISubgoalService _subgoalService;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public PaymentController(
            IUserService userService,
            IMolliePaymentService paymentService,
            IGoalService goalService,
            ISubgoalService subgoalService,
            IMapper mapper,
            ILogger<PaymentController> logger
        ) {
            _userService = userService;
            _paymentService = paymentService;
            _goalService = goalService;
            _subgoalService = subgoalService;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpGet()]
        public async Task<IActionResult> ListPayments()
        {
            var user = await _userService.FindByIdentityAsync(this.User.Identity as ClaimsIdentity);
            var payments = await _paymentService.ListPaymentsFromUser(user);

            return Ok(_mapper.Map<List<MolliePayment>, List<ListPaymentDto>>(payments));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPayment(int id)
        {
            var user = await _userService.FindByIdentityAsync(this.User.Identity as ClaimsIdentity);
            var payment = await _paymentService.ListPaymentFromUser(user, id);

            if (payment == null) {
                return NotFound();
            }

            return Ok(_mapper.Map<MolliePayment, ListPaymentDto>(payment));
        }

        [Route("ideal")]
        [HttpPost]
        public async Task<IActionResult> CreatePaymentIdeal([FromBody] PaymentDto paymentDto)
        {
            User user;
            Goal goal;

            try {
                user = await _userService.FindByIdentityAsync(this.User.Identity as ClaimsIdentity);
                goal = await _goalService.GetGoalAsync(paymentDto.GoalId);

            } catch(NullReferenceException ex) {
                _logger.LogWarning(ex.Message);
                return NotFound();
            }

            var subgoal = await _subgoalService.GetSubGoalAsync(paymentDto.SubGoalId);

            var payment = await _paymentService.CreatePayment(
                Decimal.Parse(paymentDto.Amount),
                user,
                goal,
                subgoal,
                PaymentMethod.IDEAL
            );

            return Ok(new PaymentResponse { 
                PaymentId = payment.Id,
                Url = payment.Response.CheckoutUrl
            });
        }

        [Route("paypal")]
        [HttpPost]
        public async Task<IActionResult> CreatePaymentPaypal([FromBody] PaymentDto paymentDto)
        {
            User user;
            Goal goal;

            try {
                user = await _userService.FindByIdentityAsync(this.User.Identity as ClaimsIdentity);
                goal = await _goalService.GetGoalAsync(paymentDto.GoalId);
            } catch (NullReferenceException ex) {
                _logger.LogWarning(ex.Message);
                return NotFound();
            }

            var subgoal = await _subgoalService.GetSubGoalAsync(paymentDto.SubGoalId);

            var payment = await _paymentService.CreatePayment(
                Decimal.Parse(paymentDto.Amount),
                user,
                goal,
                subgoal,
                PaymentMethod.PAYPAL
            );

            return Ok(new PaymentResponse {
                PaymentId = payment.Id,
                Url = payment.Response.CheckoutUrl
            });
        }

        [Route("webhook")]
        [HttpPost]
        [AllowAnonymous]
        [Consumes("application/x-www-form-urlencoded")]
        public async Task<IActionResult> ProcessWebhook([FromForm] PaymentWebhook paymentWebhook) {

            try {
                await _paymentService.UpdatePaymentStatus(paymentWebhook.Id);

                var payment = await _paymentService.FetchPaymentByMollieId(paymentWebhook.Id);

                if (_paymentService.IsPaid(payment))
                {
                    await _goalService.UpdateGoalAmountAsync(payment.Goal);
                    await _subgoalService.UpdateGoalAmountAsync(payment.SubGoal);
                }

            } catch (Exception e) {
                _logger.LogError(e.Message);
                return BadRequest();
            } 

            return Ok();
        }
    }
}