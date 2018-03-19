using System;
using System.IO;

namespace AplusB
{
    class AplusB
    {
        static void Main(string[] args)
        {
            try
            {
                string fileString = File.ReadAllText("input.txt");
                string[] intStrings = fileString.Split(new char[] { ' ', '\t', '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
                if (intStrings.Length > 1)
                {
                    File.WriteAllText("output.txt", (int.Parse(intStrings[0]) + int.Parse(intStrings[1])).ToString());
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
