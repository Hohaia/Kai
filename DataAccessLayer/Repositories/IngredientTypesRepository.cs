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

namespace DataAccessLayer.Repositories
{
    public class IngredientTypesRepository : IIngredientTypesRepository
    {
        public event Action<string> OnError;

        private void ErrorOccured(string errorMessage, Exception ex)
        {
            if (OnError != null)
                OnError.Invoke(errorMessage);

            Logger.Log(ex.Message, "ERROR");
        }

        public async Task AddIngredientType(IngredientType ingredientType)
        {
            try
            {
                string query = @"insert into IngredientTypes (Name) values (@Name)";

                using (IDbConnection connection = new SqlConnection(ConnectionHelper.ConnectionString))
                {
                    await connection.ExecuteAsync(query, ingredientType);
                    Logger.Log(query, "SQL Query");
                }
            }
            catch (SqlException ex)
            {
                string errorMessage = "";
                if (ex.Number == 2627)
                    errorMessage = "That ingredient type already exists in the database!";
                else
                    errorMessage = "An error occurred in the database!";
                ErrorOccured(errorMessage, ex);
            }
            catch (Exception ex)
            {
                string errorMessage = "An error occurred while adding an ingredient type!";
                ErrorOccured(errorMessage, ex);
            }
        }

        public async Task<List<IngredientType>> GetIngredientTypes()
        {
            try
            {
                string query = "select * from IngredientTypes order by Name asc";

                using (IDbConnection connection = new SqlConnection(ConnectionHelper.ConnectionString))
                {
                    return (await connection.QueryAsync<IngredientType>(query)).ToList();
                }
            }
            catch (Exception ex)
            {
                string errorMessage = "An error occurred while retieving the ingredient types!";
                ErrorOccured(errorMessage, ex);
                return new List<IngredientType>();
            }
        }
    }
}
