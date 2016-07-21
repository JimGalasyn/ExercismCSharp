// Solution to exercism problem: charp / hamming
// http://exercism.io/exercises/csharp/hamming/readme
// Copyright (c) 2016 James P. Galasyn
// This project is licensed under the terms of the MIT license.

using System;

namespace HammingLib
{
    /// <summary>
    /// Contains static methods for computing the Hamming distance between DNA sequences.
    /// </summary>
    public class Hamming
    {
        /// <summary>
        /// Calculates the Hamming distance between the specified DNA sequences.
        /// </summary>
        /// <param name="lhs">The first sequence to compare.</param>
        /// <param name="rhs">The second sequence to compare.</param>
        /// <returns>The Hamming distance between <paramref name="lhs"/> and <paramref name="rhs"/>.</returns>
        /// <remarks>
        /// The Hamming distance is found by comparing two DNA strands and 
        /// counting how many of the nucleotides are different from their 
        /// equivalent in the other string.
        ///
        /// GAGCCTACTAACGGGAT
        /// CATCGTAATGACGGCCT
        /// ^ ^ ^  ^ ^    ^^
        ///
        /// The Hamming distance between these two DNA strands is 7.
        /// TODO: Could be implemented as a proper <see cref="IEqualityComparer"/>.
        /// </remarks>
        public static int Compute(string lhs, string rhs)
        {
            int hammingDistance = 0;

            // Check inputs.
            if (!String.IsNullOrEmpty(lhs) && !String.IsNullOrEmpty(rhs))
            {
                // Sequences must have the same length.
                if (lhs.Length == rhs.Length)
                {
                    // Iterate over the first string and compare
                    // character-by-character with the second string.
                    for (int i = 0; i < lhs.Length; i++)
                    {
                        // Increment the Hamming distance 
                        // if the characters are different.
                        if (lhs[i] != rhs[i])
                        {
                            hammingDistance++;
                        }
                    }
                }
                else
                {
                    throw new ArgumentException("must have the same length", "lhs and rhs");
                }
            }

            return hammingDistance;
        }
    }
}
