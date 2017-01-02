using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ads.Data;

namespace Ads.Client
{
    class Program
    {
        static void Main()
        {
            AdsContext context=new AdsContext();
            //ExecuteWithoutInclude(context);
            //ExecuteWithInclud(context);
            SelectCertainColumn(context);
            SelectEverything(context);

        }


        public static void SelectEverything(AdsContext context)
        {
            Stopwatch watch=new Stopwatch();
            watch.Start();
            var adsSelect = context.Ads;
            foreach (var ad in adsSelect)
            {
                Console.WriteLine($"{ad.Title}");
            }
            watch.Stop();
            Console.WriteLine($"With select: {watch.Elapsed}");
        }

        public static void SelectCertainColumn(AdsContext context)
        {
            Stopwatch watch=new Stopwatch();
            watch.Start();
            var adsTitles = context.Ads.Select(a => a.Title);
            foreach (var title in adsTitles)
            {
                Console.WriteLine(title);
            }
            watch.Stop();
            Console.WriteLine($"Whith select only certain column: {watch.Elapsed}");
        }

        public static void ExecuteWithoutInclude(AdsContext context)
        {
            Stopwatch watchStop = new Stopwatch();
            watchStop.Start();
            var ads = context.Ads;

            foreach (var ad in ads)
            {
                Console.WriteLine($"{ad.Title} {ad.StatusId} {ad.Category?.Name} {ad.Town?.Name} {ad.AspNetUser?.Name}");
            }
            watchStop.Stop();
            Console.WriteLine($"Execution without includs: {watchStop.Elapsed}");
        }

        public static void ExecuteWithInclud(AdsContext context)
        {
            Stopwatch watchStop=new Stopwatch();
            watchStop.Start();
            var ads = context.Ads.Include("Category").Include("Town").Include("AspNetUser");
            foreach (var ad in ads)
            {
                Console.WriteLine($"{ad.Title} {ad.StatusId} {ad.Category?.Name} {ad.Town?.Name} {ad.AspNetUser?.Name}");
            }
            watchStop.Stop();
            Console.WriteLine($"Execute with include: {watchStop.Elapsed}");
        }
    }
}
