using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.Work.Tests
{
    [TestFixture]
    public class EnumerableGameTests
    {

        IEnumerable<long> GetNumbers( long start, long count )
        {
            long idx = 0;

            while(idx < count)
            {
                yield return start + idx;
                idx++;
            }

            // Vision du prof : for (long i = 0; i < count; ++i) yield return start + i;
        }

        IEnumerable<long> GetNumbersThatAreNotMultipleOf( long start, long count, IEnumerable<long> divisors )
        {
            long idx = 0;

            while( idx < count )
            {
                foreach (long i in divisors)
                {
                    if( idx % i == 0 ) yield return start + idx;
                }

                idx++;
            }
        }

        [Test]
        public void generating_numbers()
        {
            IEnumerable<long> test = GetNumbers( 1, 5 );
            long t = 1;

            foreach( long i in test )
            {
                Assert.AreEqual( i, t );
                t++;
            }
        }

        [Test]
        public void generating_numbers_that_are_not_multiple_of()
        {
            IEnumerable<long> test = GetNumbers( 2, 4 );
            IEnumerable<long> getMultipleOf = GetNumbersThatAreNotMultipleOf( 0, 10, test );

            long x = 0;

            foreach( long i in getMultipleOf )
            {
                Assert.AreEqual( i, x );
            }
        }
    }
}
