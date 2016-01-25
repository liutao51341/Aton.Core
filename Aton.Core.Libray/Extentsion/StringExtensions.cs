using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;


namespace Aton.Core.Library.Extentsion
{
    /// <summary>
    /// This static class contains several common String extension methods.
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        /// Replaces the characters in the originalChars string with the
        /// corresponding characters of the newChars string.
        /// </summary>
        /// <param name="txt">String to operate on.</param>
        /// <param name="originalChars">String with original characters.</param>
        /// <param name="newChars">String with replacement characters.</param>
        /// <example>For an original string equal to "123456654321" and originalChars="35" and
        /// newChars "AB", the result will be "12A4B66B4A21".</example>
        /// <returns>String with replaced characters.</returns>
        public static string ReplaceChars(this string txt, string originalChars, string newChars)
        {
            string returned = "";

            for (int i = 0; i < txt.Length; i++)
            {
                int pos = originalChars.IndexOf(txt.Substring(i, 1));
                
                if (-1 != pos)
                    returned += newChars.Substring(pos, 1);
                else
                    returned += txt.Substring(i, 1);
            }
            return returned;
        }
    }
}
