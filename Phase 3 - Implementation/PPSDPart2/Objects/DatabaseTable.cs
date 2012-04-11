﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using MySql.Data;
using MySql.Data.MySqlClient;

using PPSDPart2.Interfaces;

//TODO: Possibly use real data types instead of strings. Should be very possible using dynamic list types

namespace PPSDPart2.Objects
{
    public class DatabaseTable : IDataSource
    {
        public event EventHandler DataChanged;
        public event EventHandler Destroyed;

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

        Dictionary<string, List<string>> mData;


        public DatabaseTable(MySqlDataReader dataReader)
        {
            intFieldCount = dataReader.FieldCount;
            mFields = new List<Field>(dataReader.FieldCount);
            mData = new Dictionary<string, List<string>>();
          
            for(int i = 0; i < dataReader.FieldCount; i++)
            {
                //Get type of current field in row, create new field
                Type t = dataReader.GetFieldType(i);
                mFields.Add(new Field(dataReader.GetName(i), t));
                
                //Add an item to the dictionary. Use the column name as a key and create a dynamically typed list to store the values
                mData.Add(dataReader.GetName(i), new List<string>());
            }            

            //Populate the data lists

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

        //Event for this data source being destroyed.
        protected virtual void OnDestoryed(EventArgs e)
        {
            //Notify any listeners that this source is being destoryed
            if (Destroyed != null)
            {
                Destroyed(this, e);
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
    }
}
