using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using MySql.Data;
using MySql.Data.MySqlClient;

using PPSDPart2.Interfaces;

//TODO: Possibly use real data types instead of strings. Should be very possible using dynamic list types

namespace PPSDPart2
{
    public class DatabaseTable : IDataSource
    {
        public event EventHandler DataChanged;

        public struct Field
        {
            public string name;
            public Type type;

            public Field(string name, Type type)
            {
                this.name = name;
                this.type = type;
            }
        }
                                        
        List<Field> mFields;
        int intFieldCount;
        int intRowCount;
        string strTableName;

        Dictionary<string, List<string>> mData;

        public DatabaseTable()
        {
        }

        public DatabaseTable(MySqlDataReader dataReader)
        {            
            update(dataReader);
        }
                
        /// <summary>
        /// Call to fill the data dictionary with data from a MySqlDataReader
        /// </summary>
        /// <param name="dataReader">MySQLDataReader to read objects from</param>
        public void update(MySqlDataReader dataReader)
        {
            intFieldCount = dataReader.FieldCount;
            mFields = new List<Field>(dataReader.FieldCount);
            mData = new Dictionary<string, List<string>>();
            for (int i = 0; i < dataReader.FieldCount; i++)
            {
                //Get type of current field in row, create new field
                Type t = dataReader.GetFieldType(i);
                mFields.Add(new Field(dataReader.GetName(i), t));

                //Add an item to the dictionary. Use the column name as a key and create a dynamically typed list to store the values
                mData.Add(dataReader.GetName(i), new List<string>());
            }

            
            //Populate the data lists
            intRowCount = 0;
            //Attempt to read in one row
            while (dataReader.Read())
            {                
                //Get the values from the row and put them into the data dictionary
                for(int i = 0; i < dataReader.FieldCount; i++)
                {
                    //Null values would mess up the table structure
                    //So check for null values and replace them with no characters
                    mData[mFields[i].name].Add(
                        (dataReader.GetValue(i) == null ? "" : dataReader.GetValue(i).ToString())
                        );                    
                }
                intRowCount++;
            }
            
            //Trigger the data update event and notify listening objects
            OnDataChanged(new EventArgs());
        }

        //Event for the data changing.
        protected virtual void OnDataChanged(EventArgs e)
        {
            //Notify the event listeners that the data has changed
            if (DataChanged != null)
            {
                DataChanged(this, e);
            }
        }


        //TODO: Improve formatting
        public override string ToString()
        {
            string strOutput = "";            
            string temp;

            for (int i = 0; i < intRowCount; i++)
            {
                for(int j = 0 ; j < intFieldCount; j++)
                {                    
                    temp = mData[mFields[j].name][i];
                    temp.PadRight(20);
                    strOutput += temp + " ";
                }
                strOutput += "\n";
            }

            return strOutput;
        }

        
        public List<string> getDataColumn(string field)
        {
            return mData["field"];
        }
        
        public List<Field> Fields
        {
            get { return mFields; }
        }

        public int FieldCount
        {
            get { return intFieldCount; }
        }

        public int RowCount
        {
            get { return intRowCount; }
        }

        public Dictionary<string, List<string>> Data
        {
            get { return mData; }
            set { mData = value; }
        }

        //Required by the IDataSource interface
        public IList<string> FieldNames
        {
            get 
            {
                List<string> lstFieldnames = new List<string>();
                foreach(Field f in mFields)
                {
                    lstFieldnames.Add(f.name);
                }
                return lstFieldnames;
            }
        }



        public string FieldsList
        {
            get
            {
                string fl = "";

                foreach(Field f in mFields)
                {
                    fl += f.name + ", ";
                }
                //Trim the trailing comma                
                return fl.Substring(0, fl.Length - 2);
            }
        }

        public string TableName
        {
            get
            {
                return strTableName;
            }
            set
            {
                strTableName = value; ;
            }
        }
    }
}
