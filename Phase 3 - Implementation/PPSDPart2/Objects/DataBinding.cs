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


        public DataBinding(MySqlDataAdapter adapter)
        {
            MySqlCommandBuilder cmdBldr = new MySqlCommandBuilder(adapter);
            data = new DataTable();

            this.sqlAdapter = adapter;
            sqlAdapter.Fill(data);


            //This will only work for simple tables. May need to rework it if we want to do anything complicated
            sqlAdapter.UpdateCommand = cmdBldr.GetUpdateCommand();
            sqlAdapter.InsertCommand = cmdBldr.GetInsertCommand();
            sqlAdapter.DeleteCommand = cmdBldr.GetDeleteCommand();
        }

        public BindingSource bind()
        {
            BindingSource binding = new BindingSource();
            binding.DataSource = data;

            return binding;
        }


    }
}
