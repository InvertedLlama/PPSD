using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PPSDPart2
{
    public struct RentalItem
    {
        public int productID, stockID;
        public float cost;
        public string name;

        public RentalItem(int productID, int stockID, float cost, string name)
        {
            this.productID = productID;            
            this.stockID = stockID;
            this.cost = cost;
            this.name = name;
        }
    }

    public class RentalEventArgs : EventArgs
    {
        RentalItem mItem;

        public RentalEventArgs()
            : base()
        {}

        public RentalEventArgs(RentalItem item)
            : base()
        {
            mItem = item;
        }

        public RentalItem Item
        {
            get { return mItem; }
            set { mItem = value; }
        }
    }
}
