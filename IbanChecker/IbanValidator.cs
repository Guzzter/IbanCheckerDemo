using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IbanChecker
{
    public class IbanValidator
    {
        private List<string> _validCountries;
        private List<string> _validBanks;
        private IbanChecksum _checksumCalc;

        public IbanValidator()
        {
            _validCountries = new List<string>();
            _validCountries.Add("NL");
            _validCountries.Add("DE");

            _validBanks = new List<string>() { "INGB" };

            _checksumCalc = new IbanChecksum();
        }


        public bool Validate(string iban)
        {

            if (string.IsNullOrWhiteSpace(iban))
                return false;

            if (iban.Length != 18)
                return false;

            string countryCode = IbanStringUtils.GetCountryCodeFromIban(iban);
            if (!_validCountries.Contains(countryCode))
                return false;

            string bankCode = IbanStringUtils.GetBankCodeFromIban(iban);
            if (!_validBanks.Contains(bankCode))
                return false;

            string accountNumber = IbanStringUtils.GetBankAccountFromIban(iban);
            int parsedAccountNumber = 0;
            if (!int.TryParse(accountNumber, out parsedAccountNumber))
                return false;

            string givenCheckSum = IbanStringUtils.GetCheckSum(iban);
            string calculatedChecksum = ""+_checksumCalc.Calculate(iban);

            if (calculatedChecksum != givenCheckSum)
                return false;

            return true;
        }


    }
}
