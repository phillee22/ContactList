using System;
using System.Collections;
using System.Text;

namespace PhilsCollections
{
    public class PhilsEnumerator : IEnumerator
    {
        object _head = null;
        object _current = null;
        public PhilsEnumerator(object Head)
        {
            _head = Head;
        }
        public object Current
        {
            get { throw new NotImplementedException(); }
        }
        public bool MoveNext()
        {
            throw new NotImplementedException();
        }
        public void Reset()
        {
            _current = _head;
        }
    }
}
