using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DK.DeductionCalculator.Core.Models
{
    public class Employee
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }

        public IEnumerable<EmployeeDependent> Dependents { get; set; }
    }
}
