﻿using Dapper;
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
        public void AddIngredient(Ingredient ingredient)
        {
            string query = @"insert into Ingredients (Name, Quantity, UnitOfMeasurement, KcalPer100g, PricePer100g, Type)
            values (@Name, @Quantity, @UnitOfMeasurement, @KcalPer100g, @PricePer100g, @Type)";

            using (IDbConnection connection = new SqlConnection(ConnectionHelper.ConnectionString))
            {
                connection.Execute(query, ingredient);
            }
        }

        public async Task<List<Ingredient>> GetIngredients(string? name = "")
        {
            string query = "select * from Ingredients";
            if (!string.IsNullOrEmpty(name))
                query += $" where Name like '%{name}%'";

            string delay = " WAITFOR DELAY '00:00:02'"; // TODO: Remove this line after testing
            query += delay;                             // TODO: Remove this line after testing

            using (IDbConnection connection = new SqlConnection(ConnectionHelper.ConnectionString))
            {
                return (await connection.QueryAsync<Ingredient>(query)).ToList();
            }
        }
    }
}
