using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedvedevPyramid.BusinessLogic
{
    public class Plain
    {
        private int _count;
        private Dictionary<int, PlainIndexPlace> _stairs;

        //--------------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------------------------------------------

        public Plain()
        {
            _stairs = new Dictionary<int, PlainIndexPlace>();

            _count = 0;
        }

        //--------------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------------------------------------------

        public PlainItem Root { get; private set; }

        //--------------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------------------------------------------

        public void Store(params int[] items)
        {
            foreach (var item in items)
            {
                StoreItem(item);
            }
        }


        //--------------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------------------------------------------

        public void StoreItem(int item)
        {
            var row = CalculateRowNumber(++_count);
            var previousRow = row - 1;
            var plainItem = new PlainItem(item);

            if (_stairs.ContainsKey(row) == false)
            {
                _stairs[row] = new PlainIndexPlace(plainItem);
                if (_count == 1)
                {
                    Root = plainItem;
                    return;
                }
                _stairs[previousRow].First().Left = plainItem;
                return;

            }
            _stairs[row].Push(plainItem);
            var index = _stairs[row].Count;

            if (index == row)
            {
                _stairs[previousRow].Last().Right = plainItem;
                return;
            }

            var previousLeft = index - 1;
            _stairs[previousRow][previousLeft].Right = plainItem;
            _stairs[previousRow][index].Left = plainItem;

        }

        //--------------------------------------------------------------------------------------------------------------------------------------


        private int CalculateRowNumber(int itemNumber)
        {
            int sum = 0;
            int x = 0;

            while (sum < itemNumber)
            {
                sum += ++x;
            }

            return x;
        }
    }
}
