using Dapper;
using DataAccessLayer.Contracts;
using DataAccessLayer.CustomQueryResults;
using DomainModel.Models;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using Utility.Logging;

namespace DataAccessLayer.Repositories
{
    public class RecipesRepository : IRecipesRepository
    {
        public event Action<string> OnError;

        private void ErrorOccured(string errorMessage, Exception ex)
        {
            if (OnError != null)
                OnError.Invoke(errorMessage);

            Logger.Log(ex.Message, LogType.ERROR);
        }

        public async Task AddRecipe(Recipe recipe)
        {
            try
            {
                string query = @"INSERT INTO Recipes (Name, Description, Image, RecipeTypeId)
                                VALUES (@Name, @Description, @Image, @RecipeTypeId)";

                using (IDbConnection connection = new SqlConnection(ConnectionHelper.ConnectionString))
                {
                    await connection.ExecuteAsync(query, recipe);
                    Logger.Log(query, LogType.SQL_QUERY);
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

        public async Task<List<RecipeWithType>> GetRecipes(string? sortBy = "", string? sortOrder = "")
        {
            try
            {
                string query = @"SELECT r.Id, r.Name, r.Description, rt.Name AS 'Type'
                                FROM
                                Recipes AS r JOIN RecipeTypes AS rt
                                ON r.RecipeTypeId = rt.Id";
                if (!string.IsNullOrEmpty(sortBy))
                    query += $" ORDER BY {sortBy} {sortOrder}";

                using (IDbConnection connection = new SqlConnection(ConnectionHelper.ConnectionString))
                {
                    return (await connection.QueryAsync<RecipeWithType>(query)).ToList();
                }
            }
            catch (Exception ex)
            {
                string errorMessage = "An error occurred while retieving the recipes!";
                ErrorOccured(errorMessage, ex);
                return new List<RecipeWithType>();
            }
        }
    }
}
