namespace DK.DeductionCalculator.Core.Models
{
    /// <summary>
    /// Models an employee of your company.
    /// </summary>
    public class Employee
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public IEnumerable<EmployeeDependent> Dependents { get; set; }
    }
}
