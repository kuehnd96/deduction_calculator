using DK.DeductionCalculator.Core.Interfaces;
using DK.DeductionCalculator.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace DK.DeductionCalculator.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DeductionCalculatorController : ControllerBase
    {
        private readonly ILogger<DeductionCalculatorController> _logger;
        private readonly IBenefitDeductionCalculator _deductionCalculator;

        public DeductionCalculatorController(ILogger<DeductionCalculatorController> logger, IBenefitDeductionCalculator deductionCalculator)
        {
            _logger = logger;
            _deductionCalculator = deductionCalculator;
        }

        [HttpPost(Name = "GetBenefitDeduction")]
        public decimal Post(Employee employee)
        {
            return _deductionCalculator.CalculateEmployeeDeduction(employee);
        }
    }
}