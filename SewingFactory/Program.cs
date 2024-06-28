using SewingFactory;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Numerics;
using System.Reflection;
using System.Runtime.Intrinsics;
using System.Xml.Linq;

namespace SewingFactory
{
    internal class Program
    {
         static void Main(string[] args)
        {
            Model m1366 = new ("1366", 80);
            Model m1815 = new ("1815", 60);

            Seamstress Diana = new("Диана", 1);
            Diana.AddModel(m1366,  [24, 12, 10, 12 ]);
            Diana.AddModel(m1815, [64, 32, 25, 16 ]);


            Cutter Max = new("Максим", 2);
            Max.AddModel(m1366, [10, 100, 10, 100, 72 ]);
            Max.AddModel(m1815, [20, 200 ]);

            Console.WriteLine(Max);
            Console.WriteLine(Diana);
        }
    }
}
