using System;
using System.Diagnostics.Metrics;
using System.Globalization;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading;
using static System.Net.Mime.MediaTypeNames;


//Problem Statement
/*
Two children, Lily and Ron, want to share a chocolate bar. Each of the squares has an integer on it.

Lily decides to share a contiguous segment of the bar selected such that:

The length of the segment matches Ron's birth month, and,
The sum of the integers on the squares is equal to his birth day.
Determine how many ways she can divide the chocolate.

Example:
    S= [2,2,1,3,2]
    d=4
    m=2
*/

namespace SubarrayDivision 
{
    class Result
    {
        public static int birthday(List<int> s, int d, int m)
        {
            int count = 0;

            for (int i = 0; i <= s.Count - m; i++)
            {
                int sum = 0;

                for (int j = 0; j < m; j++)
                {
                    sum += s[i + j];
                }
                if (sum == d)
                {
                    count++;
                }
            }
            return count;
        }

    }
    internal class Program
    {
        static void Main(string[] args)
        {
            TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

            int n = Convert.ToInt32(Console.ReadLine().Trim());

            List<int> s = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(sTemp => Convert.ToInt32(sTemp)).ToList();

            string[] firstMultipleInput = Console.ReadLine().TrimEnd().Split(' ');

            int d = Convert.ToInt32(firstMultipleInput[0]);

            int m = Convert.ToInt32(firstMultipleInput[1]);

            int result = Result.birthday(s, d, m);

            textWriter.WriteLine(result);

            textWriter.Flush();
            textWriter.Close();
        }
    }


    //Divisible Sum Pairs
    //Problem Statement:
    //Given an array of integers and a positive integer k , determine the number of(i,j) pairs where i<j and ar[i] +ar[j] is divisible by k.

    // Example
    //ar = [1,2,3,4,5,6]
    //k = 5
    //Three pairs meet the criteria: [1,4], [2,3] and [4,6]
        public static int divisibleSumPairs(int n, int k, List<int> ar)
        {

            int count = 0;

            for (int i = 0; i < ar.Count - 1; i++)
            {

                for (int j = i + 1; j < ar.Count; j++)
                {

                    if ((ar[i] + ar[j]) % k == 0)
                    {
                        count++;
                    }
                }

            }

            return count;

        }

    // Migratory Birds
    //Given an array of bird sightings where every element represents a bird type id, determine the id of the most
    //frequently sighted type. If more than 1 type has been spotted that maximum amount, return the smallest of their ids.

    public static int migratoryBirds(List<int> arr)
    {
        Dictionary<int, int> birdTypeCounts = new Dictionary<int, int>();

        foreach (var num in arr)
        {
            if (birdTypeCounts.ContainsKey(num))
            {
                birdTypeCounts[num]++;
            }
            else
            {
                birdTypeCounts[num] = 1;
            }
        }

        int maxType = int.MaxValue;
        int maxCount = 0;

        foreach (var item in birdTypeCounts)
        {
            if (item.Value > maxCount || (item.Value == maxCount && item.Key < maxType))
            {
                maxCount = item.Value;
                maxType = item.Key;
            }
        }
        return maxType;
    }
    /*
    Marie invented a Time Machine and wants to test it by time-traveling to visit Russia on the Day of the Programmer(the 256th day of the year) during a year in the inclusive range from 1700 to 2700.

    From 1700 to 1917, Russia's official calendar was the Julian calendar; since 1919 they used the Gregorian calendar system. The transition from the Julian to Gregorian calendar system occurred in 1918, when the next day after January 31st was February 14th. This means that in 1918, February 14th was the 32nd day of the year in Russia.

    In both calendar systems, February is the only month with a variable amount of days; it has 29 days during a leap year, and 28 days during all other years.In the Julian calendar, leap years are divisible by 4; in the Gregorian calendar, leap years are either of the following:

    Divisible by 400.
    Divisible by 4 and not divisible by 100.
    Given a year,y , find the date of the 256th day of that year according to the official Russian calendar during that year.Then print it in the format dd.mm.yyyy, where dd is the two-digit day, mm is the two-digit month, and yyyy is .

    For example, the given year= 1984. 1984 is divisible by 4, so it is a leap year.The 256th day of a leap year after 1918 is September 12, so the answer is .12.09.1998
    */







}