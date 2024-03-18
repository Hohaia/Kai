using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Models
{
    public class IngredientType
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public IngredientType(string name, int? id = null)
        {
            Name = name;
            if (id != null)
                Id = (int)id;
        }

        public IngredientType() { }
    }
}
