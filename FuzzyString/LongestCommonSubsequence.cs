//    ___                    __ _        _             
//   / __\   _ _________   _/ _\ |_ _ __(_)_ __   __ _ 
//  / _\| | | |_  /_  / | | \ \| __| '__| | '_ \ / _` |
// / /  | |_| |/ / / /| |_| |\ \ |_| |  | | | | | (_| |
// \/    \__,_/___/___|\__, \__/\__|_|  |_|_| |_|\__, |
//                     |___/                     |___/ 
// File: FuzzyString/FuzzyString/LongestCommonSubsequence.cs
// User: Adrian Hum/
// 
// Created:  2017-10-18 7:51 PM
// Modified: 2017-10-18 9:10 PM

using System;

namespace FuzzyString
{
    public static partial class ComparisonMetrics
    {
        public static string LongestCommonSubsequence(this string source, string target)
        {
            var c = LongestCommonSubsequenceLengthTable(source, target);

            return Backtrack(c, source, target, source.Length, target.Length);
        }

        private static int[,] LongestCommonSubsequenceLengthTable(string source, string target)
        {
            var c = new int[source.Length + 1, target.Length + 1];

            for (var i = 0; i < source.Length + 1; i++) c[i, 0] = 0;
            for (var j = 0; j < target.Length + 1; j++) c[0, j] = 0;

            for (var i = 1; i < source.Length + 1; i++)
            for (var j = 1; j < target.Length + 1; j++)
                if (source[i - 1].Equals(target[j - 1]))
                    c[i, j] = c[i - 1, j - 1] + 1;
                else
                    c[i, j] = Math.Max(c[i, j - 1], c[i - 1, j]);

            return c;
        }

        private static string Backtrack(int[,] c, string source, string target, int i, int j)
        {
            if (i == 0 || j == 0)
                return "";
            if (source[i - 1].Equals(target[j - 1]))
                return Backtrack(c, source, target, i - 1, j - 1) + source[i - 1];
            return c[i, j - 1] > c[i - 1, j]
                ? Backtrack(c, source, target, i, j - 1)
                : Backtrack(c, source, target, i - 1, j);
        }
    }
}