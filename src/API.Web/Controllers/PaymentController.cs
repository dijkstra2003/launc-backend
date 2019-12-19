using System.Threading.Tasks;
using API.Core.Dtos;
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

        public PaymentController(IPaymentService paymentService, IMapper mapper)
        {
            _paymentService = paymentService;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> CreatePayment([FromBody] PaymentDto paymentDto)
        {
            var payment = await _paymentService.CreatePayment(100, new Goal { Id = 1 }, new SubGoal { Id = 1 });

            return Ok(_mapper.Map<Payment, PaymentDto>(payment));
        }
    }
}