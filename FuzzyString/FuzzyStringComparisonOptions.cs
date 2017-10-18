//    ___                    __ _        _             
//   / __\   _ _________   _/ _\ |_ _ __(_)_ __   __ _ 
//  / _\| | | |_  /_  / | | \ \| __| '__| | '_ \ / _` |
// / /  | |_| |/ / / /| |_| |\ \ |_| |  | | | | | (_| |
// \/    \__,_/___/___|\__, \__/\__|_|  |_|_| |_|\__, |
//                     |___/                     |___/ 
// File: FuzzyString/FuzzyString/FuzzyStringComparisonOptions.cs
// User: Adrian Hum/
// 
// Created:  2017-10-18 7:51 PM
// Modified: 2017-10-18 9:10 PM

namespace FuzzyString
{
    public enum FuzzyStringComparisonOptions
    {
        UseHammingDistance,

        UseJaccardDistance,

        UseJaroDistance,

        UseJaroWinklerDistance,

        UseLevenshteinDistance,

        UseLongestCommonSubsequence,

        UseLongestCommonSubstring,

        UseNormalizedLevenshteinDistance,

        UseOverlapCoefficient,

        UseRatcliffObershelpSimilarity,

        UseSorensenDiceDistance,

        UseTanimotoCoefficient,

        CaseSensitive
    }
}