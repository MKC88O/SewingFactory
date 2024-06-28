using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SewingFactory
{
    internal class Cutter : Employee
    {
        readonly Dictionary<Model, List<int>> models = [];
        public Cutter() : this("name", 0) { }

        public Cutter(string? name, int id)
        {
            SetName(name);
            SetID(id);
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
                    double priceForUnit = (quantity < 100) ? current.Key.GetPriceForUnit() * 0.3 : current.Key.GetPriceForUnit() * 0.25;
                    totalSalary += quantity * priceForUnit;
                }
            }
            return totalSalary;
        }

        public override string ToString()
        {
            string? strings = "Имя: " + name + " ID: " + id + "\n\n";
            foreach (var current in models)
            {
                strings += "\tМодель: " + current.Key.GetModelName() + "\n";
                strings += "Количество  " + "Цена за 1 еденицу  " + "  Итого \n";
                foreach (int quantity in current.Value)
                {
                    double priceForUnit = (quantity < 100) ? current.Key.GetPriceForUnit() * 0.3 : current.Key.GetPriceForUnit() * 0.25;
                    strings += quantity + " шт." + "\t\t" + priceForUnit + " грн. " + "\t" + quantity * priceForUnit + " грн. \n";
                }
                strings += "\n";
            }
            strings += "Зарплата: " + CalculateSalary() + " грн.\n";
            strings += "~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~\n";
            return strings;
        }
    };
}
