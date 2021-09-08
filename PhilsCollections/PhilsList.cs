using System;
using System.Collections;

namespace PhilsCollections
{
    public class PhilsList : IList
    {
        int _count = 0;
        bool _fixedsize = false;
        bool _readonly = false;
        bool _issynchronized = false;
        object _head = null;

        //*****
        // Properties
        //*****
        public object? this[int index]
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }
        public int Count
        {  
            get { return _count; }
        }
        public bool IsFixedSize
        {
            get { return _fixedsize; }
        }
        public bool IsReadOnly
        {
            get { return _readonly; }
        }

        public bool IsSynchronized
        {
            get { return _issynchronized; }
        }

        //*****
        // Methods
        //*****
        public int Add(object Item)
        {
            throw new NotImplementedException();
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public bool Contains(object Item)
        {
            throw new NotImplementedException();
        }

        public object SyncRoot
        {
            get { throw new NotImplementedException(); }
        }
    public void CopyTo(Array ItemArray, int Index)
        {
            throw new NotImplementedException();
        }

        // Implementation for the GetEnumerator method.
        IEnumerator IEnumerable.GetEnumerator()
        {
            return (IEnumerator)GetEnumerator();
        }

        public PhilsEnumerator GetEnumerator()
        {
            return new PhilsEnumerator(_head);
        }

        public int IndexOf(object Item)
        {
            throw new NotImplementedException();
        }

        public void Insert(object Item)
        {
            throw new NotImplementedException();
        }
        public void Insert(int Index, object Item)
        {
            throw new NotImplementedException();
        }

        public void Remove(object Item)
        {
            throw new NotImplementedException();
        }

        public void RemoveAt(int Index)
        {
            throw new NotImplementedException();
        }
    }
}
