using Glintths.Apps.Base.Internationalization.Resx;
using Glintths.MobileApps.BusinessLayer.Exceptions;
using Glintths.MobileApps.Core.ServiceAccessLayer;
using System;
using System.Text.RegularExpressions;

namespace Glintths.MobileApps.Core.Helpers
{
    public static class CardValidator
    {
        /// <summary>
        /// Percorre o cartao para cada letra e verifica para cada formato
        /// </summary>
        /// <returns></returns>
        public static bool ValidateFormat(string cardNumber, string format)
        {
            try
            {
                if (String.IsNullOrWhiteSpace(format))
                    throw new EFRException(AppResources.UnknownCardFormat);

                if (cardNumber.Length != format.Length)
                    throw new EFRException(AppResources.CardNumberInvalid);

                for (int i = 0; i < format.Length; i++)
                {
                    string a = (cardNumber).Substring(i, 1);
                    string b = (format).Substring(i, 1);
                    ValidateChar(a, b);
                }
                return true;
            }
            catch (EFRException e)
            {
                return false;
            }

        }

        /// <summary>
        /// # - qualquer letra
        /// 9 - Numero de 0 a 9
        /// numero != 9 - numero obrigatorio
        /// </summary>
        /// <param name="card"></param>
        /// <param name="format"></param>
        private static void ValidateChar(string card, string format)
        {
            int formatNumber, cardNumber;
            bool formatIsNumeric = int.TryParse(format, out formatNumber);
            bool cardIsNumeric = int.TryParse(card, out cardNumber);

            if (formatIsNumeric)
            {
                if (!cardIsNumeric)
                    throw new EFRException(AppResources.CardNumberInvalid);

                else
                {
                    if (formatNumber != 9 && cardNumber != formatNumber)
                        throw new EFRException(AppResources.CardNumberInvalid);
                }
            }
            // formato nao é numero -> #
            else if (format == "#")
            {
                if (cardIsNumeric)
                    throw new EFRException(AppResources.CardNumberInvalid);

                // evitar caracteres que nao sao letras
                if (Regex.Matches(card, @"[a-zA-Z]").Count != 1)
                    throw new EFRException(AppResources.CardNumberInvalid);
            }
            else
                throw new EFRException(AppResources.UnknownCardFormat);
        }

        /// <summary>
        /// Verifica a data de expiração do cartão
        /// </summary>
        public static bool ValidateExpDate(int year, int month)
        {
            DateTime nowDate = DateTime.Now;
            nowDate = nowDate.Date.AddDays(-nowDate.Day + 1);

            try
            {
                if ((month > 12 || month < 1 ) ||
                    (nowDate > new DateTime(year, month, 1)))
                {
                    throw new EFRException(AppResources.ExpiredCardDate);
                }
                return true;
            }
            catch (EFRException e)
            {
                return false;
            }
        }
    }
}
