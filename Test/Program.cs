using System;

namespace Test // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        public static void miniMaxSum(List<int> arr)
        {
            int size = arr.Count;
            List<int> arr1 = new List<int>();
            int sum = 0;

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    if (i != j)
                    {
                        sum += arr[j];
                    }
                }

                arr1.Add(sum);
                sum = 0;
            }

            int min = arr1.Min();

            int max = arr1.Max();

            Console.WriteLine(min + " " + max);


        }

        public static string TimeConversion(string s)
        {
            int hours = int.Parse(s.Substring(0, 2));
            int minutes = int.Parse(s.Substring(3, 2));
            int seconds = int.Parse(s.Substring(6, 2));
            string period = s.Substring(8, 2);

            if (period == "PM" && hours != 12)
            {
                hours += 12;
            }
            else if (period == "AM" && hours == 12)
            {
                hours = 0;
            }

            string formattedTime = $"{hours:D2}:{minutes:D2}:{seconds:D2}";
            return formattedTime;
        }

        static void Main(string[] args)
        {
           string name =  TimeConversion("07:05:45PM");
            Console.WriteLine(name);


            var arr = new List<int>() {1,2,3,4,5 };
            miniMaxSum(arr);  

            Console.WriteLine("Hello World!");
        }
    }
}