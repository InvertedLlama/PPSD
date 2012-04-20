using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace PPSDPart2
{
    public static class DataValidation
    {
        /// <summary>
        /// Validates a string compared to a set of regex patterns
        /// <param name="data">String to validate</param>
        /// <param name="regexPattern">Regex pattern to validate with</param>
        /// </summary>        /// 
        /// <remarks>More Info: http://gist.github.com/2391792 </remarks>
        //Note: I've edited the regex pattern for email address to allow the . character before the @ and to allow numbers at the end for domains like 6x.to ~Pete
        public static bool validateInformation(string data, RegexPattern regexPattern)
        {
            string pattern = string.Empty;
            switch (regexPattern)
            {
                case RegexPattern.NameString:
                    pattern = "^[A-Za-z -]+$";
                    break;
                case RegexPattern.NumericalString:
                    pattern = "^[0-9]+$";
                    break;
                case RegexPattern.EmailString:
                    pattern = "^[0-9A-Za-z.]+[@][0-9A-Za-z]+[.][A-Za-z0-9.]+$";
                    break;
                case RegexPattern.PriceString:
                    pattern = @"^[0-9]+\.[0-9]+$";
                    break;
                case RegexPattern.PhoneString:
                    pattern = "[+]?[0-9]{5,6} ?[0-9]{3} ?[0-9]{3}";
                    break;
            }

            return new Regex(pattern).IsMatch(data);
        }

    }

    public enum RegexPattern
    {
        NameString,
        NumericalString,
        EmailString,
        PriceString,
        PhoneString
    };
    
}
