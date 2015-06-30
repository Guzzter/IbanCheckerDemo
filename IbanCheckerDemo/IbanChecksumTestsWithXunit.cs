using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace IbanChecker
{

    //add via NuGet: xUNit + xUnit for Visual Studio
    public class IbanChecksumTestsWithXunit
    {
        private const string VALID_IBAN = "NL83INGB0001865679";
        IbanChecksum _checksum = new IbanChecksum();

        public IbanChecksumTestsWithXunit()
        {
            _checksum = new IbanChecksum();
        }

        [Fact]
        public void ConvertToChecksumStart_ValidIban_ShouldConvertedChecksum()
        {
            Assert.Equal("INGB0001865679NL", _checksum.ConvertToChecksumStart(VALID_IBAN));
        }

        [Theory]
        [InlineData(1, 2, 3)]
        [InlineData(2, 3, 5)]
        public void SimpleSumCase(int a, int b, int expected)
        {
            var actual = a + b;
            Assert.Equal(expected, actual);
        }


        [Theory]
        [InlineData(3)]
        [InlineData(5)]
        [InlineData(7)]
        public void MyFirstTheory(int value)
        {
            Assert.True(IsOdd(value));
        }

        bool IsOdd(int value)
        {
            return value % 2 == 1;
        }


        [Theory]
        [InlineData("", false)]
        [InlineData(" ", false)]
        [InlineData(null, false)]
        [InlineData("NL83INGB0001865679", true)]
        [InlineData("NL83INGB000", false)]
        [InlineData("XX83INGB0001865679", false)]
        [InlineData("NL83INGB000186ABCD", false)]
        [InlineData("NL99INGB0001865679", false)]
        public void Validate_Iban_ShouldReturnCorrectResult(string inputIban, bool result)
        {
            IbanValidator ibanValidator = new IbanValidator();
            Assert.Equal(ibanValidator.Validate(inputIban), result);
        }

    }
}
