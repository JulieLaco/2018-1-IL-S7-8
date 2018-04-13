using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace ITI.Work
{
    public class ITIList<T> : IITIList<T>
    {
        T[] _tab;
        int _count;

        public ITIList()
        {
            _tab = new T[4];
        }

        public ITIList( int initialCapacity )
        {
            if( initialCapacity <= 0 ) throw new ArgumentNullException( nameof( initialCapacity ), "Must be positive." );
            _tab = new T[initialCapacity];
        }

        public int Count => _count;

        public T this[ int index ]
        {
            get
            {
                if( index < 0 || index >= _count ) throw new IndexOutOfRangeException();
                return _tab[index];
            }
            set
            {
                if( index < 0 || index >= _count ) throw new IndexOutOfRangeException();
                _tab[index] = value;
            }
        }

        public void RemoveAt( int index )
        {
            if( index < 0 || index >= _count ) throw new IndexOutOfRangeException();
            Array.Copy( _tab, index + 1, _tab, index, _count - index );
            --_count;
        }

        public void InsertAt( int index, T value )
        {
            if( index < 0 || index > _count ) throw new IndexOutOfRangeException();

            if( _count == _tab.Length ) ResizeInternalArray();

            else
            {
                Array.Copy( _tab, index, _tab, index + 1, _count - index );
                _tab[index] = value;
                _count++;
            }
            
        }

        public int IndexOf( T i )
        {
            for( int x = 0; x < _count; ++x )
            {
                if( _tab[x].Equals( i ) ) return x;
            }
            return -1;
        }

        public void Add( T i )
        {
            if( _count == _tab.Length ) ResizeInternalArray();
            _tab[_count++] = i;
        }

        void ResizeInternalArray()
        {
            var newTab = new T[_tab.Length * 2];
            Array.Copy( _tab, newTab, _count );
            _tab = newTab;
        }

        class E : IEnumerator<T>
        {
            readonly ITIList<T> _papa;
            int _indexer;
            private bool _disposed = false;
            //SafeHandle handle = new SafeHandle( IntPtr.Zero, true );

            public E( ITIList<T> papa )
            {
                _papa = papa;
                _indexer = -1;
            }

            public T Current => _papa._tab[_indexer];

            object IEnumerator.Current => Current;

            public void Dispose()
            {
                Dispose( true );
                GC.SuppressFinalize( this );

            }

            protected virtual void Dispose(bool disposing)
            {
                //if( _disposed ) return;
                //if(disposing)
                //{
                //    handle.Dispose();
                //}

                //_disposed = true;
            }

            public bool MoveNext()
            {
                _indexer++;
                return (_indexer < _papa.Count);
            }

            public void Reset() => throw new NotSupportedException();
        }


        public IEnumerator<T> GetEnumerator()
        {
            return new E( this );
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
