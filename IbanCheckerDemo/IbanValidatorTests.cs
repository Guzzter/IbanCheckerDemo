using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using IbanChecker;

namespace IbanCheckerDemo
{
    [TestClass]
    public class IbanValidatorTests
    {
        IbanValidator _ibanValidator;
        private const string VALID_IBAN = "NL83INGB0001865679";

        [TestInitialize]
        public void InitTest()
        {
             _ibanValidator = new IbanValidator();
        }

        [TestMethod]
        public void Validate_IncorrectLength_ShouldReturnFalse()
        {
            Assert.IsFalse(_ibanValidator.Validate("NL83INGB000"));
        }

        [TestMethod]
        public void Validate_EmptyOrNull_ShouldReturnFalse()
        {
            Assert.IsFalse(_ibanValidator.Validate(""));
            Assert.IsFalse(_ibanValidator.Validate(string.Empty));
            Assert.IsFalse(_ibanValidator.Validate(" "));
            Assert.IsFalse(_ibanValidator.Validate(null));
        }

        [TestMethod]
        public void Validate_ValidTwoLetterCountryCode_ShouldReturnTrue()
        {
            Assert.IsTrue(_ibanValidator.Validate(VALID_IBAN));
        }

        [TestMethod]
        public void Validate_InvalidTwoLetterCountryCode_ShouldReturnFalse()
        {
            Assert.IsFalse(_ibanValidator.Validate("XX83INGB0001865679"));
        }


        [TestMethod]
        public void Validate_NotLastTenDigits_ShouldReturnFalse()
        {
            Assert.IsFalse(_ibanValidator.Validate("NL83INGB000186ABCD"));
        }

        [TestMethod]
        public void Validate_InCorrectBankCode_ShouldReturnFalse()
        {
            Assert.IsFalse(_ibanValidator.Validate(VALID_IBAN.Replace("INGB", "HENK")));
        }

        [TestMethod]
        public void Validate_IncorrectChecksumInIban_ShouldReturnFalse()
        {
            Assert.IsFalse(_ibanValidator.Validate(VALID_IBAN.Replace("NL83ING", "NL99ING")));
        }

        [TestMethod]
        public void Validate_CorrectIban_ShouldReturnTrue()
        {
            Assert.IsTrue(_ibanValidator.Validate(VALID_IBAN));
        }

    }
}
