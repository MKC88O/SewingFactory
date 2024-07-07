using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
namespace SewingFactory
{
    internal class Cutter : Employee
    {
        public readonly Dictionary<Model, List<int>> models = [];
        public Cutter() : this("name", 0) { }

        public Cutter(string? name, int id) : this(name, id, "Закройщик") { }

        public Cutter(string? name, int id, string position)
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
            CutterAssistant cutterAssistant = new CutterAssistant();
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
            string? strings = name + " ID: " + id + " " + position + "\n\n";
            foreach (var current in models)
            {
                strings += "\t      Модель: " + current.Key.GetModelName() + "\n";
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
