using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BillsPaymentSystem.Models;

namespace BillsPaymentSystem
{
    class Programcont
    {
        static void Main()
        {
            //TphBillsContext context=new TphBillsContext();
            //context.Database.Initialize(true);

            //TpcBillsContext context=new TpcBillsContext();
            //context.Database.Initialize(true);

            TptBillsContext context=new TptBillsContext();
            context.Database.Initialize(true);

        }
    }
}
