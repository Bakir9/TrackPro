using API.DTO;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace API.Controllers
{
   
    public class PaymentsController : BaseApiController
    {
        private readonly ILogger<PaymentsController> _logger;
        private readonly IPaymentRepository _paymentRepository;
        public readonly IMapper _mapper;
        
        public PaymentsController(IPaymentRepository paymentRepository, IMapper mapper,ILogger<PaymentsController> logger)
        {
            _paymentRepository = paymentRepository;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpPost("create")]
        public async Task<ActionResult<PaymentDTO>> CreatePayment(Payment payment)
        {
            if (payment is null)  return NotFound();

            Log.Information("Uspjesno kreirena nova uplate od strane jednog korisniak");
            _paymentRepository.Create(payment);
            await _paymentRepository.SaveAsync();

            return Ok(_mapper.Map<Payment, PaymentDTO>(payment));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<PaymentDTO>> DeletePayment(int id)
        {
            var payment = await _paymentRepository.GetPaymentById(id);
            if (payment is null) return NotFound();
            _paymentRepository.Delete(payment);
            await _paymentRepository.SaveAsync();

            return Ok(_mapper.Map<Payment, PaymentDTO>(payment));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<PaymentDTO>> Update(int id, [FromBody]Payment payment)
        {
            if(payment is null) return NotFound();

            _paymentRepository.Update(payment);
            await _paymentRepository.SaveAsync();

            var paymentUpdate = await _paymentRepository.GetPaymentById(id);

            return Ok(_mapper.Map<Payment, PaymentDTO>(paymentUpdate));
        }
    }
}