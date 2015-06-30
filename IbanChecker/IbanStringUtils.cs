using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IbanChecker
{
    public class IbanStringUtils
    {
        public static string GetCountryCodeFromIban(string ibanCode)
        {
            return ibanCode.Substring(0, 2).ToUpperInvariant();
        }

        public static string GetBankAccountFromIban(string ibanCode)
        {
            return ibanCode.Substring(8);
        }

        public static string GetBankCodeFromIban(string ibanCode)
        {
            return ibanCode.Substring(4, 4).ToUpperInvariant();
        }


        public static string GetCheckSum(string ibanCode)
        {
            return ibanCode.Substring(2, 2);
        }
    }
}
