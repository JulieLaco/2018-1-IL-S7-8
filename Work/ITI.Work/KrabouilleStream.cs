using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ITI.Work
{
    public enum KrabouilleMode
    {
        /// <summary>
        /// Used to write krabouilled data to the inner stream.
        /// </summary>
        Krabouille,

        /// <summary>
        /// Used to read krabouilled data from inner stream.
        /// </summary>
        Unkrabouille
    }

    public class KrabouilleStream : Stream
    {
        readonly Stream _inner;
        readonly KrabouilleMode _mode;
        long _position;

        public KrabouilleStream( Stream inner, KrabouilleMode mode, string password )
        {
            if( inner == null ) throw new ArgumentException( nameof(inner) );
            if( String.IsNullOrEmpty( password ) ) throw new ArgumentException();
            if( !inner.CanWrite && mode == KrabouilleMode.Krabouille )
            {
                throw new ArgumentException(" Inner must be writable for Krabouille mode.", nameof(inner) );
            }
            if( !inner.CanRead && mode == KrabouilleMode.Unkrabouille )
            {
                throw new ArgumentException( " Inner must be readable for Unkrabouille mode.", nameof(inner) );
            }

            _inner = inner;
            _mode = mode;
        }

        public override bool CanRead => _mode == KrabouilleMode.Unkrabouille;

        public override bool CanSeek => false;

        public override bool CanWrite => _mode == KrabouilleMode.Krabouille;

        public override long Length => throw new NotSupportedException();

        public override long Position
        {
            get => _position;
            set => throw new NotSupportedException();
        }

        public override void Flush() => _inner.Flush();

        public override int Read( byte[] buffer, int offset, int count )
        {
            if( !CanRead ) throw new InvalidOperationException();
            return _inner.Read(buffer, offset, count);       
        }

        public override long Seek( long offset, SeekOrigin origin )
        {
            throw new NotSupportedException();
        }

        public override void SetLength( long value )
        {
            throw new NotSupportedException();
        }

        public override void Write( byte[] buffer, int offset, int count )
        {
            if( !CanWrite ) throw new InvalidOperationException();



            _inner.Write( buffer, offset, count );
        }
    }
}
