using Pra.Consumables.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pra.Consumables.Core.Entities
{
    public class Food : Consumable
    {
        public HealthLabel HealthLabel { get; set; }
        public Food(string description, decimal pricePerUnit, HealthLabel healthLabel,
            string unit = null, Guid? id = null) : base(description, pricePerUnit, unit, id)
        {
            HealthLabel = healthLabel;
        }
        public override string ToString()
        {
            return $"{base.ToString()} \n\tHealthlabel : {HealthLabel}";
        }
    }
}
