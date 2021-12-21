using DK.DeductionCalculator.Core.Models;

namespace DK.DeductionCalculator.Core.Interfaces
{
    /// <summary>
    /// Calculates an employee's benefit deduction.
    /// </summary>
    public interface IBenefitDeductionCalculator
    {
        /// <summary>
        /// Calculates the annual benefit deduction for an employee.
        /// </summary>
        /// <param name="employee">The <see cref="Employee"/>employee</param> to calculate the deduction for. Cannot be null.
        /// <returns>The annual cost of benefits for the employee.</returns>
        decimal CalculateEmployeeDeduction(Employee employee);
    }
}
