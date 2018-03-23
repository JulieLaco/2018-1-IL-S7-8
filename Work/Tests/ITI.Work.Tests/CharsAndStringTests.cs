using FluentAssertions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.Work.Tests
{
    [TestFixture]
    class CharsAndStringTests
    {
        [Test]
        public void chars_decomposition()
        {
            string s = "Noël";
            s.Length.Should().Be( 4 );
            var sD = s.Normalize( NormalizationForm.FormD );
            sD.Length.Should().Be( 5 );
        }

        [Test]
        public void removing_diacritics()
        {
            string s = "NoëléàùçÄÎµ";
            RemoveDiacritics( s ).Should().Be( "NoeleaucAIµ" );
        }


        [Test]
        public void testing_arabic()
        {
            string s = "الغوطة الشرق";
            var sR = RemoveDiacritics( s );

            var sD = s.Normalize( NormalizationForm.FormD );
            StringBuilder b = null;
            for( int i = 0; i < sD.Length; ++i )
            {
                if( Char.GetUnicodeCategory( sD, i ) == UnicodeCategory.NonSpacingMark )
                {
                    if( b == null ) b = new StringBuilder( sD, 0, i, s.Length );
                }
                else b?.Append( sD[i] );
            }
        }

        static string RemoveDiacritics( string s )
        {
            var sD = s.Normalize( NormalizationForm.FormD );
            StringBuilder b = new StringBuilder();
            foreach( var c in sD )
            {
                if( Char.GetUnicodeCategory( c ) != UnicodeCategory.NonSpacingMark )
                {
                    b.Append( c );
                }
            }
            return b.ToString();
        }


    }
}
