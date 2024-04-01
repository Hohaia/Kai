using DataAccessLayer.Contracts;
using DomainModel.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utility.Logging;
using Dapper;
using System.Globalization;

namespace DataAccessLayer.Repositories
{
    public class RecipesRepository : IRecipesRepository
    {
        public event Action<string> OnError;

        private void ErrorOccured(string errorMessage, Exception ex)
        {
            if (OnError != null)
                OnError.Invoke(errorMessage);

            Logger.Log(DateTime.Now.ToString(), ex.Message, "ERROR");
        }

        public async Task AddRecipe(Recipe recipe)
        {
            try
            {
                string query = @"insert into Recipes (Name, Description, Image, RecipeTypeId)
                    values (@Name, @Description, @Image, @RecipeTypeId)";

                using (IDbConnection connection = new SqlConnection(ConnectionHelper.ConnectionString))
                {
                    await connection.ExecuteAsync(query, recipe);
                }
            }
            catch (SqlException ex)
            {
                string errorMessage = "";
                if (ex.Number == 2627)
                    errorMessage = "That recipe already exists in the database!";
                else
                    errorMessage = "An error occurred in the database!";
                ErrorOccured(errorMessage, ex);
            }
            catch (Exception ex)
            {
                string errorMessage = "An error occurred while adding an recipe!";
                ErrorOccured(errorMessage, ex);
            }
        }

        public async Task<List<Recipe>> GetRecipes()
        {
            try
            {
                string query = @"SELECT r.Name, r.Description, rt.Name AS 'Type'
                    FROM Recipes AS r JOIN RecipeTypes AS rt
                    ON r.RecipeTypeId=rt.Id";
                //if (!string.IsNullOrEmpty(sortBy))
                //    query += $" order by {sortBy} {sortOrder}";

                using (IDbConnection connection = new SqlConnection(ConnectionHelper.ConnectionString))
                {
                    return (await connection.QueryAsync<Recipe>(query)).ToList();
                }
            }
            catch (Exception ex)
            {
                string errorMessage = "An error occurred while retieving the recipes!";
                ErrorOccured(errorMessage, ex);
                return new List<Recipe>();
            }
        }
    }
}
