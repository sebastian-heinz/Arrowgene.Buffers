using System.Collections.Generic;
using System.Net.Sockets;

namespace Arrowgene.Buffers
{
    
    // TODO rework this one
    public class BufferManager
    {
        private readonly int _numBytes;
        private readonly int _bufferSize;
        private readonly Stack<int> _freeIndexPool;

        private int _currentIndex;
        private byte[] _buffer;

        public BufferManager(int totalBytes, int bufferSize)
        {
            _numBytes = totalBytes;
            _currentIndex = 0;
            _bufferSize = bufferSize;
            _freeIndexPool = new Stack<int>();
        }

        public void InitBuffer()
        {
            _buffer = new byte[_numBytes];
        }

        public bool SetBuffer(SocketAsyncEventArgs args)
        {
            if (_freeIndexPool.Count > 0)
            {
                args.SetBuffer(_buffer, _freeIndexPool.Pop(), _bufferSize);
            }
            else
            {
                if (_numBytes - _bufferSize < _currentIndex)
                {
                    return false;
                }

                args.SetBuffer(_buffer, _currentIndex, _bufferSize);
                _currentIndex += _bufferSize;
            }

            return true;
        }

        public void FreeBuffer(SocketAsyncEventArgs args)
        {
            _freeIndexPool.Push(args.Offset);
            args.SetBuffer(null, 0, 0);
        }
    }
}