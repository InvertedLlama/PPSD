using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using MySql.Data;
using MySql.Data.MySqlClient;


namespace PPSDPart2.Objects
{
    class Database
    {

        string connectionString;
                    
        public Database(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public bool initalise(ref string message)
        {
            //Attempt to open the connection and see if the database is reachable
            using (MySqlConnection sqlConnection = new MySqlConnection(connectionString))
            {
                try
                {
                    sqlConnection.Open();
                }
                catch (MySqlException ex)
                {
                    switch (ex.Number)
                    {
                        case 4060:
                            message = "Invalid Database";
                            break;
                        case 18456:
                            message = "Database Login Failed";
                            break;
                        default:
                            message = "Unknown Database Error";
                            break;
                    }

                    return false;
                }

                return true;
            }
            
            
        }

        public DatabaseTable runQuery(string query)
        {
            using (MySqlConnection sqlConnection = new MySqlConnection(connectionString))
            {
                MySqlCommand cmd = sqlConnection.CreateCommand();
                MySqlDataReader sqlReader;
                cmd.CommandText = query;
                
                //Open the connection
                sqlConnection.Open();

                //Pull the data
                sqlReader = cmd.ExecuteReader();

                return new DatabaseTable(sqlReader);
            }            
        }


        public string ConnectionString
        {
            get { return connectionString; }
            set { connectionString = value; }
        }


    }
}
