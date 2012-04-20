using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Windows.Forms;

using MySql.Data;
using MySql.Data.MySqlClient;



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
                               "PASSWORD=" + password + ";"+
                               "POOLING=true;" +
                               "Min Pool Size=0;"+
                               "Max Pool Size=100;";
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
            DataTable table = new DataTable();
            using (MySqlDataAdapter adapter = new MySqlDataAdapter(query, sqlConnection))
            {                
                try
                {
                    adapter.MissingSchemaAction = MissingSchemaAction.AddWithKey;
                    adapter.Fill(table);
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }
            }
            return table;
        }

        public void selectData(string query, ref DataTable table)
        {
            table.Clear();
            using (MySqlDataAdapter adapter = new MySqlDataAdapter(query, sqlConnection))
            {
                try
                {
                    adapter.MissingSchemaAction = MissingSchemaAction.AddWithKey;
                    adapter.Fill(table);
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }
            }
        }

        public bool runCommandQuery(string query)
        {
            try
            {
                using (MySqlCommand cmd = new MySqlCommand(query, sqlConnection))
                {
                    cmd.ExecuteNonQuery();
                }
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
                return false;
            }

            return true;
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
