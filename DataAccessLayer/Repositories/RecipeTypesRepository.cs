using Dapper;
using DataAccessLayer.Contracts;
using DomainModel.Models;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using Utility.Logging;

namespace DataAccessLayer.Repositories
{
    public class RecipeTypesRepository : IRecipeTypesRepository
    {
        public event Action<string> OnError;

        private void ErrorOccured(string errorMessage, Exception ex)
        {
            if (OnError != null)
                OnError.Invoke(errorMessage);

            Logger.Log(ex.Message, LogType.ERROR);
        }

        public async Task AddRecipeType(RecipeType recipeType)
        {
            try
            {
                string query = @"INSERT INTO RecipeTypes (Name)
                                VALUES (@Name)";

                using (IDbConnection connection = new SqlConnection(ConnectionHelper.ConnectionString))
                {
                    await connection.ExecuteAsync(query, recipeType);
                    Logger.Log(query, LogType.SQL_QUERY);
                }
            }
            catch (SqlException ex)
            {
                string errorMessage = "";
                if (ex.Number == 2627)
                    errorMessage = "That recipe type already exists in the database!";
                else
                    errorMessage = "An error occurred in the database!";
                ErrorOccured(errorMessage, ex);
            }
            catch (Exception ex)
            {
                string errorMessage = "An error occurred while adding a recipe type!";
                ErrorOccured(errorMessage, ex);
            }
        }

        public async Task<List<RecipeType>> GetRecipeTypes()
        {
            try
            {
                string query = "select * from RecipeTypes order by Name asc";

                using (IDbConnection connection = new SqlConnection(ConnectionHelper.ConnectionString))
                {
                    return (await connection.QueryAsync<RecipeType>(query)).ToList();
                }
            }
            catch (Exception ex)
            {
                string errorMessage = "An error occurred while retieving the recipe types!";
                ErrorOccured(errorMessage, ex);
                return new List<RecipeType>();
            }
        }
    }
}
