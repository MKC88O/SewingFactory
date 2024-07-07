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
        protected string? position;

        public Employee() : this("name", 0, "position") { }

        public Employee(string? name, int id) : this(name, id, "position") { }

        public Employee(string? name, int id, string position)
        {
            SetName(name);
            SetID(id);
            SetPosition(position);
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

        public void SetPosition(string? position)
        {
            this.position = position;
        }

        public string? GetName()
        {
            return name;
        }

        public int GetId()
        {
            return id;
        }

        public string? GetPosition()
        {
            return position;
        }

        //public virtual void Print() { }
    };
}
