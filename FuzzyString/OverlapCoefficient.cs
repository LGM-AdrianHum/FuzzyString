//    ___                    __ _        _             
//   / __\   _ _________   _/ _\ |_ _ __(_)_ __   __ _ 
//  / _\| | | |_  /_  / | | \ \| __| '__| | '_ \ / _` |
// / /  | |_| |/ / / /| |_| |\ \ |_| |  | | | | | (_| |
// \/    \__,_/___/___|\__, \__/\__|_|  |_|_| |_|\__, |
//                     |___/                     |___/ 
// File: FuzzyString/FuzzyString/OverlapCoefficient.cs
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
        public static double OverlapCoefficient(this string source, string target)
        {
            return Convert.ToDouble(source.Intersect(target).Count()) /
                   Convert.ToDouble(Math.Min(source.Length, target.Length));
        }
    }
}