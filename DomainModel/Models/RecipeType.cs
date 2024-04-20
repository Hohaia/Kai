using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;

namespace DomainModel.Models
{
    public class RecipeType
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public RecipeType(string name, int? id = null)
        {
            Name = name;
        }

        public RecipeType() { }
    }
}
