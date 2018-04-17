using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingIntegerNumbers
{
    class SortingIntegerNumbers
    {
        static void Main(string[] args)
        {
            string fileString = File.ReadAllText("input.txt");
            string[] intStrings = fileString.Split(new char[] { ' ', '\t', '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);

            int n = int.Parse(intStrings[0]);
            int m = int.Parse(intStrings[1]);
            int i, j;

            //int[] arrN = new int[n];
            //int[] arrM = new int[m];
            //for (i = 0; i < n; i++)
            //    arrN[i] = int.Parse(intStrings[i + 2]);
            //for (i = 0; i < m; i++)
            //    arrM[i] = int.Parse(intStrings[i + 2 + n]);
            n = 6000;
            m = 1;
            Random r = new Random();
            int[] arrN = new int[n];
            int[] arrM = new int[m];
            for (i = 0; i < n; i += 2)
            {
                arrN[i] = i; //r.Next(1, 40000);
                arrN[i + 1] = arrN[i] + 1;
            }
            for (i = 0; i < m; i++)
                arrM[i] = 40000;

            int[] numN = new int[40001];
            int[] numM = new int[40001];

            for (i = 0; i < n; i++)
                numN[arrN[i]]++;

            for (i = 0; i < m; i++)
                numM[arrM[i]]++;

            List<Pair> N = new List<Pair>();
            List<Pair> M = new List<Pair>();
            List<Pair> NM = new List<Pair>();

            for (i = 1; i < 40001; i++)
            {
                if (numN[i] != 0)
                    N.Add(new Pair(i, numN[i]));

                if (numM[i] != 0)
                    M.Add(new Pair(i, numM[i]));
            }

            foreach (var n1 in N)
                foreach (var m1 in M)
                {
                    int val = n1.Value * m1.Value;
                    var find = NM.Find(t => t.Value == val);
                    if (find == null)
                    {
                        NM.Add(new Pair(val, n1.Number * m1.Number));
                    }
                    else
                    {
                        find.Number += n1.Number * m1.Number;
                    }
                }

            var arrNM = NM.OrderBy(t => t.Value).ToArray();

            j = 9;
            long res = 0;
            for (i = 0; i < arrNM.Length; i++)
            {
                j += arrNM[i].Number;
                if (j > 9)
                {
                    for (int k = 0; k < j / 10; k++)
                        res += arrNM[i].Value;
                    j %= 10;
                }
            }

            Array.Sort(arrN.Select(t => t & 0x01).ToArray(), arrN);
            Array.Sort(arrN.Select(t => t & 0x02).ToArray(), arrN);
            Array.Sort(arrN.Select(t => t & 0x04).ToArray(), arrN);
            Array.Sort(arrN.Select(t => t & 0x08).ToArray(), arrN);
            Array.Sort(arrN.Select(t => t & 0x10).ToArray(), arrN);

            long res2 = 0;
            i = 0;
            while (i < arrN.Length)
            {
                res2 += arrN[i] * arrM[0];
                i += 10;
            }

            using (StreamWriter str = new StreamWriter("output.txt"))
            {
                str.Write("{0}", res);
            }
        }
    }

    public class Pair
    {
        public int Value { get; set; }
        public int Number { get; set; }

        public Pair(int value, int number)
        {
            Value = value;
            Number = number;
        }
    }
}
