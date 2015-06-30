using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace IbanChecker
{
    
    public class IbanChecksum
    {
        //https://nl.wikipedia.org/wiki/International_Bank_Account_Number


        //Step 1
        internal string ConvertToChecksumStart(string iban)
        {
            return IbanStringUtils.GetBankCodeFromIban(iban) + 
                IbanStringUtils.GetBankAccountFromIban(iban) + 
                IbanStringUtils.GetCountryCodeFromIban(iban);
        }
        
        //Step 2
        internal string ConvertChecksumToNumberString(string checksumStart)
        {
            string numberString = "";
            for (int i = 0; i < checksumStart.Length; i++)
            {
                var chr = checksumStart[i];
                if (Char.IsDigit(chr))
                {
                    numberString += chr;
                }
                else
                {
                    numberString += (Convert.ToInt16(chr)-55);
                }
            }

            return numberString + "00";
        }

        //Step 3
        internal int ConvertNumberStringToInt(string checksum)
        {
            var nr = BigInteger.Parse(checksum);

            //182316110001234567232100 mod 97 = 78
            int remainder = (int)(nr % new BigInteger(97));

            //98 - 78 = 20
            return 98 - remainder;
        }


        //All steps
        public int Calculate(string iban)
        {
            string checkStart = ConvertToChecksumStart(iban);
            string numberString = ConvertChecksumToNumberString(checkStart);
            int checksum = ConvertNumberStringToInt(numberString);
            return checksum;
        }

    }
}
