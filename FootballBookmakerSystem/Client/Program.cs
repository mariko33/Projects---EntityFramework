using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;

namespace Client
{
    class Program
    {
        static void Main()
        {
            FootballBookmarkerContext context=new FootballBookmarkerContext();
            context.Database.Initialize(true);
        }
    }
}
