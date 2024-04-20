using DataAccessLayer.CustomQueryResults;
using DomainModel.Models;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;

namespace DataAccessLayer.Contracts
{
    public interface IIngredientsRepository
    {
        public event Action<string> OnError;
        public Task AddIngredient(Ingredient ingredient);
        public Task<List<IngredientWithType>> GetIngredients(string? nameSearch = "", string? sortBy = "", string? sortOrder = "");
        public Task DeleteIngredient(IngredientWithType ingredient);
        public Task EditIngredient(Ingredient ingredient);
    }
}