using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PPSDPart2
{
    public class ValueTreeNode : TreeNode
    {
        object mValue;        

        public ValueTreeNode(string nodeText, object value) : base(nodeText)
        {
            mValue = value;
        }

        public object Value
        {
            get { return mValue; }
            set { mValue = value; }
        }

        public Type Type
        {
            get { return mValue.GetType(); }
        }
    }
}
