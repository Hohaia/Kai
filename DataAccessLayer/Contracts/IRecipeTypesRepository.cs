using DomainModel.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;

namespace DataAccessLayer.Contracts
{
    public interface IRecipeTypesRepository
    {
        public event Action<string> OnError;
        public Task AddRecipeType(RecipeType recipeType);
        public Task<List<RecipeType>> GetRecipeTypes();
    }
}
