﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
namespace SewingFactory
{
    internal class Model
    {

        protected string? modelName;
        protected double priceForUnit = 0;

        public Model() : this("modelName", 0) { }

        public Model(string? modelName, double priceForUnit)
        {
            SetModelName(modelName);
            SetPriceForUnit(priceForUnit);
        }

        public void SetModelName(string? modelName)
        {
            this.modelName = modelName;
        }

        public void SetPriceForUnit(double priceForUnit)
        {
            this.priceForUnit = priceForUnit;
        }

        public string? GetModelName()
        {
            return modelName;
        }

        public double GetPriceForUnit()
        {
            return priceForUnit;
        }
    };
}
