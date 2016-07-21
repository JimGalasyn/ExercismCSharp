using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnagramLib
{
    public class Anagram
    {

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

        private bool IsAnagram(string source, string toTest)
        {
            bool retval = false;

            if (!String.IsNullOrEmpty(source) && !String.IsNullOrEmpty(toTest))
            {
                if (source.Length == toTest.Length)
                {
                    if (source.ToLower() != toTest.ToLower())
                    {
                        var sourceDictionary = CountChars(source);
                        var toTestDictionary = CountChars(toTest);

                        retval = IsEqual(sourceDictionary, toTestDictionary);
                    }
                }
            }

            return retval;
        }

        private Dictionary<char, int> CountChars(string str)
        {
            Dictionary<char, int> charDictionary = new Dictionary<char, int>();

            foreach (char c in str)
            {
                char cLowerCase = char.ToLower(c);
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


        private bool IsEqual(Dictionary<char, int> lhs, Dictionary<char, int> rhs)
        {
            bool retval = false;

            if (lhs != null && rhs != null && lhs != rhs)
            {
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

        public string SourceString { get; private set; }
    }
}
