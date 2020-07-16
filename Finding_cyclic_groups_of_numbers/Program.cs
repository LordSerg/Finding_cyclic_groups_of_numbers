using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finding_cyclic_groups_of_numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Input the group (example: (Z/20Z)* )");
            string s = Console.ReadLine();
            int n = 0;
            bool b = false;
            for (int i = 0; i < s.Length; i++)
            {
                if(s[i] >= '0'&& s[i] <= '9')
                {
                    n *= 10;
                    n += Convert.ToInt32(s[i] - '0');
                }
                if (s[i] == '*')
                    b = true;
            }
            if (b == true)
            {
                int length = 1;
                long[] nums = new long[n];
                nums[0] = 1;
                long x = 0;
                for (long i = 2; i < n; i++)
                {
                    x = NSK(i, n);
                    if (x == 1)
                    {
                        length++;
                        nums[length - 1] = i;
                    }
                }
                long[,] m;
                m = new long[length, length];
                for (int i = 0; i < length; i++)
                {
                    for (int j = 0; j < length; j++)
                    {
                        m[i, j] = nums[i] * nums[j] % n;
                    }
                }
                Console.WriteLine("Adjacency table:");
                string ss = n.ToString(), ss1;
                for (int i = 0; i < length; i++)
                {
                    if (i == 0)
                    {
                        for (int k = 0; k < ss.Length; k++)
                            Console.Write("_");
                        Console.Write("|");
                        for (int j = 0; j < length; j++)
                        {
                            Console.Write(m[i, j]);
                            ss1 = m[i, j].ToString();
                            for (int k = 0; k < 2 * ss.Length - ss1.Length; k++)
                                Console.Write("_");
                        }
                        Console.WriteLine();
                    }

                    ss1 = m[i, 0].ToString();
                    Console.Write(m[i, 0]);
                    for (int k = 0; k < ss.Length - ss1.Length; k++)
                        Console.Write(" ");
                    Console.Write("|");
                    for (int j = 0; j < length; j++)
                    {
                        Console.Write(m[i, j]);
                        ss1 = m[i, j].ToString();
                        for (int k = 0; k < 2 * ss.Length - ss1.Length; k++)
                            Console.Write(" ");
                    }
                    Console.WriteLine();
                }
            }
            else
            {
                long[,] m = new long[n, n];
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        m[i, j] = (i+j) % n;
                    }
                }
                Console.WriteLine("Adjacency table:");
                string ss = n.ToString(), ss1;
                for (int i = 0; i < n; i++)
                {
                    if (i == 0)
                    {
                        for (int k = 0; k < ss.Length; k++)
                            Console.Write("_");
                        Console.Write("|");
                        for (int j = 0; j < n; j++)
                        {
                            Console.Write(m[i, j]);
                            ss1 = m[i, j].ToString();
                            for (int k = 0; k < 2 * ss.Length - ss1.Length; k++)
                                Console.Write("_");
                        }
                        Console.WriteLine();
                    }

                    ss1 = m[i, 0].ToString();
                    Console.Write(m[i, 0]);
                    for (int k = 0; k < ss.Length - ss1.Length; k++)
                        Console.Write(" ");
                    Console.Write("|");
                    for (int j = 0; j < n; j++)
                    {
                        Console.Write(m[i, j]);
                        ss1 = m[i, j].ToString();
                        for (int k = 0; k < 2 * ss.Length - ss1.Length; k++)
                            Console.Write(" ");
                    }
                    Console.WriteLine();
                }
            }
            Console.ReadKey();
        }
        static long NSK(long a, long b)
        {
            if (a != 0 && b != 0)
            {
                long k = Math.Abs(a), p = Math.Abs(b);
                if (Math.Abs(a) > Math.Abs(b))
                {
                    k = Math.Abs(b);
                    p = Math.Abs(a);
                }
                do
                {
                    k += p;
                    p = k - p;
                    k -= p;
                    k -= (k / p) * p;//остаток
                                     //k=max, p=min
                }
                while (k > 0);
                return p;
            }
            else
            {
                if (a != 0 || b != 0)
                {
                    if (a == 0)
                        return Math.Abs(b);
                    else
                        return Math.Abs(a);
                }
                else
                {
                    return 0;
                }
            }
        }
    }
}
