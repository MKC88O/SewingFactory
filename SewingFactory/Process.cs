using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SewingFactory
{
    internal class Process
    {
        public string? processName;
        public double processPrice;

        public Process() : this("processName", 0) { }

        public Process(string processName, double processPrice)
        {
            SetProcessName(processName);
            SetProcessPrice(processPrice);
        }

        public void SetProcessName(string processName)
        { 
            this.processName = processName;
        }

        public void SetProcessPrice(double processPrice)
        {
            this.processPrice = processPrice;
        }

        public string? GetProcessName()
        { 
            return processName;
        }
        public double GetProcessPrice()
        {
            return processPrice;
        }
        
    }
}
