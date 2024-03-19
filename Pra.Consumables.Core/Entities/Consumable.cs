using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pra.Consumables.Core.Entities
{
    public abstract class Consumable
    {
        private string description;
        private decimal pricePerUnit;

        public Guid Id { get; }

		public string Description
		{
			get { return description; }
			set 
			{
				if (value is null) value = "onbekend";
				value = value.Trim();
				if (value.Length == 0) value = "onbekend";
				description = value; 
			}
		}
        public string Unit { get; set; }

		public decimal PricePerUnit
		{
			get { return pricePerUnit; }
			set
			{
				if (value < 0m) value = 0m;
				pricePerUnit = value; 
			}
		}
		public Consumable(string description, decimal pricePerUnit,
			string unit = null, Guid? id = null)
		{
			Description = description;
			PricePerUnit = pricePerUnit;
			Unit = unit;
			if(id is null)
			{
				Id = Guid.NewGuid();
			}
			else
			{
				Id = (Guid)id;
			}
		}

        public override string ToString()
        {
			return $"{Description} : €{PricePerUnit}/{Unit}";
		}
    }
}
