using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HomeworkIntroductionEntityFramework
{
    class Program
    {
        static void Main()
        {
            System.Globalization.CultureInfo customCulture = (System.Globalization.CultureInfo)System.Threading.Thread.CurrentThread.CurrentCulture.Clone();
            customCulture.NumberFormat.NumberDecimalSeparator = ".";

            System.Threading.Thread.CurrentThread.CurrentCulture = customCulture;
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");    //Formating Date and Time
            SoftuniContext context = new SoftuniContext();
            using (context)
            {
                //Insert
                //Town townTwo = new Town { Name = "Svishtov" };
                //context.Towns.Add(townTwo);
                //context.SaveChanges();

                //Town studentski = context.Towns.FirstOrDefault(town => town.Name == "Studentski");
                //Address mandjaSt = new Address {AddressText = "Mandja brat"};
                //studentski.Addresses.Add(mandjaSt);
                //context.SaveChanges();

                //Remove

                //Town st = context.Towns.FirstOrDefault(town => town.Name == "Studentski");
                //context.Addresses.RemoveRange(st.Addresses);   //Remove all adresses with town = st
                //context.Towns.Remove(st);                      //Remove town = Studentski 
                //context.SaveChanges();

                //Querying

                //IEnumerable<Address> adresses = context.Addresses;
                //foreach (var adress in adresses)
                //{
                //    Console.WriteLine(adress.AddressText);
                //    Console.WriteLine("-----------"+adress.Town.Name);
                //}

                //IEnumerable<Employee> employees = context.Employees
                //    .Where(employee => employee.Projects.Count(
                //                           project => project.StartDate.Year >= 2001 && project.StartDate.Year <= 2003) >
                //                       0)
                //    .Take(30);

                //foreach (var employee in employees)
                //{
                //    Console.WriteLine($"{employee.FirstName} {employee.LastName} {employee.Manager.FirstName}");
                //    foreach (Project project in employee.Projects)
                //    {
                //        if (project.StartDate.Year >= 2001 && project.StartDate.Year <= 2003)
                //        {

                //            Console.WriteLine($"--{project.Name} {project.StartDate:d} {project.EndDate:M/d/yyyy hh:mm:ss tt}");
                //        }

                //    }
                //}

                //Task 3

                //IEnumerable<Employee> employees = context.Employees;
                //foreach (var employee in employees)
                //{
                //    Console.WriteLine($"{employee.FirstName} {employee.LastName} {employee.MiddleName}" +
                //                      $" {employee.JobTitle} {employee.Salary}");
                //}

                //Task 4

                //var employeesNames = context.Employees
                //    .Where(e => e.Salary > 50000)
                //    .Select(e => e.FirstName);
                //foreach (var employeeName in employeesNames)
                //{
                //    Console.WriteLine(employeeName);
                //}

                //Task 5

                //var employees = context.Employees
                //    .Where(e => e.Department.Name == "Research and Development")
                //    .OrderBy(e => e.Salary)
                //    .ThenByDescending(e => e.FirstName);
                //foreach (var employee in employees)
                //{
                //    Console.WriteLine($"{employee.FirstName} {employee.LastName}" +
                //                      $" from {employee.Department.Name} - ${employee.Salary:F2}");
                //}


                //Таск 6

                // Address adress = new Address
                // {
                //     AddressText = "Vitoshka 15",
                //     TownID = 4

                // };

                // context.Addresses.Add(adress);
                // context.SaveChanges();

                //Employee  employee = context.Employees.FirstOrDefault(e => e.LastName == "Nakov");
                // employee.Address = adress;
                // context.SaveChanges();

                //IEnumerable<Employee> employees = context.Employees
                //    .OrderByDescending(e => e.AddressID)
                //    .Take(10);

                //foreach (var employee in employees)
                //{

                //    Console.WriteLine(employee.Address.AddressText);
                //}

                //Task 7

                //var project = context.Projects.Find(2);
                //context.Employees.RemoveRange(project.Employees);
                //context.Projects.Remove(project);
                //context.SaveChanges();

                //Task 9

                //var adresses = context.Addresses
                //    .OrderByDescending(a => a.Employees.Count())
                //    .ThenBy(a => a.Town.Name)
                //    .Take(10);
                //foreach (var adress in adresses)
                //{
                //    Console.WriteLine($"{adress.AddressText}, {adress.Town.Name} - {adress.Employees.Count()} employees");
                //}

                //Task 10
                //var employee = context.Employees.Find(147);
                //IEnumerable<Project> employeeProjects = employee.Projects.OrderBy(project => project.Name);
                //Console.WriteLine($"{employee.FirstName} {employee.LastName} {employee.JobTitle}");
                //foreach (var employeeProject in employeeProjects)
                //{
                //    Console.WriteLine(employeeProject.Name);
                    
                //}

               //Task 11
                //IEnumerable<Department> departments = context.Departments
                //    .Where(dep => dep.Employees.Count > 5)
                //    .OrderBy(dep=>dep.Employees.Count);
                
                //foreach (var department in departments)
                //{
                //    Console.WriteLine($"{department.Name} {department.Manager.FirstName}");
                   
                //    foreach (Employee employee in department.Employees)
                //    {
                //        Console.WriteLine($"{employee.FirstName} {employee.LastName} {employee.JobTitle}");
                //    }
                //}

            //Task 15
                //IEnumerable<Project> projects = context.Projects.OrderByDescending(pro => pro.StartDate).
                //    Take(10).
                //    OrderBy(pro=>pro.Name);
                //foreach (var project in projects)
                //{
                //    Console.WriteLine($"{project.Name} {project.Description} {project.StartDate} {project.EndDate}");
                //}

            //Таск 16
                //IEnumerable<Employee> employees = context.Employees
                //    .Where(e => e.Department.Name == "Engineering" ||
                //                e.Department.Name == "Tool Design" ||
                //                e.Department.Name == "Marketing" ||
                //                e.Department.Name == "Informaition Services");
                //foreach (var employee in employees)
                //{
                //    employee.Salary *= 1.12m;
                //    Console.WriteLine($"{employee.FirstName} {employee.LastName} (${employee.Salary})");

                //}

               // context.SaveChanges();

            //Task 17



            }

        }
    }
}
