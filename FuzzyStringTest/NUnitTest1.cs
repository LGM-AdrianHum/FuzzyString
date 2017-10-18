//    ___                    __ _        _             
//   / __\   _ _________   _/ _\ |_ _ __(_)_ __   __ _ 
//  / _\| | | |_  /_  / | | \ \| __| '__| | '_ \ / _` |
// / /  | |_| |/ / / /| |_| |\ \ |_| |  | | | | | (_| |
// \/    \__,_/___/___|\__, \__/\__|_|  |_|_| |_|\__, |.TEST
//                     |___/                     |___/ 
// File: FuzzyString/FuzzyStringTest/NUnitTest1.cs
// User: Adrian Hum/
// 
// Created:  2017-10-18 9:01 PM
// Modified: 2017-10-18 9:10 PM

using System.Collections.Generic;
using FuzzyString;
using NUnit.Framework;

//using NUnit.Framework;

namespace FuzzyStringTest
{
    [TestFixture]
    public class FuzzyString
    {
        public string TestString1 = "Kyven Smythe";

        public string TestString2 = "Kevin Smith";

        public string TestString3 = "Alexander Dumas";

        [Test]
        public void GeneralTest()
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

            Assert.IsTrue(kevin.ApproximatelyEquals(kevyn, FuzzyStringComparisonTolerance.Weak, options.ToArray()));
            Assert.IsTrue(
                kevin.ApproximatelyEquals(kevyn, FuzzyStringComparisonTolerance.Normal, options.ToArray()));
            Assert.IsTrue(
                kevin.ApproximatelyEquals(kevyn, FuzzyStringComparisonTolerance.Strong, options.ToArray()));
        }

        [Test]
        public void GetHammingDistance()
        {
            var l = TestString1.HammingDistance(TestString2);
            Assert.AreNotEqual(l, 0);
        }
    }
}