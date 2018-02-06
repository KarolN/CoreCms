using System;

namespace CoreCms.Common.Utils.Extensions
{
    public static class StringExtensions
    {
        public static string ToLowerCaseFirstLetter(this string text)
        {
            return Char.ToLowerInvariant(text[0]) + text.Substring(1);
        }
    }
}