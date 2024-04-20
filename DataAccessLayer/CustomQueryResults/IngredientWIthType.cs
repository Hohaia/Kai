using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;

namespace DataAccessLayer.CustomQueryResults
{
    public class IngredientWithType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public decimal Quantity { get; set; }
        public string UnitOfMeasurement { get; set; }
        public decimal PricePer100g { get; set; }
        public decimal KcalPer100g { get; set; }
    }
}
