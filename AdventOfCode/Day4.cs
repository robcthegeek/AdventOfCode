using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode
{
    // Day 4: Secure Container
    public static class Passcode
    {
        public static bool IsValid(int passcode)
        {
            var chars = passcode.ToString().ToCharArray();
            if (chars.Length != 6) return false;
            if (new HashSet<char>(chars).Count == chars.Length) return false; // no matches

            int last = -1;
            for (int i = 0; i < chars.Length; i++)
            {
                var asInt = int.Parse(chars[i].ToString());
                if (asInt < last) return false;
                last = asInt;
            }

            return true;
        }

        public static int ValidInRange(int start, int end) =>
            Enumerable
                .Range(start, end - start + 1)
                .Count(IsValid);
    }
}
