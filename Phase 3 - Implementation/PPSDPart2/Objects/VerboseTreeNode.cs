using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PPSDPart2
{
    public class VerboseTreeNode : TreeNode
    {
        string mMessage;

        public VerboseTreeNode(string nodeText) : base(nodeText)
        {
            mMessage = "";
        }

        public VerboseTreeNode(string nodeText, string value) : base(nodeText)
        {
            mMessage = value;
        }

        public string Message
        {
            get { return mMessage; }
            set { mMessage = value; }
        }
    }
}
