using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace SimpleMapping
{
    class Program
    {
        static void Main()
        {
            Mapper.Initialize(cfg=>cfg.CreateMap<Employee,EmployeeDto>());
            var employee=new Employee
            {
                FirstName = "Pesho",
                LastName = "Peshev",
                Address = "Tintqva 1",
                BirthDay = new DateTime(1999-01-01),
                Salary = 800.00m

            };

            var emplyeeDto = Mapper.Map<EmployeeDto>(employee);
            Console.WriteLine($"{emplyeeDto.FirstName} {emplyeeDto.LastName} {emplyeeDto.Salary}");
        }
    }
}
