using System;


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
}