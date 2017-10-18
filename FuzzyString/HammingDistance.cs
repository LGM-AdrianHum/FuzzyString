//    ___                    __ _        _             
//   / __\   _ _________   _/ _\ |_ _ __(_)_ __   __ _ 
//  / _\| | | |_  /_  / | | \ \| __| '__| | '_ \ / _` |
// / /  | |_| |/ / / /| |_| |\ \ |_| |  | | | | | (_| |
// \/    \__,_/___/___|\__, \__/\__|_|  |_|_| |_|\__, |
//                     |___/                     |___/ 
// File: FuzzyString/FuzzyString/HammingDistance.cs
// User: Adrian Hum/
// 
// Created:  2017-10-18 7:51 PM
// Modified: 2017-10-18 9:10 PM

using System.Linq;

namespace FuzzyString
{
    public static partial class ComparisonMetrics
    {
        public static int HammingDistance(this string source, string target)
        {
            return source.Length != target.Length ? 99999 : source.Where((t, i) => !t.Equals(target[i])).Count();
        }
    }
}