using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PPSDPart2
{
    class ListItem
    {
        private string mText;
        private int mValue;

        public ListItem(string text, int value)
        {
            mText = text;
            mValue = value;
        }

        public override string ToString()
        {
            return mText;    
        }

        public int Value
        {
            get { return mValue; }
            set { mValue = value; }
        }
    }
}
