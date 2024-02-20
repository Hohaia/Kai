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

namespace DataAccessLayer.Repositories
{
    public class IngredientsRepository : IIngredientsRepository
    {
        public async Task AddIngredient(Ingredient ingredient)
        {
            string query = @"insert into Ingredients (Name, Quantity, UnitOfMeasurement, KcalPer100g, PricePer100g, Type)
            values (@Name, @Quantity, @UnitOfMeasurement, @KcalPer100g, @PricePer100g, @Type)";

            using (IDbConnection connection = new SqlConnection(ConnectionHelper.ConnectionString))
            {
                await connection.ExecuteAsync(query, ingredient);
            }
        }

        public async Task<List<Ingredient>> GetIngredients(string? name = "")
        {
            string query = "select * from Ingredients";
            if (!string.IsNullOrEmpty(name))
                query += $" where Name like '%{name}%'";

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
