//    ___                    __ _        _             
//   / __\   _ _________   _/ _\ |_ _ __(_)_ __   __ _ 
//  / _\| | | |_  /_  / | | \ \| __| '__| | '_ \ / _` |
// / /  | |_| |/ / / /| |_| |\ \ |_| |  | | | | | (_| |
// \/    \__,_/___/___|\__, \__/\__|_|  |_|_| |_|\__, |
//                     |___/                     |___/ 
// File: FuzzyString/FuzzyString/JaroWinklerDistance.cs
// User: Adrian Hum/
// 
// Created:  2017-10-18 7:51 PM
// Modified: 2017-10-18 9:10 PM

using System;

namespace FuzzyString
{
    public static partial class ComparisonMetrics
    {
        public static double JaroWinklerDistance(this string source, string target)
        {
            var jaroDistance = source.JaroDistance(target);
            var commonPrefixLength = CommonPrefixLength(source, target);

            return jaroDistance + commonPrefixLength * 0.1 * (1 - jaroDistance);
        }

        public static double JaroWinklerDistanceWithPrefixScale(string source, string target, double p)
        {
            double prefixScale;

            if (p > 0.25) prefixScale = 0.25;
            else if (p < 0) prefixScale = 0;
            else prefixScale = p;

            var jaroDistance = source.JaroDistance(target);
            var commonPrefixLength = CommonPrefixLength(source, target);

            return jaroDistance + commonPrefixLength * prefixScale * (1 - jaroDistance);
        }

        private static double CommonPrefixLength(string source, string target)
        {
            var maximumPrefixLength = 4;
            var commonPrefixLength = 0;
            if (source.Length <= 4 || target.Length <= 4) maximumPrefixLength = Math.Min(source.Length, target.Length);

            for (var i = 0; i < maximumPrefixLength; i++)
                if (source[i].Equals(target[i])) commonPrefixLength++;
                else return commonPrefixLength;

            return commonPrefixLength;
        }
    }
}