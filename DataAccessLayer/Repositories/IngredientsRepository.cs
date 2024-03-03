using Dapper;
using DataAccessLayer.Contracts;
using DomainModel.Models;
using Utility.Logging;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class IngredientsRepository : IIngredientsRepository
    {
        public async Task AddIngredient(Ingredient ingredient)
        {
            try
            {
                string query = @"insert into Ingredients (Name, Quantity, UnitOfMeasurement, KcalPer100g, PricePer100g, Type)
                    values (@Name, @Quantity, @UnitOfMeasurement, @KcalPer100g, @PricePer100g, @Type)";

                using (IDbConnection connection = new SqlConnection(ConnectionHelper.ConnectionString))
                {
                    await connection.ExecuteAsync(query, ingredient);
                }
            }
            catch (SqlException ex)
            {
                string errorMessage = "";
                if (ex.Number == 2627)
                {
                    errorMessage = "That ingredient already exists in the database!"; //TODO: enter the duplicate name into the search field
                    Logger.LogError(DateTime.Now.ToString(), ex.Message);
                }
                else
                {
                    errorMessage = "An error occurred in the database!";
                    Logger.LogError(DateTime.Now.ToString(), ex.Message);
                }
            }
            catch (Exception ex)
            {
                string errorMessage = "An error occurred while adding an ingredient!";
                //TODO: show error message to the user
                Logger.LogError(DateTime.Now.ToString(), ex.Message);
            }
        }

        public async Task<List<Ingredient>> GetIngredients(string? name = "")
        {
            string query = "select * from Ingredients";
            if (!string.IsNullOrEmpty(name))
                query += $" where Name like '{name}%'";

            using (IDbConnection connection = new SqlConnection(ConnectionHelper.ConnectionString))
            {
                return (await connection.QueryAsync<Ingredient>(query)).ToList();
            }
        }

        public async Task DeleteIngredient(Ingredient ingredient)
        {
            string query = @$"delete from Ingredients where Id={ingredient.Id}";

            using (IDbConnection connection = new SqlConnection(ConnectionHelper.ConnectionString))
            {
                await connection.ExecuteAsync(query);
            }
        }

        public async Task EditIngredient(Ingredient ingredient)
        {
            string query = @"update Ingredients
                            set
                            Name = @Name,
                            Quantity = @Quantity,
                            UnitOfMeasurement = @UnitOfMeasurement,
                            KcalPer100g = @KcalPer100g,
                            PricePer100g = @PricePer100g,
                            Type = @Type
                            where Id = @Id";


            using (IDbConnection connection = new SqlConnection(ConnectionHelper.ConnectionString))
            {
                await connection.ExecuteAsync(query, ingredient);
            }
        }
    }
}
