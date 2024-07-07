using SewingFactory;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Numerics;
using System.Reflection;
using System.Runtime.Intrinsics;
using System.Xml.Linq;
using Newtonsoft.Json;

namespace SewingFactory
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Process buttons = new("Пуговицы", 3.5);
            Process loops = new("Петли", 3.5);
            Process snaps = new("Кнопка", 7);
            Process ironing = new("Глажка", 2);
            Process pack = new("Упаковка", 3);
            Process glue = new("Проклейка", 2);

            Model m1366 = new("1366", 80);
            Model m1815 = new("1815", 60);
            Model m1698 = new("1698", 40);
            Model p = new("p", 35);
            Model r = new("r", 50);

            Seamstress Diana = new("Диана", 1);
            Diana.AddModel(m1366, [24, 12, 10, 12, 12, 10]);
            Diana.AddModel(m1815, [64, 32, 25, 16]);
            Diana.AddModel(m1698, [10]);

            Cutter Max = new("Максим", 2);
            Max.AddModel(m1366, [10, 100, 10, 100, 72]);
            Max.AddModel(m1815, [20, 200]);
            Max.AddModel(m1698, [550, 248]);
            Max.AddModel(p, [105]);
            Max.AddModel(r, [174, 227]);

            CutterAssistant Kirill = new("Кирилл", 3, Max);

            Admin admin = new("Вася", 4);
            admin.AddEmployee(Diana);
            admin.AddEmployee(Max);
            admin.AddEmployee(Kirill);
            admin.AddEmployee(admin);

            Packer packer = new("Иван", 5, "Упаковщик");

            packer.AddProcess(m1698, 10, [pack, buttons, ironing, glue, loops]);

            packer.AddProcess(m1366, 10, [pack, snaps]);
            packer.AddProcess(m1815, 137, [pack]);

            admin.AddEmployee(packer);
            Admin.PrintSalary(admin.employees);

            Console.WriteLine(Max);
            Console.WriteLine(Diana);
            Console.WriteLine(Kirill);
            Console.WriteLine(admin);
            Console.WriteLine(packer);

            //string json = JsonConvert.SerializeObject(Max, Formatting.Indented);
            //Console.WriteLine(json);

        }
    }
}
