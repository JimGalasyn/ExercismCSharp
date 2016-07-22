using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordCountLib
{
    public class Phrase
    {
        public static Dictionary<string, int> WordCount(string phrase)
        {
            Dictionary<string, int> wordCounts = new Dictionary<string, int>();

            var phraseScrubbed = FilterNonAlpha(phrase);

            var words = phraseScrubbed.Split(new[] {' ', ',' });
            var wordsScrubbed = words.Where(w => !String.IsNullOrWhiteSpace(w));

            foreach (var word in wordsScrubbed)
            {
                string scrubbedWord = ScrubWord(word);
                if (scrubbedWord != String.Empty)
                {
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
