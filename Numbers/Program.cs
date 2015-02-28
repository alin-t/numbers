using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Numbers
{
    class Program
    {
        private const String InputPath = @"D:\NumberParserExtended_good.txt";

        static void Main(string[] args)
        {
            List<string> lines = File.ReadLines(InputPath).ToList();

            List<Number> numbers = NumbersProcessor.ExtractNumbersFromFileContent(lines);

            // print the found know numbers
            List<Number> knownNumbers = NumbersFactory.CreateKnownNumbers();
            foreach (var number in numbers)
            {
                var knownNumber = knownNumbers.FirstOrDefault(known => known.Equals(number));
                if (knownNumber != null) Console.Write(knownNumber.GetValue());
                Console.Write(" ");
            }

            Console.ReadKey();
        }
    }
}
