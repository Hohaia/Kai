using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Models
{
    public class FrozenMeal
    {
        public int Id { get; set; }
        public int FrozenMealTypeId { get; set; }
        public string Name { get; set; }
        public int Servings { get; set; }
        public string ServingSuggestion { get; set; }
        public string DateFrozen { get; set; }

        public FrozenMeal(int frozenMealTypeId, string name, int servings, string servingSuggestion, string dateFrozen, int? id = null)
        {
            FrozenMealTypeId = frozenMealTypeId;
            Name = name;
            Servings = servings;
            ServingSuggestion = servingSuggestion;
            DateFrozen = dateFrozen;
            if (id != null)
                Id = (int)id;
        }

        public FrozenMeal() { }
    }
}
