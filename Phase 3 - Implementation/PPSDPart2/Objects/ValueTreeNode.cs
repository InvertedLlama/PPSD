using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PPSDPart2
{
    public class ValueTreeNode : TreeNode
    {
        int mValue;        

        public ValueTreeNode(string nodeText, int value) : base(nodeText)
        {
            mValue = value;
        }

        public int Value
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
