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

        public static bool IsValidPartDeux(int passcode)
        {
            var digits = passcode.ToString().ToCharArray();
            if (digits.Length != 6) return false;

            var hasPair = false;
            var previous = digits[0];
            var count = 1;
            for (var i = 1; i < digits.Length; i++)
            {
                if (digits[i - 1] > digits[i]) return false;

                if (previous == digits[i])
                    count++;
                else
                {
                    if (count == 2) hasPair = true;

                    count = 1;
                    previous = digits[i];
                }
            }

            if (count == 2) hasPair = true;

            return hasPair;
        }

        public static int ValidInRange(int start, int end) =>
        Enumerable
            .Range(start, end - start + 1)
            .Count(IsValid);

        public static int ValidInRangePartDeux(int start, int end) =>
        Enumerable
            .Range(start, end - start + 1)
            .Count(IsValidPartDeux);
    }
}
