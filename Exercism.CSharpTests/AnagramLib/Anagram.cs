// Solution to exercism problem: charp / anagram
// http://exercism.io/exercises/csharp/anagram/readme
// Copyright (c) 2016 James P. Galasyn

using System;
using System.Collections.Generic;
using System.Linq;

namespace AnagramLib
{
    /// <summary>
    /// Implements an anagram test for a list of strings.
    /// </summary>
    public class Anagram
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Anagram"/> class to the specified string.
        /// </summary>
        /// <param name="source"></param>
        public Anagram(string source)
        {
            if (!String.IsNullOrEmpty(source))
            {
                SourceString = source;
            }
            else
            {
                throw new ArgumentException("must be assigned and non-empty", "source");
            }
        }

        /// <summary>
        /// Tests the specified collection of strings against <see cref="SourceString"/>. 
        /// </summary>
        /// <param name="toMatch">The strings to match.</param>
        /// <returns>The strings that are anagrams of <see cref="SourceString"/>.</returns>
        public string[] Match(string[] toMatch)
        {
            string[] matchesArray = null;

            if (toMatch != null && toMatch.Length > 0)
            {
                var matches = toMatch.Where(s => IsAnagram(SourceString, s));
                matchesArray = matches.ToArray();
            }

            return matchesArray;
        }

        /// <summary>
        /// Determines whether the specified string is an anagram of a source string.
        /// </summary>
        /// <param name="source">The string to test against.</param>
        /// <param name="toTest">The string to test as an anagram of <paramref name="source"/>.</param>
        /// <returns>true, if <paramref name="toTest"/> is an anagram of <paramref name="source"/>; otherwise, false.</returns>
        private bool IsAnagram(string source, string toTest)
        {
            bool retval = false;

            // Check the inputs for null and empty strings.
            if (!String.IsNullOrEmpty(source) && !String.IsNullOrEmpty(toTest))
            {
                // Anagrams must have the same length.
                if (source.Length == toTest.Length)
                {
                    // Anagrams can't be the same string.
                    if (source.ToLower() != toTest.ToLower())
                    {
                        // Populate dictionaries that represent both words as character counts.
                        var sourceDictionary = CountChars(source);
                        var toTestDictionary = CountChars(toTest);

                        // If the dictionaries have the same content, the words are anagrams.
                        retval = IsEqual(sourceDictionary, toTestDictionary);
                    }
                }
            }

            return retval;
        }

        /// <summary>
        /// Populates a dictionary that represents the specified string 
        /// by using character counts.
        /// </summary>
        /// <param name="str">The string to represent.</param>
        /// <returns>The dictionary that represents <paramref name="str"/>.</returns>
        /// <remarks>The string is represented as a map of chars to ints. Each char has a
        /// corresponding count value. For example, the word "BobDobbs" is represented like this:
        /// b: 4
        /// d: 1
        /// o: 2
        /// s: 1
        /// Words are anagrams if they have the same character counts. 
        /// </remarks>
        private Dictionary<char, int> CountChars(string str)
        {
            // Create the dictionary that represents the string.
            Dictionary<char, int> charDictionary = new Dictionary<char, int>();

            // Populate the dictionary by iterating over the characters 
            // in the string and counting their frequency along the way.
            foreach (char c in str)
            {
                // Anagrams are case-insensitive.
                char cLowerCase = char.ToLower(c);

                // Increment for character count or add a new character, 
                // if it's not already in the dictionary. 
                if (charDictionary.ContainsKey(cLowerCase))
                {
                    charDictionary[cLowerCase]++;
                }
                else
                {
                    charDictionary[cLowerCase] = 1;
                }
            }

            return charDictionary;
        }

        /// <summary>
        /// Determines whether the specified dictionaries have the same content.
        /// </summary>
        /// <param name="lhs">The first dictionary to compare.</param>
        /// <param name="rhs">The second dictionary to compare.</param>
        /// <returns>true, if <paramref name="lhs"/> and <paramref name="rhs"/> have 
        /// the same content; otherwise, false.</returns>
        /// <remarks>TODO: Sould be implemented as a proper <see cref="IEqualityComparer"/>.</remarks>
        private bool IsEqual(Dictionary<char, int> lhs, Dictionary<char, int> rhs)
        {
            bool retval = false;

            // Check inputs.
            if (lhs != null && rhs != null && lhs != rhs)
            {
                // Equal dictionaries must have the same number of entries.
                if (lhs.Count == rhs.Count)
                {
                    // Check that the same keys are present in both dictionaries.
                    // Adapted from: http://stackoverflow.com/questions/21758074/c-sharp-compare-two-dictionaries-for-equality
                    if (!lhs.Keys.Except(rhs.Keys).Any() &&
                        !rhs.Keys.Except(lhs.Keys).Any())
                    {
                        retval = true; // TODO: This is a bit of a hack.

                        // Check that the values are equal in both dictionaries.
                        foreach (var kvp in lhs)
                        {
                            if(kvp.Value != rhs[kvp.Key])
                            {
                                retval = false;
                                break;
                            }
                        }
                    }
                }
            }

            return retval;
        }

        /// <summary>
        /// Gets the string to be tested against for anagrams. 
        /// </summary>
        public string SourceString { get; private set; }
    }
}
