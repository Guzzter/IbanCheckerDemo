using IbanChecker;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IbanCheckerDemo
{
    [TestClass]
    public class IbanStringUtilsTests
    {
        private const string VALID_IBAN = "NL83INGB0001865679";

        [TestMethod]
        public void ConvertToChecksumStart_ValidIban_ShouldConvertedChecksum()
        {
            Assert.AreEqual("83", IbanStringUtils.GetCheckSum(VALID_IBAN));
        }

        [TestMethod]
        public void GetCountryCodeFromIban_Iban_ShouldReturnCountryCode()
        {
            Assert.AreEqual("NL", IbanStringUtils.GetCountryCodeFromIban(VALID_IBAN));
        }

        [TestMethod]
        public void GetBankCodeFromIban_Iban_ShouldReturnBankCode()
        {
            Assert.AreEqual("INGB", IbanStringUtils.GetBankCodeFromIban(VALID_IBAN));
        }

        [TestMethod]
        public void GetBankAccountFromIban_Iban_ShouldReturnBankAccountNr()
        {
            Assert.AreEqual("0001865679", IbanStringUtils.GetBankAccountFromIban(VALID_IBAN));
        }


    }
}
