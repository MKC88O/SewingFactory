using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SewingFactory
{
    internal class Employee
    {
        protected string? name;
        protected int id;

        public Employee() : this("name", 0) { }

        public Employee(string? name, int id)
        {
            SetName(name);
            SetID(id);
        }

        public virtual double CalculateSalary()
        {
            return 0;
        }

        public void SetName(string? name)
        {
            this.name = name;
        }

        public void SetID(int id)
        {
            this.id = id;
        }

        public string? GetName()
        {
            return name;
        }

        public int GetId()
        {
            return id;
        }

        public virtual void Print() { }
    };
}
