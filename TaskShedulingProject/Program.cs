using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskSchedulingProject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StreamWriter ourStream;
            ourStream = File.CreateText(@"C:\General\test.txt");
            ourStream.WriteLine("This is the task scheduler demo file is created at :" + DateTime.Now);
            ourStream.Close();
            Console.WriteLine("File created Successfully!");

            Console.ReadLine();
            Console.ReadKey();
        }
    }
}
