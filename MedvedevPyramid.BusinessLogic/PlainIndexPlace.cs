using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedvedevPyramid.BusinessLogic
{
    public class PlainIndexPlace : IDictionary<int, PlainItem>
    {
        private Dictionary<int, PlainItem> _store;
        private PlainItem _lastItem;
        private int _maxKey;

        //--------------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------------------------------------------

        public PlainIndexPlace(PlainItem plainItem)
        {

            _store = new Dictionary<int, PlainItem>();
            _store[1] = plainItem;
            _lastItem = plainItem;
            _maxKey = 1;
        }

        public PlainItem First()
        {
            return _store[1];
        }

        public PlainItem Last()
        {

            return _lastItem;
        }

        public void Push(PlainItem value)
        {
            _store.Add(++_maxKey, value);
            _lastItem = value;
        }

        //--------------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------------------------------------------

        public PlainItem this[int key]
        {
            get
            {
                return _store[key];
            }

            set
            {
                _store[key] = value;
            }
        }

        public int Count
        {
            get
            {
                return _store.Count;
            }
        }

        public bool IsReadOnly
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public ICollection<int> Keys
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public ICollection<PlainItem> Values
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public void Add(KeyValuePair<int, PlainItem> item)
        {
            throw new NotImplementedException();
        }

        public void Add(int key, PlainItem value)
        {
            _maxKey = key;
            _store.Add(key, value);
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public bool Contains(KeyValuePair<int, PlainItem> item)
        {
            throw new NotImplementedException();
        }

        public bool ContainsKey(int key)
        {
            throw new NotImplementedException();
        }

        public void CopyTo(KeyValuePair<int, PlainItem>[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }


        //--------------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------------------------------------------





        public IEnumerator<KeyValuePair<int, PlainItem>> GetEnumerator()
        {
            throw new NotImplementedException();
        }



        public bool Remove(KeyValuePair<int, PlainItem> item)
        {
            throw new NotImplementedException();
        }

        public bool Remove(int key)
        {
            throw new NotImplementedException();
        }

        public bool TryGetValue(int key, out PlainItem value)
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
