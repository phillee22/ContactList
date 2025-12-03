using System;
using System.Collections;
using System.Text;

namespace PhilsCollections
{
    public class PhilsEnumerator : IEnumerator
    {
        public object _head = null;
        object _current = null;

        public PhilsEnumerator(object Head)
        {
            _head = Head;
        }

        public object Current
        {
            get { return ((Node)_current).Data; }
        }

        public bool MoveNext()
        {
            if (_head == null)
            {
                throw new InvalidOperationException();
            }

            if (_current == null)  // first MoveNext call or first after a Reset() call...
            {
                _current = _head;
            }
            else
            {
                _current = ((Node)_current).next;
            }

            return (((Node)_current).next != null);
        }

        public void Reset()
        {
            _current = null;
        }
    }
}
