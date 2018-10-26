using DataAccessUtility;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace CRUDExample.Services
{
    public class ADOService
    {

        public void ExecuteQuery()
        {
            // add a customer
            Dictionary<string, SqlParameter> cmdParameters = new Dictionary<string, SqlParameter>();
            cmdParameters["name"] = new SqlParameter("name", "Smith");
            cmdParameters["state"] = new SqlParameter("state", "MD");
            SqlDatabaseUtility.ExecuteCommand("mssqltips", "dbo.AddCustomer", cmdParameters);

            // query the customer table
            Dictionary<string, SqlParameter> queryParameters = new Dictionary<string, SqlParameter>();
            SqlDataReader reader = SqlDatabaseUtility.ExecuteQuery(
                "mssqltips", "dbo.GetCustomerList", queryParameters);
            while (reader.Read() == true)
            {
                Console.WriteLine(string.Format("{0}\t{1}\t{2}",
                    reader[0].ToString(),
                    reader[1].ToString(),
                    reader[2].ToString()));
            }
        }
}
}