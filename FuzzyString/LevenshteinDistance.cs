//    ___                    __ _        _             
//   / __\   _ _________   _/ _\ |_ _ __(_)_ __   __ _ 
//  / _\| | | |_  /_  / | | \ \| __| '__| | '_ \ / _` |
// / /  | |_| |/ / / /| |_| |\ \ |_| |  | | | | | (_| |
// \/    \__,_/___/___|\__, \__/\__|_|  |_|_| |_|\__, |
//                     |___/                     |___/ 
// File: FuzzyString/FuzzyString/LevenshteinDistance.cs
// User: Adrian Hum/
// 
// Created:  2017-10-18 7:51 PM
// Modified: 2017-10-18 9:10 PM

using System;

namespace FuzzyString
{
    public static partial class ComparisonMetrics
    {
        public static int LevenshteinDistance(this string source, string target)
        {
            if (source.Length == 0) return target.Length;
            if (target.Length == 0) return source.Length;

            var distance = source[source.Length - 1] == target[target.Length - 1] ? 0 : 1;

            return Math.Min(Math.Min(LevenshteinDistance(source.Substring(0, source.Length - 1), target) + 1,
                                LevenshteinDistance(source, target.Substring(0, target.Length - 1))) + 1,
                LevenshteinDistance(source.Substring(0, source.Length - 1), target.Substring(0, target.Length - 1)) +
                distance);
        }

        public static double NormalizedLevenshteinDistance(this string source, string target)
        {
            var unnormalizedLevenshteinDistance = source.LevenshteinDistance(target);

            return unnormalizedLevenshteinDistance - source.LevenshteinDistanceLowerBounds(target);
        }

        public static int LevenshteinDistanceUpperBounds(this string source, string target)
        {
            // If the two strings are the same length then the Hamming Distance is the upper bounds of the Levenshtien Distance.
            if (source.Length == target.Length) return source.HammingDistance(target);

            // Otherwise, the upper bound is the length of the longer string.
            if (source.Length > target.Length) return source.Length;
            if (target.Length > source.Length) return target.Length;

            return 9999;
        }

        public static int LevenshteinDistanceLowerBounds(this string source, string target)
        {
            // If the two strings are the same length then the lower bound is zero.
            if (source.Length == target.Length) return 0;

            // If the two strings are different lengths then the lower bounds is the difference in length.
            return Math.Abs(source.Length - target.Length);
        }
    }
}