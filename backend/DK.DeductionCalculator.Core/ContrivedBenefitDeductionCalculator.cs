using DK.DeductionCalculator.Core.Interfaces;
using DK.DeductionCalculator.Core.Models;

namespace DK.DeductionCalculator.Core
{
    /// <summary>
    /// Basic deduction calculator for employee benefits.
    /// </summary>
    public class ContrivedBenefitDeductionCalculator : IBenefitDeductionCalculator
    {
        private static int EmployeeAnnualDeduction = 1000;
        private static int EmployeeDependentAnnualDeduction = 500;
        private static decimal NameDiscount = 0.1M;
        private static string NameDiscountLetter = "A";

        /// <summary>
        /// Calculates the annual benefit deduction for an employee in a contrived manner.
        /// </summary>
        /// <param name="employee">The <see cref="Employee"/>employee</param> to calculate the deduction for. Cannot be null.
        /// <returns>The annual cost of benefits for the employee.</returns>
        public decimal CalculateEmployeeDeduction(Employee employee)
        {
            if (employee == null)
            {
                throw new ArgumentNullException(nameof(employee));
            }

            decimal deductionTotal = 0;

            if (employee.FirstName.StartsWith(NameDiscountLetter) ||
                employee.LastName.StartsWith(NameDiscountLetter))
            {
                deductionTotal = EmployeeAnnualDeduction - (EmployeeAnnualDeduction * NameDiscount);
            }
            else
            {
                deductionTotal = EmployeeAnnualDeduction;
            }

            foreach (var dependent in employee.Dependents)
            {
                if (dependent.FirstName.StartsWith(NameDiscountLetter) || 
                    dependent.LastName.StartsWith(NameDiscountLetter))
                {
                    deductionTotal += EmployeeDependentAnnualDeduction - (EmployeeDependentAnnualDeduction * NameDiscount);
                }
                else
                {
                    deductionTotal += EmployeeDependentAnnualDeduction;
                }
            }

            return deductionTotal;
        }
    }
}
