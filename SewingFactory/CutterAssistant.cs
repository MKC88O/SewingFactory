using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SewingFactory
{
    internal class CutterAssistant : Employee
    {
        private  Cutter? cutter;
        public CutterAssistant() : this("name", 0, null) { }

        public CutterAssistant(string? name, int id, Cutter? cutter) : this(name, id, cutter, "Помощник закройщика") { }

        public CutterAssistant(string? name, int id, Cutter? cutter, string position)
        {
            SetName(name);
            SetID(id);
            SetCutter(cutter);
            SetPosition(position);
        }

        public void SetCutter(Cutter? cutter)
        {
            if(cutter != null)
            {
                this.cutter = cutter;
            }
        }

        public Cutter? GetCutter()
        {
            return cutter;
        }
        public override double CalculateSalary()
        {
            if (cutter != null)
            {
                return cutter.CalculateSalary() * 0.3;
            }
            return 0;
        }

        public override string ToString()
        {
            string? strings = name + " ID: " + id + " " + position + "\n\n";
            strings += "Зарплата: " + CalculateSalary() + " грн.\n";
            strings += "~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~\n";
            return strings;
        }
    }
}
