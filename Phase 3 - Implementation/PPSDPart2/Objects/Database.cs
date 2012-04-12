using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using MySql.Data;
using MySql.Data.MySqlClient;
using System.Data;



namespace PPSDPart2
{
    //TODO: Set reasonable command timeouts
    //TODO: Improve string formatting
    //TODO: Improve error handling
    //POSS TODO: Make data type sensetive
    public class Database
    {
        string connectionString;

        /// <summary>
        /// Creates an instance of a Database object
        /// </summary>
        public Database(string host, string database, string username, string password)
        {
            connectionString = "SERVER=" + host + ";" +
                               "DATABASE=" + database + ";" +
                               "UID=" + username + ";" +
                               "PASSWORD=" + password + ";";
        }

        /// <summary>
        /// Initialises the database with the Database object's credentials
        /// </summary>
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

                sqlConnection.Close();
                return true;
            }        
        }
        
        /// <summary>
        /// Executes non-DDL statements (SELECT etc) and returns matching rows from the Database
        /// </summary>
        /// <param name="query">Query to execute against the database</param>
        /// <returns>DatabaseTable containing matching rows</returns>
        public DatabaseTable runDataSelectQuery(string query)
        {
            using (MySqlConnection sqlConnection = new MySqlConnection(connectionString))
            {
                MySqlCommand cmd = sqlConnection.CreateCommand();
                MySqlDataReader sqlReader = null;
                DatabaseTable databaseTable;

                cmd.CommandText = query;
                sqlConnection.Open();

                //Pull the data
                try
                {
                    sqlReader = cmd.ExecuteReader();
                    databaseTable = new DatabaseTable(sqlReader);
                }
                
                //If there's an error throw it to the calling function so it can be handled accordingly
                catch (MySqlException e)
                {
                    throw e;
                }
                //Make sure to close connections and readers regardless of outcome
                finally
                {                    
                    if(sqlReader != null)
                        sqlReader.Close();

                    cmd.Connection.Close();
                }              

                return databaseTable;
            }            
        }

        /// <summary>
        /// Executes non-DDL statements (SELECT etc) and returns matching rows from the Database
        /// but puts them into an existing DatabaseTable object
        /// </summary>
        /// <param name="query">Query to execute against the database</param>
        /// <param name="table">Table to put the data into</param>
        /// <returns>DatabaseTable containing matching rows</returns>
        public void runDataSelectQuery(string query, ref DatabaseTable table)
        {
            using (MySqlConnection sqlConnection = new MySqlConnection(connectionString))
            {
                MySqlCommand cmd = sqlConnection.CreateCommand();
                MySqlDataReader sqlReader = null;

                cmd.CommandText = query;
                sqlConnection.Open();

                //Pull the data
                try
                {
                    sqlReader = cmd.ExecuteReader();
                    table.update(sqlReader);
                }

                //If there's an error throw it to the calling function so it can be handled accordingly
                catch (MySqlException e)
                {
                    throw e;
                }
                //Make sure to close connections and readers regardless of outcome
                finally
                {
                    if (sqlReader != null)
                        sqlReader.Close();

                    cmd.Connection.Close();
                }

            }
        }

        /// <summary>
        /// Executes DDL statements (CREATE, ALTER, DROP etc) on the Database.
        /// </summary>
        /// <param name="query">Query to execute against the database table</param>
        /// <returns>Boolean success of the query</returns>
        public bool runCommandQuery(string query)
        {
            using (MySqlConnection sqlConnection = new MySqlConnection(connectionString))
            {
                MySqlCommand cmd = sqlConnection.CreateCommand();
                cmd.CommandText = query;

                try
                {
                    sqlConnection.Open();
                    cmd.ExecuteNonQuery();                    
                }
                catch (MySqlException e)
                {
                    throw e;
                }
                finally
                {
                    cmd.Connection.Close();
                    sqlConnection.Close();
                }
                                
            }
            return true;
        }

        /// <summary>
        /// Connection String containing Hostname, Database Name, User and Pass.
        /// </summary>
        public string ConnectionString
        {
            get { return connectionString; }
            set { connectionString = value; }
        }
    }
}
