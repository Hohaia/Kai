using Dapper;
using DataAccessLayer.Contracts;
using DomainModel.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utility.Logging;

namespace DataAccessLayer.Repositories
{
    public class FrozenMealTypesRepository : IFrozenMealTypesRepository
    {
        public event Action<string> OnError;

        private void ErrorOccured(string errorMessage, Exception ex)
        {
            if (OnError != null)
                OnError.Invoke(errorMessage);

            Logger.Log(ex.Message, LogType.ERROR);
        }

        public async Task<List<FrozenMealType>> GetFrozenMealTypes()
        {
            try
            {
                string query = "select * from FrozenMealTypes order by GroupNum asc";

                using (IDbConnection connection = new SqlConnection(ConnectionHelper.ConnectionString))
                {
                    return (await connection.QueryAsync<FrozenMealType>(query)).ToList();
                }
            }
            catch (Exception ex)
            {
                string errorMessage = "An error occurred while retieving the frozen meal types!";
                ErrorOccured(errorMessage, ex);
                return new List<FrozenMealType>();
            }
        }
    }
}
