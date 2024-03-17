using DomainModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Contracts
{
    public interface IIngredientTypesRepository
    {
        public event Action<string> OnError;
        public Task AddIngredientType(IngredientType ingredientType);
        public Task<List<IngredientType>> GetIngredientTypes();
    }
}
