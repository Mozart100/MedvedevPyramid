using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedvedevPyramid.BusinessLogic
{
    public class PlainItem
    {

        public PlainItem(int item)
        {
            Item = item;

            Right = Left = null;
        }

        //--------------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------------------------------------------

        public int Item { get; }
        public PlainItem Right { get; set; }
        public PlainItem Left { get; set; }
    }


    public static class PlainItemExtensions
    {
        public static bool HasChildren(this PlainItem item)
        {
            if (item == null)
                return false;

            return item.Right != null || item.Left != null;
        }
    }
}
