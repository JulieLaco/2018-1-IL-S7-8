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
        private bool _canRead;
        private bool _canWrite;

        public KrabouilleStream( Stream inner, KrabouilleMode mode, string password )
        {
            if( mode == KrabouilleMode.Krabouille && !(inner.CanRead) )
            {
                _canWrite = true;
            }
            else if( mode == KrabouilleMode.Unkrabouille && !(inner.CanWrite) )
            {
                _canRead = true;
            }
        }

        public override bool CanRead => _canRead;

        public override bool CanSeek => false;

        public override bool CanWrite => _canWrite;

        public override long Length => throw new NotSupportedException();

        public override long Position { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public override void Flush()
        {
            throw new NotImplementedException();
        }

        public override int Read( byte[] buffer, int offset, int count )
        {
            throw new NotImplementedException();
        }

        public override long Seek( long offset, SeekOrigin origin )
        {
            throw new NotImplementedException();
        }

        public override void SetLength( long value )
        {
            throw new NotImplementedException();
        }

        public override void Write( byte[] buffer, int offset, int count )
        {
            throw new NotImplementedException();
        }
    }
}
