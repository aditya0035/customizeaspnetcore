using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Primitives;
using System.Collections.Generic;
using System.Data.SqlClient;
using System;

namespace ConfigurationSample
{
    public class DatabaseConfigurationProvider : ConfigurationProvider
    {
        private string _connectionString;
      
        public DatabaseConfigurationProvider(string connectionString)
        {
            _connectionString = connectionString;
        }
        
        public override void Load()
        {
            using (var db=new SqlConnection(_connectionString))
            using(var command=new SqlCommand("Select ConfigurationKey,ConfigurationValue From [dbo].[SwiftStatusConfiguration] Where IsDlt=0",db))
            {
                command.CommandType = System.Data.CommandType.Text;
                db.Open();
                var reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Data.TryAdd(Convert.ToString(reader["ConfigurationKey"]), Convert.ToString(reader["ConfigurationValue"]));
                    }
                }
            }
        }
    }
}