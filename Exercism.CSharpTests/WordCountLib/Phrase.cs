// Solution to exercism problem: charp / word-count
// http://exercism.io/exercises/csharp/word-count/readme
// Copyright (c) 2016 James P. Galasyn
// This project is licensed under the terms of the MIT license.

using System;
using System.Collections.Generic;
using System.Linq;

namespace WordCountLib
{
    /// <summary>
    /// Contains static methods for splitting a phrase into its component words.
    /// </summary>
    public class Phrase
    {
        /// <summary>
        /// Counts the number of times each word appears in a phrase.
        /// </summary>
        /// <param name="phrase">The phrase to analyze.</param>
        /// <returns>A dictionary of word counts.</returns>
        public static Dictionary<string, int> WordCount(string phrase)
        {
            // Create the dictionary that holds the word counts.
            Dictionary<string, int> wordCounts = new Dictionary<string, int>();

            // Remove the non-alphanumeric characters. Spaces and commas are retained.
            var phraseScrubbed = FilterNonAlpha(phrase);

            // Split the phrase into component words.
            var words = phraseScrubbed.Split(new[] {' ', ',' });

            // The previous Split operation produces spurious empty words, so remove these.
            var wordsScrubbed = words.Where(w => !String.IsNullOrWhiteSpace(w));

            // Iterate over the word list and add words to the dictionary.
            foreach (var word in wordsScrubbed)
            {
                // Words may have spurious apostrophes, so remove these.
                string scrubbedWord = ScrubWord(word);
                if (scrubbedWord != String.Empty)
                {
                    // Add the word and its count to the dictionary.
                    if (wordCounts.ContainsKey(scrubbedWord))
                    {
                        wordCounts[scrubbedWord]++;
                    }
                    else
                    {
                        wordCounts[scrubbedWord] = 1;
                    }
                }
            }

            return wordCounts;
        }

        /// <summary>
        /// Removes spurious apostrophes from the specified word.
        /// </summary>
        /// <param name="word">The word to scrub.</param>
        /// <returns>The scrubbed word.</returns>
        /// <remarks>This method also converts the word to lower case.</remarks>
        private static string ScrubWord(string word)
        {
            string wordLowerCase = word.ToLower();
            string wordScrubbed = wordLowerCase;

            // Trim opening and closing apostrophes. 
            // TODO: Fails with plural-possessive words that end in an apostrophe.

            if (wordLowerCase.StartsWith("\'"))
            {
                wordScrubbed = wordLowerCase.Remove(0, 1);
            }

            if (wordScrubbed.EndsWith("\'"))
            {
                wordScrubbed = wordScrubbed.Remove(wordScrubbed.Length-1, 1);
            }
            
            return wordScrubbed;
        }

        /// <summary>
        /// Filters non-alphanumeric characters from the specified string.
        /// </summary>
        /// <param name="str">The string to filter.</param>
        /// <returns>The filtered string.</returns>
        /// <remarks>Apostrophes and commas are retained.
        /// Adapted from: How do I remove all non alphanumeric characters from a string except dash?
        /// http://stackoverflow.com/questions/3210393/how-do-i-remove-all-non-alphanumeric-characters-from-a-string-except-dash
        /// </remarks>
        private static string FilterNonAlpha(string str)
        {
            char[] charArray = str.ToCharArray();

            charArray = Array.FindAll<char>(charArray, (c =>
            (char.IsLetterOrDigit(c) || char.IsWhiteSpace(c) || c == '\'' || c == ',')));

            string retval = new string(charArray);

            return retval;
        }
    }
}
