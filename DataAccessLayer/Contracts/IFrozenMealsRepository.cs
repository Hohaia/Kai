using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Contracts
{
    public interface IFrozenMealsRepository
    {
        public event Action<string> OnError;
    }
}
