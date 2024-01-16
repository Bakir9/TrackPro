using Core.Interfaces;

namespace API.Controllers
{
   
    public class PaymentsController : BaseApiController
    {
        private readonly ILogger<PaymentsController> _logger;
        private readonly IPaymentRepository _paymentRepository;
        
        public PaymentsController(IPaymentRepository paymentRepository, ILogger<PaymentsController> logger)
        {
            _paymentRepository = paymentRepository;
            _logger = logger;
        }
    }
}