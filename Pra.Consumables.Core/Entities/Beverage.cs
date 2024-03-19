using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pra.Consumables.Core.Entities
{
    public class Beverage : Consumable
    {
        public bool IsAlcoholic { get; set; }
        public Beverage(string description, decimal pricePerUnit, bool isAlcoholic,
            Guid? id = null) : base(description, pricePerUnit, "cl.", id)
        {
            IsAlcoholic = isAlcoholic;
        }
        public override string ToString()
        {
            return $"* {base.ToString()}";
        }
    }
}
