// Solution to exercism problem: charp / leap
// http://exercism.io/exercises/csharp/leap/readme
// Copyright (c) 2016 James P. Galasyn
namespace LeapYearLib
{
    /// <summary>
    /// Contains static methods for computing leap years.
    /// </summary>
    public class Year
    {
        /// <summary>
        /// Determines whether the spcified year is a leap year.
        /// </summary>
        /// <param name="year">The year to test.</param>
        /// <returns>true, if <paramref name="year"/> is a leap year; otherwise, false.</returns>
        /// <remarks>Implements this logic for deciding on leap years:
        /// on every year that is evenly divisible by 4
        ///     except every year that is evenly divisible by 100
        ///         unless the year is also evenly divisible by 400 
        /// </remarks>
        public static bool IsLeap(int year)
        {
            // TODO: Validate input.

            bool isDivisibleBy4 = (year % 4 == 0);
            bool isDivisibleBy100 = (year % 100 == 0);
            bool isDivisibleBy400 = (year % 400 == 0);

            bool isLeapYear = isDivisibleBy4 && (!isDivisibleBy100 || isDivisibleBy400);

            return isLeapYear;
        }
    }
}
