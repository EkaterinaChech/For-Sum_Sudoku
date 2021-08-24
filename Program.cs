using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Microsoft.VisualBasic.CompilerServices;

namespace Split
{
    class Program
    {
        private static void PrintIfCorrect(List<int> list, int n)
        {
            if (list.Sum() == n)
            {
                foreach (var l in list)
                    Console.Write(l + " ");
                Console.WriteLine();
            }
        }

        private static bool Combine(ref List<int> a, int n, int length)
        {
            int k = length;
            for (int i = k - 1; i >= 0; --i)
                if (a[i] < n - k + i + 1)
                {
                    ++a[i];
                    for (int j = i + 1; j < k; ++j)
                        a[j] = a[j - 1] + 1;
                    return true;
                }

            return false;
        }

        private static void Run(int n, int length)
        {
            List<int> mas = new List<int>() {1, 2, 3, 4, 5, 6, 7, 8, 9};
            List<int> res = mas.GetRange(0, length);
            PrintIfCorrect(res, n);
            while (Combine(ref res, mas.Count, length))
            {
                PrintIfCorrect(res, n);
            }
        }

        public static void Main(string[] args)
        {
            int n = 0, length = 0;
            int input = 1;
            while (input != 0)
            {
                Console.WriteLine("Enter 1 to Run;\nEnter 0 to exit.");

                switch ((input) = int.Parse(Console.ReadLine()))
                {
                    case 0:
                        break;
                    default:
                        Console.WriteLine("Enter N:");
                        n = int.Parse(Console.ReadLine());
                        Console.WriteLine("Enter length:");
                        length = int.Parse(Console.ReadLine());
                        Run(n, length);
                        break;
                }
            }
        }
    }
}