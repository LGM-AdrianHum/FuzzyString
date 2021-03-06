﻿//    ___                    __ _        _             
//   / __\   _ _________   _/ _\ |_ _ __(_)_ __   __ _ 
//  / _\| | | |_  /_  / | | \ \| __| '__| | '_ \ / _` |
// / /  | |_| |/ / / /| |_| |\ \ |_| |  | | | | | (_| |
// \/    \__,_/___/___|\__, \__/\__|_|  |_|_| |_|\__, |
//                     |___/                     |___/ 
// File: FuzzyString/FuzzyStringConsole/Program.cs
// User: Adrian Hum/
// 
// Created:  2017-10-18 7:51 PM
// Modified: 2017-10-18 9:10 PM

using System;
using System.Collections.Generic;
using FuzzyString;

namespace FuzzyStringConsole
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var kevin = "kevin";
            var kevyn = "kevyn";

            var options = new List<FuzzyStringComparisonOptions>
            {
                FuzzyStringComparisonOptions.UseJaccardDistance,
                FuzzyStringComparisonOptions.UseNormalizedLevenshteinDistance,
                FuzzyStringComparisonOptions.UseOverlapCoefficient,
                FuzzyStringComparisonOptions.UseLongestCommonSubsequence,
                FuzzyStringComparisonOptions.CaseSensitive
            };

            Console.WriteLine(kevin.ApproximatelyEquals(kevyn, FuzzyStringComparisonTolerance.Weak, options.ToArray()));
            Console.WriteLine(
                kevin.ApproximatelyEquals(kevyn, FuzzyStringComparisonTolerance.Normal, options.ToArray()));
            Console.WriteLine(
                kevin.ApproximatelyEquals(kevyn, FuzzyStringComparisonTolerance.Strong, options.ToArray()));

            Console.ReadLine();
        }
    }
}