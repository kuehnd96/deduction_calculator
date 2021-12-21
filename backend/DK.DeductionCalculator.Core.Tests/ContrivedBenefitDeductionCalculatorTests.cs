using DK.DeductionCalculator.Core.Models;
using System;
using System.Collections.Generic;
using Xunit;

namespace DK.DeductionCalculator.Core.Tests
{
    public class ContrivedBenefitDeductionCalculatorTests
    {
        [Fact]
        public void CalculateEmployeeDeduction_Missing_Employee()
        {
            // ARRANGE
            var subject = new ContrivedBenefitDeductionCalculator();
            
            // ACT
            Assert.Throws<ArgumentNullException>(() => subject.CalculateEmployeeDeduction(null));
        }

        [Fact]
        public void CalculateEmployeeDeduction_Just_Employee()
        {
            // ARRANGE
            var subject = new ContrivedBenefitDeductionCalculator();
            var employee = new Employee()
            {
                FirstName = "John",
                LastName = "Smith",
                Dependents = new List<EmployeeDependent>()
            };

            // ACT
            var deductionAmount = subject.CalculateEmployeeDeduction(employee);

            // MEASURE
            Assert.Equal(1000, deductionAmount);
        }

        [Fact]
        public void CalculateEmployeeDeduction_Employee_With_Dependents()
        {
            // ARRANGE
            var subject = new ContrivedBenefitDeductionCalculator();
            var employee = new Employee()
            {
                FirstName = "John",
                LastName = "Smith",
                Dependents = new List<EmployeeDependent>()
                { 
                    new EmployeeDependent { FirstName = "Sam", LastName = "Schulz" }, 
                    new EmployeeDependent { FirstName = "Jane", LastName = "Doe" }
                }
            };

            // ACT
            var deductionAmount = subject.CalculateEmployeeDeduction(employee);

            // MEASURE
            Assert.Equal(2000, deductionAmount);
        }

        [Fact]
        public void CalculateEmployeeDeduction_Employee_Name_Discount_With_Dependents()
        {
            // ARRANGE
            var subject = new ContrivedBenefitDeductionCalculator();
            var employee = new Employee()
            {
                FirstName = "Aaron",
                LastName = "Smith",
                Dependents = new List<EmployeeDependent>()
                {
                    new EmployeeDependent { FirstName = "Sam", LastName = "Smith" },
                    new EmployeeDependent { FirstName = "Jane", LastName = "Smith" }
                }
            };

            // ACT
            var deductionAmount = subject.CalculateEmployeeDeduction(employee);

            // MEASURE
            Assert.Equal(1900, deductionAmount);
        }

        [Fact]
        public void CalculateEmployeeDeduction_Employee_With_Dependents_With_Name_Discounts()
        {
            // ARRANGE
            var subject = new ContrivedBenefitDeductionCalculator();
            var employee = new Employee()
            {
                FirstName = "John",
                LastName = "Smith",
                Dependents = new List<EmployeeDependent>()
                {
                    new EmployeeDependent { FirstName = "Brenda", LastName = "Smith" },
                    new EmployeeDependent { FirstName = "Alan", LastName = "Smith" },
                    new EmployeeDependent { FirstName = "Allison", LastName = "Smith" }
                }
            };

            // ACT
            var deductionAmount = subject.CalculateEmployeeDeduction(employee);

            // MEASURE
            Assert.Equal(2400, deductionAmount);
        }
    }
}