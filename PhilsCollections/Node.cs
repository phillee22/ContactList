using System;
using System.Collections.Generic;
using System.Text;

namespace PhilsCollections
{
    class Node
    {
        internal Node next = null;
        object _data = null;

        internal Node(object Data)
        {
            _data = Data;
            next = null;
        }

        internal object Data
        {
            get { return _data; }
            set { _data = value; }
        }
    }
}
