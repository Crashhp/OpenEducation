using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecretarySwap
{
    public static class Extensions
    {
        public static int Min(this int[] x, int from)
        {
            int result = -1;
            int minValue = int.MaxValue;
            for (int i = from; i < x.Length; i++)
                if (x[i] < minValue)
                {
                    minValue = x[i];
                    result = i;
                }
            return result;
        }

        public static string GetLastHalf(string text)
        {
            var str = text.Skip(text.Length / 2).ToString();
            return str;
        }
    }

    class SecretarySwap
    {
        static void Main(string[] args)
        {
            try
            {
                int i, j, key;
                string fileString = File.ReadAllText("input.txt");
                string[] intStrings = fileString.Split(new char[] { ' ', '\t', '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);

                int length = int.Parse(intStrings[0]);

                int[] arr = new int[length];
                for (i = 0; i < length; i++)
                    arr[i] = int.Parse(intStrings[i + 1]);

                using (StreamWriter file = new StreamWriter("output.txt"))
                {
                    for (i = 0; i < length; i++)
                    {
                        j = arr.Min(i);

                        if (j > 0 && i != j)
                        {
                            key = arr[j];
                            arr[j] = arr[i];
                            arr[i] = key;
                            file.WriteLine("Swap elements at indices {0} and {1}.", i + 1, j + 1);
                        }
                    }

                    file.WriteLine("No more swaps needed.");
                    for (i = 0; i < length; i++)
                        file.Write(arr[i].ToString() + " ");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
