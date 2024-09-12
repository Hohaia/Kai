using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Models
{
    public class FrozenMealType
    {
        public int Id { get; set; }
        public int GroupNum { get; set; }
        public string Name { get; set; }

        public FrozenMealType(int groupNum, string name, int? id = null)
        {
            GroupNum = groupNum;
            Name = name;
        }

        public FrozenMealType() { }
    }
}
