using System;

namespace Common
{
    public static class StringExtensions
    {
        public static string ReversedCopy(this string input)
        {
            char[] stringArray = input.ToCharArray();
            Array.Reverse(stringArray);
            return new string(stringArray);
        }
    }
}
