using DomainModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Contracts
{
    public interface IFrozenMealTypesRepository
    {
        public event Action<string> OnError;

        public Task<List<FrozenMealType>> GetFrozenMealTypes();
    }
}
