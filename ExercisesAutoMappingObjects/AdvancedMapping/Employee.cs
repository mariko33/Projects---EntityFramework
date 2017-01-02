using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedMapping
{
    class Employee
    {
        private IList<Employee> employees;

        public Employee()
        {
            this.employees=new List<Employee>();
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public decimal Salary { get; set; }
        public DateTime BirthDay { get; set; }
        public string Address { get; set; }
        public bool IsOnHoliday { get; set; }
        public Employee Manager { get; set; }

        public IList<Employee> Employees
        {
            get { return this.employees; }
            set { this.employees = value; } 
            
        }

    }
}
