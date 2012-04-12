using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using MySql.Data;
using MySql.Data.MySqlClient;
using System.Data;



namespace PPSDPart2
{
    public class Database : IDisposable
    {
        string connectionString;
        MySqlConnection sqlConnection;

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
            MySqlConnection temp = new MySqlConnection(connectionString);
            
            try
            {
               temp.Open();
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
                temp.Close();
                return false;
            }

            sqlConnection = temp; 
            return true;                  
        }


        public DataTable selectData(string query)
        {
            MySqlDataAdapter adapter = new MySqlDataAdapter(query, sqlConnection);
            DataTable table = new DataTable();
            adapter.Fill(table);

            adapter.Dispose();            
            return table;
        }

        public DataBinding selectDataBinding(string query)
        {
            MySqlDataAdapter adapter = new MySqlDataAdapter(query, sqlConnection);
            DataBinding binding = new DataBinding(adapter);
            return binding;
        }

        /// <summary>
        /// Call to cleanup any services and references the database object is using
        /// also destroys any DataBindings that rely on this
        /// </summary>
        public void Dispose()
        {
            //Close the connection
            sqlConnection.Close();
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
