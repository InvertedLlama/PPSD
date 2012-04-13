using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

using System.Windows.Forms;

using MySql;
using MySql.Data;
using MySql.Data.Common;
using MySql.Data.MySqlClient;

namespace PPSDPart2
{
    public class DataBinding
    {
        private MySqlDataAdapter sqlAdapter;
        private DataTable data;
        private string selectCommand;
                
        /// <summary>
        /// Create a DataBinding object based around the data in the adapter passed
        /// </summary>
        /// <param name="adapter">MySQLDataAdapter containing Data for this binding</param>
        public DataBinding(MySqlDataAdapter adapter)
        {
            MySqlCommandBuilder cmdBldr = new MySqlCommandBuilder(adapter);
            data = new DataTable();
            this.sqlAdapter = adapter;
            selectCommand = sqlAdapter.SelectCommand.CommandText;
            sqlAdapter.MissingSchemaAction = MissingSchemaAction.Add;
            sqlAdapter.AcceptChangesDuringUpdate = true;            
            sqlAdapter.Fill(data);
            
            //This will only work for simple tables. May need to rework it if we want to do anything complicated            
            sqlAdapter.UpdateCommand = cmdBldr.GetUpdateCommand();            
            sqlAdapter.InsertCommand = cmdBldr.GetInsertCommand();
            sqlAdapter.InsertCommand.UpdatedRowSource = UpdateRowSource.FirstReturnedRecord;
            sqlAdapter.DeleteCommand = cmdBldr.GetDeleteCommand();
        }

        public void update()
        {            
            sqlAdapter.Update(data);
            data.Clear();
            sqlAdapter.Fill(data);
        }

        public DataTable Data
        {
            get { return data; }
        }

        public MySqlDataAdapter Adapater
        {
            get { return sqlAdapter; }
        }

    }
}
