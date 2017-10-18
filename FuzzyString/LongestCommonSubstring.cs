//    ___                    __ _        _             
//   / __\   _ _________   _/ _\ |_ _ __(_)_ __   __ _ 
//  / _\| | | |_  /_  / | | \ \| __| '__| | '_ \ / _` |
// / /  | |_| |/ / / /| |_| |\ \ |_| |  | | | | | (_| |
// \/    \__,_/___/___|\__, \__/\__|_|  |_|_| |_|\__, |
//                     |___/                     |___/ 
// File: FuzzyString/FuzzyString/LongestCommonSubstring.cs
// User: Adrian Hum/
// 
// Created:  2017-10-18 7:51 PM
// Modified: 2017-10-18 9:10 PM

using System.Text;

namespace FuzzyString
{
    public static partial class ComparisonMetrics
    {
        public static string LongestCommonSubstring(this string source, string target)
        {
            if (string.IsNullOrEmpty(source) || string.IsNullOrEmpty(target)) return null;

            var l = new int[source.Length, target.Length];
            var maximumLength = 0;
            var lastSubsBegin = 0;
            var stringBuilder = new StringBuilder();

            for (var i = 0; i < source.Length; i++)
            for (var j = 0; j < target.Length; j++)
                if (source[i] != target[j])
                {
                    l[i, j] = 0;
                }
                else
                {
                    if (i == 0 || j == 0)
                        l[i, j] = 1;
                    else
                        l[i, j] = 1 + l[i - 1, j - 1];

                    if (l[i, j] <= maximumLength) continue;
                    maximumLength = l[i, j];
                    var thisSubsBegin = i - l[i, j] + 1;
                    if (lastSubsBegin == thisSubsBegin)
                    {
//if the current LCS is the same as the last time this block ran
                        stringBuilder.Append(source[i]);
                    }
                    else //this block resets the string builder if a different LCS is found
                    {
                        lastSubsBegin = thisSubsBegin;
                        stringBuilder.Length = 0; //clear it
                        stringBuilder.Append(source.Substring(lastSubsBegin, i + 1 - lastSubsBegin));
                    }
                }

            return stringBuilder.ToString();
        }
    }
}