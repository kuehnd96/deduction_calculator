using DK.DeductionCalculator.Core.Models;

namespace DK.DeductionCalculator.Core.Interfaces
{
    /// <summary>
    /// Calculates an employee's benefit deduction.
    /// </summary>
    public interface IBenefitDeductionCalculator
    {
        int CalculateEmployeeDeduction(Employee employee);
    }
}
