using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace ITI.Work
{
    public class ITIDictionary<TKey,TValue> : IEnumerable<KeyValuePair<TKey,TValue>>
    {
        int _count;
        Node[] _buckets;

        class Node
        {
            public readonly TKey Key;
            public TValue Value;
            public Node Next;
        }

        public int Count => _count;

        public void Add( TKey key, TValue value )
        {

        }

        public void Remove( TKey key )
        {

        }

        public TValue this[ TKey key ]
        {
            get { return default( TValue ); }
            set { }
        }

        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    }
}
