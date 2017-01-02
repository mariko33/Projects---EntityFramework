using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversitySystem
{
    class Program
    {
        static void Main()
        {
            //TphUniversitySystemContext context=new TphUniversitySystemContext();
            //context.Database.Initialize(true);

            //TptUniversitySystemContext context=new TptUniversitySystemContext();
            //context.Database.Initialize(true);

            TpcUniversitySystemContext context=new TpcUniversitySystemContext();
            context.Database.Initialize(true);



        } 
    }
}
