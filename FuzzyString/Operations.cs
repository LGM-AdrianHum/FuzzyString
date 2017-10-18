//    ___                    __ _        _             
//   / __\   _ _________   _/ _\ |_ _ __(_)_ __   __ _ 
//  / _\| | | |_  /_  / | | \ \| __| '__| | '_ \ / _` |
// / /  | |_| |/ / / /| |_| |\ \ |_| |  | | | | | (_| |
// \/    \__,_/___/___|\__, \__/\__|_|  |_|_| |_|\__, |
//                     |___/                     |___/ 
// File: FuzzyString/FuzzyString/Operations.cs
// User: Adrian Hum/
// 
// Created:  2017-10-18 7:51 PM
// Modified: 2017-10-18 8:56 PM

using System.Collections.Generic;
using System.Linq;

namespace FuzzyString
{
    public static class Operations
    {
        public static string Capitalize(this string source)
        {
            return source.ToUpper();
        }

        public static string[] SplitIntoIndividualElements(string source)
        {
            var stringCollection = new string[source.Length];

            for (var i = 0; i < stringCollection.Length; i++)
                stringCollection[i] = source[i].ToString();

            return stringCollection;
        }

        public static string MergeIndividualElementsIntoString(IEnumerable<string> source)
        {
            var returnString = "";

            var enumerable = source as string[] ?? source.ToArray();
            var count = enumerable.Count();
            for (var i = 0; i < count; i++)
                returnString += enumerable.ElementAt(i);
            return returnString;
        }

        public static List<string> ListPrefixes(this string source)
        {
            var prefixes = new List<string>();

            for (var i = 0; i < source.Length; i++)
                prefixes.Add(source.Substring(0, i));

            return prefixes;
        }

        public static List<string> ListBiGrams(this string source)
        {
            return ListNGrams(source, 2);
        }

        public static List<string> ListTriGrams(this string source)
        {
            return ListNGrams(source, 3);
        }

        public static List<string> ListNGrams(this string source, int n)
        {
            var nGrams = new List<string>();

            if (n > source.Length)
                return null;
            if (n == source.Length)
            {
                nGrams.Add(source);
                return nGrams;
            }
            for (var i = 0; i < source.Length - n; i++)
                nGrams.Add(source.Substring(i, n));

            return nGrams;
        }
    }
}