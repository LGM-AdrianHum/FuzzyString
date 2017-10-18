//    ___                    __ _        _             
//   / __\   _ _________   _/ _\ |_ _ __(_)_ __   __ _ 
//  / _\| | | |_  /_  / | | \ \| __| '__| | '_ \ / _` |
// / /  | |_| |/ / / /| |_| |\ \ |_| |  | | | | | (_| |
// \/    \__,_/___/___|\__, \__/\__|_|  |_|_| |_|\__, |
//                     |___/                     |___/ 
// File: FuzzyString/FuzzyString/RatcliffObershelpSimilarity.cs
// User: Adrian Hum/
// 
// Created:  2017-10-18 7:51 PM
// Modified: 2017-10-18 8:56 PM

using System;
using System.Linq;

namespace FuzzyString
{
    public static partial class ComparisonMetrics
    {
        public static double RatcliffObershelpSimilarity(this string source, string target)
        {
            return 2 * Convert.ToDouble(source.Intersect(target).Count()) /
                   Convert.ToDouble(source.Length + target.Length);
        }
    }
}