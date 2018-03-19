using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sortland
{
    public class Citizen : IComparable
    {
        public int Number { get; set; }
        public float Money { get; set; }

        public Citizen(int number, float money)
        {
            Number = number;
            Money = money;
        }

        public int CompareTo(object obj)
        {
            return Money.CompareTo((obj as Citizen).Money);
        }
    }

    class Sortland
    {
        static void Main(string[] args)
        {
            int i, j;
            Citizen key;
            string fileString = File.ReadAllText("input.txt");
            string[] numStrings = fileString.Split(new char[] { ' ', '\t', '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);

            int length = int.Parse(numStrings[0]);

            Citizen[] arr = new Citizen[length];
            for (i = 0; i < length; i++)
            {
                arr[i] = new Citizen(i + 1, float.Parse(numStrings[i + 1], CultureInfo.InvariantCulture.NumberFormat));
            }

            for (j = 1; j < length; j++)
            {
                key = arr[j];
                i = j - 1;
                while (i > -1 && arr[i].CompareTo(key) > 0)
                    arr[i + 1] = arr[i--];
                arr[i + 1] = key;
            }

            using (StreamWriter file = new StreamWriter("output.txt"))
            {
                file.Write(arr[0].Number.ToString() + " ");
                file.Write(arr[length / 2].Number.ToString() + " ");
                file.Write(arr[length - 1].Number.ToString());
            }
        }
    }
}
