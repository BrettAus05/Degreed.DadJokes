using System.Text.RegularExpressions;

namespace Degreed.DadJokes.Core.Utilities
{
    public static class StringExtensions
    {
        /// <summary>
        /// Finds any occurance of the termToEmphasize and makes it uppercase
        /// </summary>
        /// <param name="input"></param>
        /// <param name="termToEmphasize"></param>
        /// <returns></returns>
        public static string Emphasize(this string input, string termToEmphasize)
        {
            if (string.IsNullOrEmpty(termToEmphasize))
            {
                return input;
            }
            return Regex.Replace(input, termToEmphasize, termToEmphasize.ToUpper(), RegexOptions.IgnoreCase);
        }
    }
}
