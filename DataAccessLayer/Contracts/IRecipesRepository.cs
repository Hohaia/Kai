using DataAccessLayer.CustomQueryResults;
using DomainModel.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;

namespace DataAccessLayer.Contracts
{
    public interface IRecipesRepository
    {
        public event Action<string> OnError;
        public Task AddRecipe(Recipe recipe);
        public Task<List<RecipeWithType>> GetRecipes(string? sortBy = "", string? sortOrder = "");
    }
}
