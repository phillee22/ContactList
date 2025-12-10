using System;
using System.Collections;
using System.Collections.Generic;


namespace PhilsCollections.Generic
{

#if false

    public class PhilsList<T> : IList<T>
    {
        int _count = 0;
        Node _end = null;
        bool _fixedsize = false;
        bool _readonly = false;
        bool _issynchronized = false;
        Node _head = null;

        //*****
        // Properties
        //*****
        public T this[int index]
        {        
            get
            {
                Node temp = _head;
                int i = 0;

                while ((temp != null) && (i < index))
                {
                    temp = temp.next;
                    i++;
                }

                if (temp != null)
                    return temp.Data;
                else
                    throw new IndexOutOfRangeException();
            }
            set
            {
                Node temp = _head;
                int i = 0;

                while ((temp != null) && (i < _count))
                {
                    temp = temp.next;
                    i++;
                }

                if (temp != null)
                    temp.Data = value;
                else
                    throw new IndexOutOfRangeException();
            }
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
        public void Add(T Item)
        {
            int index = 0;
            Node newnode = new Node(Item);
            Node temp = _head;
            if (temp == null)   // list is empty...
            {
                _head = newnode;
            }
            else
            {
                // go to the end of the list and add the new node there...
                while (temp.next != null)
                {
                    index++;
                    temp = temp.next;
                }
                temp.next = newnode;
            }

            _count++;
        }

        public void AddRange(T[] items)
        {
            throw new NotImplementedException("NYI");
        }

        public void Clear()
        {
            Node temp = _head;
            Node lead = _head;

            _head = null;
            _count = 0;

            // loop to the end to free each node's references...
            while(temp != null)
            {
                temp.Data = null;
                lead = temp.next;
                temp.next = null;
                temp = lead;
            }
        }

        private Node _Contains(T Item, out Node Trail)
        {
            Node temp = _head;
            Trail = null;   // must set to null until we know that _head is not empty.

            // loop until we find the end or the item...
            while ((temp != null) && (temp.Data.ToString() != Item.ToString()))
            {
                Trail = temp;
                temp = temp.next;
            }

            return temp;
        }

        // assuming that the calling (public) function is checking for errors so we don't have to
        // throw() from a private helper fuction.
        private Node _GotoIndex(int index)
        {
            Node temp = _head;
            int _ndx = 0;

            // loop until we find the end or the item...
            while ((temp != null) && (_ndx < index))
            {
                temp = temp.next;
                _ndx++;
            }

            return temp;
        }

        public bool Contains(T Item)
        {
            Node trail;    // throw away...

            if (this._Contains(Item, out trail) != null)   // must have found it - remove the reference to the data object...
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public object SyncRoot
        {
            get { throw new NotImplementedException(); }
        }

        public void CopyTo(T[] arrayOfItems, int Index)
        {
            throw new NotImplementedException("NYI");
        }

        // Implementation for the GetEnumerator method.
        IEnumerator<T> IEnumerable.GetEnumerator()
        {
            return (IEnumerator)GetEnumerator();
        }

        public PhilsEnumerator<T> GetEnumerator()
        {
            return new PhilsEnumerator(_head);
        }

        public int IndexOf(T Item)
        {
            throw new NotImplementedException();
        }

        public void Insert(int Index, T Item)
        {
            Node prev = null;

            // clear the error conditions...
            if (Index < 0) throw new IndexOutOfRangeException();
            if (Index > this._count) throw new IndexOutOfRangeException("Specified index is off the end of the list.");


            if (Index == 0)  // insert at the front of the list...
            {
                // if the list is empty, just call Add()
                if (_count == 0)
                {
                    this.Add(Item);
                }
                else  //
                {
                    prev = new Node(Item);
                    prev.next = _head;
                    _head = prev;
                    _count++;
                }
            }
            else  // go to the index of the node previous to the insertion poiun
            {
                prev = this._GotoIndex(Index-1);
                Node next = prev.next;
                prev.next = new Node(Item);
                prev.next.next = next;
                _count++;
            }
        }

        public bool Remove(T Item)
        {
            return false;

#if false
            Node trail = null;
            Node temp = this._Contains(Item, out trail);

            if (temp != null)   // must have found it - remove the reference to the data object...
            {
                temp.Data = null;

                if (_count == 1)  // one-item list and we found the item at the first node...
                {
                    _head = null;
                }
                else if (trail == null)  // multi-item list, but we found the item at the first node...
                {
                    _head = temp.next;
                }
                else  // multi-item list and found the item in the middle/end somewhere...
                {
                    trail.next = temp.next;
                }

                _count--;
            }

#endif
        }

        public void RemoveAt(int Index)
        {
            throw new NotImplementedException();
        }
    }
#endif

}
