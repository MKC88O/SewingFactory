using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SewingFactory
{
    internal class Admin : Employee
    {
        public readonly List<Employee> employees = [];

        public Admin() : this("name", 0) { }
        public Admin(string? name, int id) : this(name, id, "Администратор") { }
        public Admin(string? name, int id, string position) 
        {
            SetName(name);
            SetID(id);
            SetPosition(position);
        }

        public void AddEmployee(Employee employee)
        {
            employees.Add(employee);
        }

        public override double CalculateSalary()
        {
            double adminSalary = 0;

            foreach (var employee in employees)
            {
                if (employee != null && employee is Seamstress)
                {
                    adminSalary += employee.CalculateSalary();
                }
            }
            return adminSalary * 0.05;
        }

        public override string ToString()
        {
            string? strings = name + " ID: " + id + " " + position + "\n\n";
            strings += "Зарплата: " + CalculateSalary() + " грн.\n";
            strings += "~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~\n";
            return strings;
        }

        public static void PrintSalary(List<Employee>employees)
        {
            foreach (var employee in employees)
            {
                Console.Write("{0, -13}", "ID" + employee.GetId() + "  " + employee.GetName());
                Console.Write("{0, -22}", employee.GetPosition());
                Console.WriteLine("{0, 2}", employee.CalculateSalary() + "грн.");
            }
            Console.WriteLine();    
        }
    }
}
