using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HospitalSystem.Models;

namespace HospitalSystem
{
    class Program
    {
        static void Main()
        {
            HospitalDatabse context=new HospitalDatabse();
            Patient p=new Patient()
            {
                FirstName = "Mm",
                LastName = "NN",
                Address = "Nqkade tam",
                Email = "mm@mmm.bg"
        
            };
            context.Patients.Add(p);
            //Doctor doc = new Doctor()
            //{
            //    Name = "Petrov",
            //    Speciality = "Pediatry"
            //};
            //context.Doctors.Add(doc);
            context.SaveChanges();
            
        }
    }
}
