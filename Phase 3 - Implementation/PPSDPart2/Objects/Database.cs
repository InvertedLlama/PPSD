﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using MySql.Data;
using MySql.Data.MySqlClient;


namespace PPSDPart2.Objects
{
    //TODO: Set reasonable command timeouts
    //TODO: Improve string formatting
    //TODO: Improve error handling
    //POSS TODO: Make data type sensetive
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
        
        
        public DatabaseTable runDataSelectQuery(string query)
        {
            using (MySqlConnection sqlConnection = new MySqlConnection(connectionString))
            {
                MySqlCommand cmd = sqlConnection.CreateCommand();
                MySqlDataReader sqlReader = null;
                cmd.CommandText = query;
                
                //Open the connection
                sqlConnection.Open();

                DatabaseTable dt = null;

                //Pull the data
                try
                {
                    sqlReader = cmd.ExecuteReader();
                    dt = new DatabaseTable(sqlReader);
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

                return dt;
            }            
        }

        //Dont run select queries through this function.
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

        public string ConnectionString
        {
            get { return connectionString; }
            set { connectionString = value; }
        }


    }
}
