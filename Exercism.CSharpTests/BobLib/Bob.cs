// Solution to exercism problem: charp / bob
// http://exercism.io/exercises/csharp/bob/readme
// Copyright (c) 2016 James P. Galasyn

using System;

namespace BobLib
{
    /// <summary>
    /// Contains static methods for talking with Bob, a stereotypical "lackadaisical teenager".
    /// </summary>
    /// <remarks>
    ///  Bob answers 'Sure.' if you ask him a question.
    ///  He answers 'Whoa, chill out!' if you yell at him.
    ///  He says 'Fine. Be that way!' if you address him without actually saying anything.
    ///  He answers 'Whatever.' to anything else.
    /// </remarks>
    public class Bob
    {
        /// <summary>
        /// Tells Bob something. The returned string holds his reply.
        /// </summary>
        /// <param name="tellBob">The phrase to say to Bob.</param>
        /// <returns>Bob's reply.</returns>
        /// <remarks>The <see cref="Hey"/> method tests for three kinds of input:
        /// silence, yelling at Bob, and asking Bob a question. These tests are
        /// simple string manipulations without the sophistication of lexical or
        /// semantic analysis. Note that for the <see cref="Hey"/> method to work
        /// correctly, the <see cref="IsSilence(string)"/>, <see cref="IsYelling(string)"/>,
        /// and <see cref="IsQuestion(string)"/> methods must be called in this order.
        /// </remarks>
        public static string Hey(string tellBob)
        {
            // Initialize the return value to the default reply.
            string retval = Bob.defaultReply;

            // Trim leading and trailing whitespace.
            string tellBobTrimmed = tellBob.Trim();

            // Test the trimmed string for the three input types.
            // These calls are order-dependent.
            if (IsSilence(tellBobTrimmed))
            {
                retval = Bob.silenceReply;
            }
            else if (IsYelling(tellBobTrimmed))
            {
                retval = Bob.yellingReply;
            }
            else if (IsQuestion(tellBobTrimmed))
            {
                retval = Bob.questionReply;
            }

            return retval;
        }

        /// <summary>
        /// Determines whether the specified string is equivalent to silence.
        /// </summary>
        /// <param name="tellBob">The string to test for silence.</param>
        /// <returns>true, if <paramref name="tellBob"/> resolves to silence; otherwise, false.</returns>
        private static bool IsSilence(string tellBob)
        {
            bool isSilence = String.IsNullOrEmpty(tellBob);

            if (!isSilence)
            {
                isSilence =
                    (tellBob.Length == 1) &&
                    (!char.IsLetterOrDigit(tellBob[0]));
            }

            return isSilence;
        }

        /// <summary>
        /// Determines whether the specified string is equivalent to yelling.
        /// </summary>
        /// <param name="tellBob">The string to test for silence.</param>
        /// <returns>true, if <paramref name="tellBob"/> resolves to yelling; otherwise, false.</returns>
        private static bool IsYelling(string tellBob)
        {
            bool isYelling = false;

            string scrubbed = FilterNonAlpha(tellBob);
            if (!IsSilence(scrubbed))
            {
                string tellBobUppercase = tellBob.ToUpper();
                isYelling = (tellBobUppercase == tellBob);
            }

            return isYelling;
        }

        /// <summary>
        /// Determines whether the specified string is equivalent to asking a question.
        /// </summary>
        /// <param name="tellBob">The string to test for asking a question.</param>
        /// <returns>true, if <paramref name="tellBob"/> resolves to a question; otherwise, false.</returns>
        /// <remarks>Assumes that <paramref name="tellBob"/> has been trimmed and tested for
        /// yelling and being a question.</remarks>
        private static bool IsQuestion(string tellBob)
        {
            return tellBob.EndsWith("?");
        }

        /// <summary>
        /// Filters non-alphanumeric characters from the specified string.
        /// </summary>
        /// <param name="str">The string to filter.</param>
        /// <returns>The filtered string.</returns>
        /// <remarks>
        /// Adapted from: How do I remove all non alphanumeric characters from a string except dash?
        /// http://stackoverflow.com/questions/3210393/how-do-i-remove-all-non-alphanumeric-characters-from-a-string-except-dash
        /// </remarks>
        private static string FilterNonAlpha(string str)
        {
            char[] charArray = str.ToCharArray();

            charArray = Array.FindAll<char>(charArray, (c => (char.IsLetter(c))));

            string retval = new string(charArray);

            return retval;
        }

        // String constants.
        readonly static string defaultReply = "Whatever.";
        readonly static string silenceReply = "Fine. Be that way!";
        readonly static string yellingReply = "Whoa, chill out!";
        readonly static string questionReply = "Sure.";

    }
}