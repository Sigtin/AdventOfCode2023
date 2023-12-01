using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AdventOfCode2023.Puzzles.Day_1
{
    public class Day1
    {
        private static readonly Dictionary<string, int> numberTable = new()
        {
            {"zero", 0},
            {"0", 0},
            {"one", 1},
            {"1", 1},
            {"two", 2},
            {"2", 2},
            {"three", 3},
            {"3", 3},
            {"four", 4},
            {"4", 4},
            {"five", 5},
            {"5", 5},
            {"six", 6},
            {"6", 6},
            {"seven", 7},
            {"7", 7},
            {"eight", 8},
            {"8", 8},
            {"nine", 9},
            {"9", 9},
        };
        public static int PartOne()
        {
            var input = File.ReadLines("H:\\Dev_Projects\\AdventOfCode2023\\Puzzles\\Day_1\\Day1_Input.txt").ToList();
            Dictionary<int, int> indexAndNumbers = [];
            int totalSum = 0;

            for (int i = 0; i < input.Count; i++)
            {
                Char[] line = input[i].ToCharArray();
                List<int> numbersInLine = [];
                for (int j = 0;  j < line.Length; j++)
                {
                    try
                    {
                        int number = int.Parse(line[j].ToString());
                        numbersInLine.Add(number);
                    }
                    catch
                    {
                        continue;
                    }
                    
                }

                indexAndNumbers[i] = int.Parse($"{numbersInLine.First()}{numbersInLine.Last()}");
                //Console.WriteLine($"{i}. {indexAndNumbers[i]}");
            }

            totalSum = indexAndNumbers.Sum(x => x.Value);

            return totalSum;
        }

        public static int PartTwo()
        {
            var input = File.ReadLines("H:\\Dev_Projects\\AdventOfCode2023\\Puzzles\\Day_1\\Day1_Input.txt").ToList();
            Dictionary<int, int> indexAndNumbers = [];
            int totalSum = 0;

            for (int i = 0; i < input.Count; i++)
            {
                input[i] = ConvertWordsToNumbers(input[i]);
                
                indexAndNumbers[i] = int.Parse($"{input[i].First()}{input[i].Last()}");
                //Console.WriteLine($"{i}. {indexAndNumbers[i]}");
            }

            totalSum = indexAndNumbers.Sum(x => x.Value);

            return totalSum;
        }

        private static string ConvertWordsToNumbers(string input)
        {
            List<Match> matches = [];
            foreach(string key in numberTable.Keys)
            {
                if (input.Contains(key))
                {
                    var regex = new Regex(Regex.Escape(key));
                    matches.AddRange(regex.Matches(input));
                }
            }

            matches.Sort(delegate (Match x, Match y)
            {
                if (x.Index > y.Index) return +1;
                else if (x.Index < y.Index) return -1;
                else return 0;
            });

            List<string> numbers = [];

            foreach(Match match in matches)
            {
                numbers.Add(numberTable[match.Value].ToString());
            }

            List<int> numbersInLine = [];
            for (int j = 0; j < numbers.Count; j++)
            {
                try
                {
                    int number = int.Parse(numbers[j].ToString());
                    numbersInLine.Add(number);
                }
                catch
                {
                    continue;
                }

            }

            StringBuilder stringBuilder = new StringBuilder("");

            foreach(int number in numbersInLine)
            {
                stringBuilder.Append(number);
            }

            return stringBuilder.ToString();
        }
    }
}
