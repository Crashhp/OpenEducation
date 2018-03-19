using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplusB2
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string fileString = File.ReadAllText("input.txt");
                string[] intStrings = fileString.Split(new char[] { ' ', '\t', '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
                if (intStrings.Length > 1)
                {
                    var b = int.Parse(intStrings[1]);
                    File.WriteAllText("output.txt", (int.Parse(intStrings[0]) + (long)b * b).ToString());
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
