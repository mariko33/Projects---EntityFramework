using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projection
{
    class EmployeeDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public decimal Salary { get; set; }
        public string ManagerName { get; set; }

        public override string ToString()
        {
            return string.Format($"{this.FirstName} {this.LastName} {this.Salary} - Manager: {this.ManagerName ?? "[no manager]"}");
        }
    }
}
