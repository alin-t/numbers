using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Numbers
{
    public class NumbersProcessor
    {
        public static int? ValueFromNumber(Number toProcess, List<Number> knownNumbers)
        {
            int? parsedValue = null;
            knownNumbers.ForEach(number =>
                {
                    if (toProcess.Equals(number)) parsedValue = number.GetValue();
                });
            return parsedValue;
        }

        public static List<Number> ExtractNumbersFromFileContent(List<string> lines)
        {
            var numbers = new List<Number>();
            var numbersGroup = new List<List<string>>();

            // read batches of 4 lines and extract the numbers aftewards
            for (int i = 0; i < lines.Count; i++)
            {
                if (i % 4 == 0 && i != 0)
                {
                    numbers.AddRange(NumbersProcessor.ExtractNumbersFromGroupBatch(numbersGroup));
                    numbersGroup = new List<List<string>>
                        {
                            lines[i].ToCharArray().Select(c => c.ToString(CultureInfo.InvariantCulture)).ToList()
                        };
                }
                else
                {
                    numbersGroup.Add(lines[i].ToCharArray().Select(c => c.ToString(CultureInfo.InvariantCulture)).ToList());
                }
            }
            // process last batch
            numbers.AddRange(NumbersProcessor.ExtractNumbersFromGroupBatch(numbersGroup));

            return numbers;
        }

        public static List<Number> ExtractNumbersFromGroupBatch(List<List<String>> lines)
        {
            var numbers = new List<Number>();

            int startIndex = 0;

            for (int i = 0; i < lines[0].Count; i++)
            {
                if (i == lines[0].Count - 1)
                {
                    // extract last number
                    numbers.Add(ExtractNumber(startIndex, i, lines));
                }
                else if (MetNumbersSeparator(i, lines))
                {
                    numbers.Add(ExtractNumber(startIndex, i - 1, lines));
                    // find the next starting index for the next number
                    // forward any eventual more than 1 space
                    i = startIndex = GetNextStartIndex(i, lines);
                }
            }

            return numbers;
        }

        // find out if we have space for the index in all the lines
        private static Boolean MetNumbersSeparator(int index, List<List<String>> lines)
        {
            return lines.All(t => t[index] == " ");
        }

        private static Number ExtractNumber(int startIndex, int endIndex, List<List<String>> lines)
        {
            var representation = lines.Select(line => line.GetRange(startIndex, endIndex - startIndex + 1)).ToList();

            return new Number(representation);
        }

        // find the starting index of the next number
        private static int GetNextStartIndex(int currentIndex, List<List<String>> lines)
        {
            int index;
            for (index = currentIndex; index < lines[0].Count; index++)
            {
                if (lines[0][index] != " ") return index;
            }

            return index;
        }
    }
}
