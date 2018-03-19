using System;
using System.IO;

namespace Program
{
    class Program
    {
        static void Main(string[] args)
        {
            int i, j;
            string fileString = File.ReadAllText("input.txt");
            string[] intStrings = fileString.Split(new char[] { ' ', '\t', '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);

            int length = int.Parse(intStrings[0]);

            int[] arr = new int[length];
            for (i = 0; i < length; i++)
                arr[i] = int.Parse(intStrings[i + 1]);

            int[] c = new int[length];

            using (StreamWriter file = new StreamWriter("output.txt"))
            {
                int i1 = 0, i2 = 0, j1 = 0, j2 = 0;
                long num = 0;
                for (i = 1; i < length; i *= 2)
                {
                    for (j = 0; j < length - 2 * i + 1; j += 2 * i)
                    {
                        j2 = j + 2 * i - 1;
                        MergeSort(ref arr, j, j + i - 1, j + i, j2, ref c, ref num);
                    }

                }

                bool q = false;
                for (i = 1; i < length; i *= 2)
                {
                    if ((length & i) == i)
                    {
                        if (q)
                        {
                            i2 = j1 - 1;
                            i1 = j1 - i;
                            MergeSort(ref arr, i1, i2, j1, j2, ref c, ref num);
                            j1 = i1;
                        }
                        else
                        {
                            q = true;
                            j2 = length - 1;
                            j1 = length - i;
                        }
                    }
                }

                file.Write("{0}", num);
            }
        }

        public static void MergeSort(ref int[] a, int i1, int i2, int j1, int j2, ref int[] outA, ref long Num)
        {
            int i = i1, j = j1, k = i1;
            int n = i2 + 1;
            int m = j2 + 1;
            while (i < n || j < m)
            {
                if (j == m || (i < n && a[i] <= a[j]))
                {
                    outA[k] = a[i];
                    i++;
                }
                else
                {
                    outA[k] = a[j];
                    if (i < n) Num += n - i;
                    j++;
                }
                k++;
            }

            for (i = i1; i <= i2; i++)
                a[i] = outA[i];

            for (j = j1; j <= j2; j++)
                a[j] = outA[j];
        }
    }
}
