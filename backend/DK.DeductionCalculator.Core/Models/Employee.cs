namespace DK.DeductionCalculator.Core.Models
{
    public class Employee
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public IEnumerable<EmployeeDependent> Dependents { get; set; }
    }
}
