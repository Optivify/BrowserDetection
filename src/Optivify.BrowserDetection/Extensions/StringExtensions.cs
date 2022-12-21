using System;
using System.Text;

namespace Optivify.BrowserDetection.Extensions
{
    public static class StringExtensions
    {
        public static bool Contains(this string str, string strToCompare, StringComparison comparison)
        {
            if (str == null || strToCompare == null)
            {
                return false;
            }

            return str.IndexOf(strToCompare, comparison) >= 0;
        }

        public static string Replace(this string str, string oldValue, string newValue, StringComparison comparison)
        {
            var sb = new StringBuilder();
            var lastIndex = 0;
            var index = str.IndexOf(oldValue, comparison);

            while (index != -1)
            {
                sb.Append(str.Substring(lastIndex, index - lastIndex));
                sb.Append(newValue);
                index += oldValue.Length;
                lastIndex = index;
                index = str.IndexOf(oldValue, index, comparison);
            }

            sb.Append(str.Substring(lastIndex));

            return sb.ToString();
        }
    }
}
