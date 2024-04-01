using Dapper;
using DataAccessLayer.Contracts;
using DomainModel.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utility.Logging;

namespace DataAccessLayer.Repositories
{
    public class IngredientsRepository : IIngredientsRepository
    {
        public event Action<string> OnError;

        private void ErrorOccured(string errorMessage, Exception ex)
        {
            if (OnError != null)
                OnError.Invoke(errorMessage);

            Logger.Log(ex.Message, LogType.ERROR);
        }

        public async Task AddIngredient(Ingredient ingredient)
        {
            try
            {
                string query = @"insert into Ingredients (Name, Quantity, UnitOfMeasurement, KcalPer100g, PricePer100g, IngredientTypeId)
                    values (@Name, @Quantity, @UnitOfMeasurement, @KcalPer100g, @PricePer100g, @IngredientTypeId)";

                using (IDbConnection connection = new SqlConnection(ConnectionHelper.ConnectionString))
                {
                    await connection.ExecuteAsync(query, ingredient);
                    Logger.Log(query, LogType.SQL_QUERY);
                }
            }
            catch (SqlException ex)
            {
                string errorMessage = "";
                if (ex.Number == 2627)
                    errorMessage = "That ingredient already exists in the database!";
                else
                    errorMessage = "An error occurred in the database!";
                ErrorOccured(errorMessage, ex);
            }
            catch (Exception ex)
            {
                string errorMessage = "An error occurred while adding an ingredient!";
                ErrorOccured(errorMessage, ex);
            }
        }

        public async Task<List<Ingredient>> GetIngredients(string? nameSearch = "", string? sortBy = "", string? sortOrder = "")
        {
            try
            {
                string query = "select * from Ingredients";
                if (!string.IsNullOrEmpty(nameSearch))
                    query += $" where Name like '{nameSearch}%'";
                if (!string.IsNullOrEmpty(sortBy))
                    query += $" order by {sortBy} {sortOrder}";

                using (IDbConnection connection = new SqlConnection(ConnectionHelper.ConnectionString))
                {
                    return (await connection.QueryAsync<Ingredient>(query)).ToList();
                }
            }
            catch (Exception ex)
            {
                string errorMessage = "An error occurred while retieving the ingredients!";
                ErrorOccured(errorMessage, ex);
                return new List<Ingredient>();
            }
        }

        public async Task DeleteIngredient(Ingredient ingredient)
        {
            try
            {
                string query = @$"delete from Ingredients where Id={ingredient.Id}";

                using (IDbConnection connection = new SqlConnection(ConnectionHelper.ConnectionString))
                {
                    await connection.ExecuteAsync(query);
                }
            }
            catch (Exception ex)
            {
                string errorMessage = "An error occurred while deleting an ingredient!";
                ErrorOccured(errorMessage, ex);
            }
        }

        public async Task EditIngredient(Ingredient ingredient)
        {
            try
            {
                string query = @"update Ingredients
                            set
                            Name = @Name,
                            Quantity = @Quantity,
                            UnitOfMeasurement = @UnitOfMeasurement,
                            KcalPer100g = @KcalPer100g,
                            PricePer100g = @PricePer100g,
                            IngredientTypeId = @IngredientTypeId
                            where Id = @Id";
                using (IDbConnection connection = new SqlConnection(ConnectionHelper.ConnectionString))
                {
                    await connection.ExecuteAsync(query, ingredient);
                    Logger.Log(query, LogType.SQL_QUERY);
                }
            }
            catch (Exception ex)
            {
                string errorMessage = "An error occurred while editing an ingredient!";
                ErrorOccured(errorMessage, ex);
            }
        }
    }
}
