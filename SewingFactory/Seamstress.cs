using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SewingFactory
{
    internal class Seamstress : Employee
    {
        public readonly Dictionary<Model, List<int>> models = [];
        public Seamstress() : this("name", 0, "position") { }

        public Seamstress(string? name, int id) : this(name, id, "Швея") { }

        public Seamstress(string? name, int id, string position)
        {
            SetName(name);
            SetID(id);
            SetPosition(position);
        }

        public void AddModel(Model model, List<int> quantity)
        {
            if (!models.ContainsKey(model))
            {
                models[model] = [];
            }
            models[model].AddRange(quantity);
        }
        public override double CalculateSalary()
        {
            double totalSalary = 0;
            foreach (var current in models)
            {
                foreach (int quantity in current.Value)
                {
                    totalSalary += quantity * current.Key.GetPriceForUnit();
                }
            }
            return totalSalary;
        }

        public override string ToString()
        {
            string? strings = name + " ID: " + id + " " + position + "\n\n";
            foreach (var current in models)
            {
                strings += "\tМодель: " + current.Key.GetModelName() + "\n";
                strings += "Количество  " + "Цена за 1 еденицу  " + "  Итого \n";
                foreach (int quantity in current.Value)
                {
                    strings += quantity + " шт." + "\t\t" + current.Key.GetPriceForUnit() + " грн. " + "\t" + quantity * current.Key.GetPriceForUnit() + " грн. \n";
                }
                strings += "\n";
            }
            strings += "Зарплата: " + CalculateSalary() + " грн.\n";
            strings += "~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~\n";
            return strings;
        }
    };
}
