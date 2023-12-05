using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2023.Puzzles.Day_2
{
    public class Day2
    {
        public static int PartOne()
        {
            var input = File.ReadLines("H:\\Dev_Projects\\AdventOfCode2023\\Puzzles\\Day_2\\Day2_Input.txt").ToList();
            List<string> gameOutcome = [];
            foreach(string line in input)
            {
                var split = line.Split(":");
                gameOutcome.Add(split[1].Trim());
            }

            List<Game> games = [];

            for(int i = 0; i < gameOutcome.Count; i++)
            {
                var outcomes = gameOutcome[i].Split(";");
                List<Pull> pulls = [];

                foreach (string hand in outcomes)
                {
                    var numbersPerColor = hand.Split(",");

                    foreach (string color in numbersPerColor)
                    {
                        var finalSplit = color.Trim().Split(" ");
                        Pull pull = new()
                        {
                            NumberOfCubes = int.Parse(finalSplit[0]),
                            Color = finalSplit[1]
                        };

                        pulls.Add(pull);
                    }
                }

                games.Add(new Game()
                {
                    Id = i + 1,
                    Pulls = pulls
                });
            }

            int totalSum = 0;

            foreach (var item in games)
            {
                bool validGame = true;
                for (int i = 0; i < item.Pulls.Count; i++)
                {
                    switch (item.Pulls[i].Color.ToLower())
                    {
                        case "red":
                            if (item.Pulls[i].NumberOfCubes > 12)
                                validGame = false;
                            break;
                        case "green":
                            if (item.Pulls[i].NumberOfCubes > 13)
                                validGame = false;
                            break;
                        case "blue":
                            if (item.Pulls[i].NumberOfCubes > 14)
                                validGame = false;
                            break;
                        default:
                            break;
                    }
                }

                if (!validGame)
                    continue;

                totalSum += item.Id;
            }

            return totalSum;
        }

        public static int PartTwo()
        {
            var input = File.ReadLines("H:\\Dev_Projects\\AdventOfCode2023\\Puzzles\\Day_2\\Day2_Input.txt").ToList();
            List<string> gameOutcome = [];
            foreach (string line in input)
            {
                var split = line.Split(":");
                gameOutcome.Add(split[1].Trim());
            }

            List<Game> games = [];

            for (int i = 0; i < gameOutcome.Count; i++)
            {
                var outcomes = gameOutcome[i].Split(";");
                List<Pull> pulls = [];

                foreach (string hand in outcomes)
                {
                    var numbersPerColor = hand.Split(",");

                    foreach (string color in numbersPerColor)
                    {
                        var finalSplit = color.Trim().Split(" ");
                        Pull pull = new()
                        {
                            NumberOfCubes = int.Parse(finalSplit[0]),
                            Color = finalSplit[1]
                        };

                        pulls.Add(pull);
                    }
                }

                games.Add(new Game()
                {
                    Id = i + 1,
                    Pulls = pulls
                });
            }

            int totalSum = 0;

            foreach (var item in games)
            {
                int minimumRed = 0;
                int minimumGreen = 0;
                int minimumBlue = 0;

                for (int i = 0; i < item.Pulls.Count; i++)
                {
                    switch (item.Pulls[i].Color.ToLower())
                    {
                        case "red":
                            if (item.Pulls[i].NumberOfCubes > minimumRed)
                                minimumRed = item.Pulls[i].NumberOfCubes;
                            break;
                        case "green":
                            if (item.Pulls[i].NumberOfCubes > minimumGreen)
                                minimumGreen = item.Pulls[i].NumberOfCubes;
                            break;
                        case "blue":
                            if (item.Pulls[i].NumberOfCubes > minimumBlue)
                                minimumBlue = item.Pulls[i].NumberOfCubes;
                            break;
                        default:
                            break;
                    }
                }

                totalSum += minimumBlue * minimumGreen * minimumRed;
            }

            return totalSum;
        }
    }

    public class Game
    {
        public int Id { get; set; }
        public required List<Pull> Pulls { get; set; }
    }

    public class Pull
    {
        public int NumberOfCubes { get; set; }
        public required string Color { get; set; }
    }
}
