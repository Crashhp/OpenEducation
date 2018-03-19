using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsertSorting
{
    class Program
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

                // 1 8 4 2 3 7 5 6 9 0

                int[] swap = new int[length];
                swap[0] = 1;
                for (j = 1; j < length; j++)
                {
                    key = arr[j];
                    i = j - 1;
                    while (i > -1 && arr[i] > key)
                        arr[i + 1] = arr[i--];
                    arr[i + 1] = key;
                    swap[j] = i + 2;
                }

                using (StreamWriter file = new StreamWriter("output.txt"))
                {
                    for (i = 0; i < length; i++)
                        file.Write(swap[i].ToString() + " ");

                    file.WriteLine();

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
