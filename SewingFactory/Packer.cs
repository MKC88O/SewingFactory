using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SewingFactory
{
    internal class Packer : Employee
    {
        public readonly Dictionary<Model, Dictionary<Process, int>> prcss = [];
        public Packer() : this("name", 0) { }
        public Packer(string? name, int id) : this(name, id, "Упаковщик") { }
        public Packer(string? name, int id, string position) 
        {
            SetName(name);
            SetID(id);
            SetPosition(position);
        }

        public void AddProcess(Model model, int quantity, List<Process> processes)
        {
            if (!prcss.ContainsKey(model))
            {
                prcss[model] = [];
            }
            foreach (var process in processes)
            {
                prcss[model][process] = quantity;
            }
        }

        public override double CalculateSalary()
        {
            double totalSalary = 0;

            foreach (var current in prcss)
            {
                foreach (var currentPrcss in current.Value)
                {
                    totalSalary += currentPrcss.Key.processPrice * currentPrcss.Value;
                }
            }
            return totalSalary;
        }

        public override string ToString()
        {
            string? strings = name + " ID: " + id + " " + position + "\n\n";
            foreach (var current in prcss)
            {
                strings += "\t     Модель: " + current.Key.GetModelName() + "\n";
                strings += "Количество  " + "\tПроцесс  " + "\tИтого \n";
                foreach (var currentPrcss in current.Value)
                {
                    strings += currentPrcss.Value + " шт.\t    "  + currentPrcss.Key.GetProcessName() + " (" + currentPrcss.Key.GetProcessPrice() + "грн.)" +
                        "\t" + currentPrcss.Value * currentPrcss.Key.GetProcessPrice() + " грн. \n";
                }
                strings += "\n";
            }
            strings += "Зарплата: " + CalculateSalary() + " грн.\n";
            strings += "~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~\n";
            return strings;
        }
    }
}
