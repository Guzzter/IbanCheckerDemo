using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using IbanChecker;
using FluentAssertions;

namespace IbanCheckerDemo
{
    /// <summary>
    /// Summary description for IbanChecksumTests
    /// </summary>
    [TestClass]
    public class IbanChecksumTests
    {
        private const string VALID_IBAN = "NL83INGB0001865679";
        IbanChecksum _checksum = new IbanChecksum();

        [TestMethod]
        public void Init()
        {
            _checksum = new IbanChecksum();
        }

        [TestMethod]
        public void ConvertToChecksumStart_ValidIban_ShouldConvertedChecksum()
        {
            Assert.AreEqual("INGB0001865679NL", _checksum.ConvertToChecksumStart(VALID_IBAN));
            //Use Fluent assertions:
            _checksum.ConvertToChecksumStart(VALID_IBAN).Should().Be("INGB0001865679NL");

        }

        [TestMethod]
        public void ConvertChecksumToNumberString_ValidIban_ShouldReturnStringWithInts()
        {
            Assert.AreEqual("182316110001234567232100", _checksum.ConvertChecksumToNumberString("INGB0001234567NL"));
        }

        [TestMethod]
        public void ConvertNumberStringToInt_ValidIban_ConvertChecksumToNumberString_ValidIban_ShouldReturnBigInt()
        {
            Assert.AreEqual(20, _checksum.ConvertNumberStringToInt("182316110001234567232100"));
        }
        
        [TestMethod]
        public void Calculate_ValidIban_ShouldReturnIbanNumber()
        {
            Assert.AreEqual(83, _checksum.Calculate(VALID_IBAN));
        }
    }
}
