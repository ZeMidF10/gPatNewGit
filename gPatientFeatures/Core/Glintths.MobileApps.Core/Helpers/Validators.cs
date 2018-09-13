using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Glintths.MobileApps.Core.Helpers
{
    public static class Validators
    {
        public static bool IsValidPatientName(string strIn)
        {
            if (String.IsNullOrEmpty(strIn))
                return false;
            return (strIn.Length >= 4 && strIn.Length <81);
        }

        public static bool IsValidDate(string strIn)
        {
            if (String.IsNullOrEmpty(strIn))
                return false;
            var aux = new DateTime();
            var result = DateTime.TryParse(strIn, out aux);
            return (result && aux.Year > 1900 && aux.Year < DateTime.Today.Year);
        }

        public static bool IsValidPatientNIF(string strIn)
        {
            if (String.IsNullOrEmpty(strIn))
                return false;
            return strIn.Length == 9;
        }

        public static bool IsValidphoneNumber(string strIn)
        {
            if (String.IsNullOrEmpty(strIn))
                return false;
            try
            {
                strIn = strIn.Replace(" ", "");
                return Regex.IsMatch(strIn,
                    @"^(^(\+|00)\d{1,4}){0,1}(\s{0,1})\d{9,15}$",
                    RegexOptions.IgnorePatternWhitespace,
                    TimeSpan.FromMilliseconds(250));
            }
            catch (RegexMatchTimeoutException)
            {
                return false;
            }
        }

        public static bool IsValidEmail(string strIn)
        {
            if (String.IsNullOrEmpty(strIn))
                return false;

            // Return true if strIn is in valid e-mail format.
            try
            {
                return Regex.IsMatch(strIn,
                    @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                    @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$",
                    RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));
            }
            catch (RegexMatchTimeoutException)
            {
                return false;
            }
        }

        /// <summary>
        /// Substituicao do ToTitleCase que pelos vistos nao existe no cultureinfo em xamarin forms
        /// Poe a primeira letra da palavra maiuscula
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string ToTitleCase(string str)
        {
            try
            {
                string auxStr = str.ToLower();
                string[] auxArr = auxStr.Split(' ');
                string result = "";
                bool firstWord = true;
                foreach (string word in auxArr)
                {
                    if (!String.IsNullOrWhiteSpace(word))
                    {
                        if (!firstWord)
                            result += " ";
                        else
                            firstWord = false;

                        result += word.Substring(0, 1).ToUpper();

                        if (word.Length > 1)
                            result += word.Substring(1, word.Length - 1);
                    }
                }
                return result;
            }
            catch (Exception e)
            {
                return str;
            }


        }

    }
}
