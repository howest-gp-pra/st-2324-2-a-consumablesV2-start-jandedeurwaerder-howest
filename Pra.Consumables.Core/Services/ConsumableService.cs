using Pra.Consumables.Core.Entities;
using Pra.Consumables.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pra.Consumables.Core.Services
{
    public class ConsumableService
    {
		private List<Consumable> consumables;

		public IEnumerable<Consumable> Consumables
		{
			get { return consumables.OrderBy(c => c.Description); }
		}

		public ConsumableService()
		{
			DoSeeding();
		}
		private void DoSeeding()
		{
			consumables = new List<Consumable>()
			{
				new Food("Appel", 0.15m, HealthLabel.A, null ),
				new Food("Ei", 0.3m, HealthLabel.C, "stuk"),
				new Food("Boter",16m, HealthLabel.C, "kg"),
				new Beverage("Pils", 0.1m, true),
				new Beverage("Whiskey", 3m, true),
				new Beverage("Water", 0.08m, false)
			};
		}
		public bool Insert(Consumable consumable)
		{
			try
			{
				consumables.Add(consumable);
				return true;
			}
			catch
			{
				return false;
			}
		}
		public bool Delete(Consumable consumable)
		{
			try 
			{
				consumables.Remove(consumable);
				return true;
			}
			catch 
			{
				return false;
			}
		}
	}
}
