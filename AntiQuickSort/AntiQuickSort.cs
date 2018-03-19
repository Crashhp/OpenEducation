using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntiQuickSort
{
    class Program
    {
        static void Main(string[] args)
        {
            string fileString = File.ReadAllText("input.txt");
            int n = int.Parse(fileString);

            int[] a = new int[n];

            using (StreamWriter file = new StreamWriter("output.txt"))
            {
                int i = 0;
                if (n == 1) a[0] = 1;
                if (n == 2)
                {
                    a[0] = 1;
                    a[1] = 2;
                }
                if (n > 2)
                {
                    a[0] = 1; a[1] = 2;
                    for (int j = 2; j < n; j++)
                    {
                        a[j] = a[j / 2];
                        a[j / 2] = j + 1;
                    }
                }

                for (int k = 0; k < n; k++)
                    file.Write("{0} ", a[k]);
            }
        }
    }
}
