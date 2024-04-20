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
                string query = @"INSERT INTO Ingredients (Name, Quantity, UnitOfMeasurement, KcalPer100g, PricePer100g, IngredientTypeId)
                                VALUES (@Name, @Quantity, @UnitOfMeasurement, @KcalPer100g, @PricePer100g, @IngredientTypeId)";

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

        public async Task<List<IngredientWithType>> GetIngredients(string? nameSearch = "", string? sortBy = "", string? sortOrder = "")
        {
            try
            {
                string query = @"SELECT i.Id, i.Name, it.Name AS 'Type', i.Quantity, i.UnitOfMeasurement, i.KcalPer100g, i.PricePer100g
                                FROM
                                Ingredients AS i JOIN IngredientTypes AS it
                                ON i.IngredientTypeId = it.Id";
                if (!string.IsNullOrEmpty(nameSearch))
                    query += $" WHERE i.Name LIKE '{nameSearch}%'";
                if (!string.IsNullOrEmpty(sortBy))
                    query += $" ORDER BY {sortBy} {sortOrder}";

                using (IDbConnection connection = new SqlConnection(ConnectionHelper.ConnectionString))
                {
                    return (await connection.QueryAsync<IngredientWithType>(query)).ToList();
                }
            }
            catch (Exception ex)
            {
                string errorMessage = "An error occurred while retieving the ingredients!";
                ErrorOccured(errorMessage, ex);
                return new List<IngredientWithType>();
            }
        }

        public async Task DeleteIngredient(IngredientWithType ingredient)
        {
            try
            {
                string query = @$"DELETE FROM Ingredients WHERE Id={ingredient.Id}";

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
                string query = @"UPDATE Ingredients
                                SET
                                Name = @Name,
                                Quantity = @Quantity,
                                UnitOfMeasurement = @UnitOfMeasurement,
                                KcalPer100g = @KcalPer100g,
                                PricePer100g = @PricePer100g,
                                IngredientTypeId = @IngredientTypeId
                                WHERE Id = @Id";
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
