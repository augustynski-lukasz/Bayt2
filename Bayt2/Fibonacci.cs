using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;

namespace Bayt2
{
    public class FibonacciNumbers : IEnumerable<BigInteger>, IEnumerator<BigInteger>
    {
        private Int64 _position = -1;
        private readonly BigInteger[] _fibonacciLast = {0, 1};

        IEnumerator<BigInteger> IEnumerable<BigInteger>.GetEnumerator()
        {
            return this;
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
                    return _fibonacciLast[_position];

                var temp = _fibonacciLast.Sum();
                _fibonacciLast[0] = _fibonacciLast[1];
                _fibonacciLast[1] = temp;
                return temp;
            }
        }

        public void Dispose()
        {
            
        }

        public IEnumerator GetEnumerator()
        {
            return this;
        }
    }
}
