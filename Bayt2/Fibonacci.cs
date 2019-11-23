using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;

namespace Bayt2
{
    public class FibonacciNumbers : IEnumerable<BigInteger>, IEnumerator<BigInteger>
    {
        private Int64 _position = -1;
        private BigInteger[] _fibonaciLast = {0, 1};

        public FibonacciNumbers()
        {  
        }

        IEnumerator<BigInteger> IEnumerable<BigInteger>.GetEnumerator()
        {
            return (IEnumerator<BigInteger>)this;
        }

        public bool MoveNext()
        {
            ++_position;
            return true;
        }

        public void Reset()
        {
            _position = -1;
        }

        object IEnumerator.Current => Current;

        public BigInteger Current
        {
            get
            {
                if (_position < 2)
                    return _fibonaciLast[_position];

                var temp = _fibonaciLast.Sum();
                _fibonaciLast[0] = _fibonaciLast[1];
                _fibonaciLast[1] = temp;
                return temp;
            }
        }

        public void Dispose()
        {
            
        }

        public IEnumerator GetEnumerator()
        {
            return (IEnumerator)this;
        }
    }
}
