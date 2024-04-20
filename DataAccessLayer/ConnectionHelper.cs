using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;

namespace DataAccessLayer
{
    static internal class ConnectionHelper
    {
        internal static string ConnectionString
        {
            get
            {
                return ConfigurationManager.ConnectionStrings["CookBookConnectionString"].ConnectionString;
            }
        }
    }
}
