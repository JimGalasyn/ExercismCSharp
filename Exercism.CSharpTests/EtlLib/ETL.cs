// Solution to exercism problem: charp / ETL
// http://exercism.io/exercises/csharp/etl/readme
// Copyright (c) 2016 James P. Galasyn

using System.Collections.Generic;

namespace EtlLib
{
    /// <summary>
    /// Contains static methods for transforming a Scrabble letter/score dictionary.
    /// </summary>
    public class ETL
    {
        /// <summary>
        /// Converts a Scrabble letter/score dictionary from an "old" format to a "new" format.
        /// </summary>
        /// <param name="toConvert">The dictionary to convert.</param>
        /// <returns>The converted dictionary.</returns>
        public static Dictionary<string, int> Transform(Dictionary<int, IList<string>> toConvert)
        {
            // Create the dictionary that holds the converted format.
            Dictionary<string, int> converted = new Dictionary<string, int>();

            // Make sure there's work to do.
            if (toConvert != null && toConvert.Count > 0)
            {
                // Iterate over the source dictionary's key list.
                foreach (int score in toConvert.Keys)
                {
                    // Get the list of letters that corresponds with the key.
                    var list = toConvert[score];

                    // Populate the new dictionary by iterating over the letters.
                    foreach (var letter in list)
                    {
                        // The new format requires letters to be in lower case.
                        var newLetter = letter.ToLower();

                        // Check to make sure that the letter hasn't been added already.
                        if(!converted.ContainsKey(newLetter))
                        {
                            // Add the letter to the new dictionary and assign its score value.
                            converted[newLetter] = score;
                        }
                    }
                }
            }

            return converted;
        }
    }
}