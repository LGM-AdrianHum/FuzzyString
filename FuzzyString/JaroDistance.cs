//    ___                    __ _        _             
//   / __\   _ _________   _/ _\ |_ _ __(_)_ __   __ _ 
//  / _\| | | |_  /_  / | | \ \| __| '__| | '_ \ / _` |
// / /  | |_| |/ / / /| |_| |\ \ |_| |  | | | | | (_| |
// \/    \__,_/___/___|\__, \__/\__|_|  |_|_| |_|\__, |
//                     |___/                     |___/ 
// File: FuzzyString/FuzzyString/JaroDistance.cs
// User: Adrian Hum/
// 
// Created:  2017-10-18 7:51 PM
// Modified: 2017-10-18 8:56 PM

using System.Linq;

namespace FuzzyString
{
    public static partial class ComparisonMetrics
    {
        public static double JaroDistance(this string source, string target)
        {
            var m = source.Intersect(target).Count();

            if (m == 0) return 0;
            var sourceIntersectTarget = source.Intersect(target);
            var targetIntersectSource = target.Intersect(source);
            var sourceTargetIntersetAsString =
                sourceIntersectTarget.Aggregate("", (current, character) => current + character);
            var targetSourceIntersetAsString =
                targetIntersectSource.Aggregate("", (current, character) => current + character);
            // ReSharper disable once PossibleLossOfFraction
            double t = sourceTargetIntersetAsString.LevenshteinDistance(targetSourceIntersetAsString) / 2;
            return (m / source.Length + m / target.Length + (m - t) / m) / 3;
        }
    }
}