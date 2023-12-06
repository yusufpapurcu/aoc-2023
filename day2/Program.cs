

using System.Collections;
using System.Collections.Immutable;
using System.Text;
using Microsoft.VisualBasic;

namespace Day1
{
    class Program
    {

        static void Main(string[] args)
        {
            Part1(args);
            Part2(args);
        }

        internal static int _limitRed = 12;
        internal static int _limitGreen = 13;
        internal static int _limitBlue = 14;

        static void Part1(string[] args)
        {
            if (args.Length != 1)
            {
                Console.WriteLine("Be sure you use the command correctly. Correct usage:");
                Console.WriteLine("dotnet run {input file path}");
                return;
            }

            var inputFilePath = args[0];
            var lines = File.ReadAllLines(inputFilePath);

            var score = 0;
            foreach (string line in lines)
            {
                var ts = Strings.Split(line, ":");
                if (ts.Length != 2)
                {
                    Console.WriteLine("fail in line, " + line);
                    return;
                }

                var gameNumber = Strings.Split(ts[0], " ")[1];

                var isGameFailed = false;
                var stepsRaw = Strings.Split(ts[1], ";");
                foreach (var stepRaw in stepsRaw)
                {
                    var itemsRaw = Strings.Split(stepRaw, ",");
                    foreach (var itemRaw in itemsRaw)
                    {
                        var tmp = Strings.Split(Strings.Trim(itemRaw), " ");
                        if (tmp.Length != 2)
                        {
                            Console.WriteLine("fail in item, " + itemRaw);
                            Console.WriteLine("-> length " + tmp.Length);
                            return;
                        }

                        var itemCount = tmp[0];
                        var itemType = tmp[1];

                        if (itemType == "red")
                        {
                            int x;
                            Int32.TryParse(itemCount, out x); if (x > _limitRed) isGameFailed = true;
                        }
                        if (itemType == "green")
                        {
                            int x;
                            Int32.TryParse(itemCount, out x); if (x > _limitGreen) isGameFailed = true;
                        }
                        if (itemType == "blue")
                        {
                            int x;
                            Int32.TryParse(itemCount, out x); if (x > _limitBlue) isGameFailed = true;
                        }

                    }
                }
                if (!isGameFailed)
                {
                    int x;
                    Int32.TryParse(gameNumber, out x); if (x > 12) isGameFailed = true;
                    score += x;
                }
            }

            Console.WriteLine($"score for p1: {score}");
        }

        static void Part2(string[] args)
        {
            if (args.Length != 1)
            {
                Console.WriteLine("Be sure you use the command correctly. Correct usage:");
                Console.WriteLine("dotnet run {input file path}");
                return;
            }

            var inputFilePath = args[0];
            var lines = File.ReadAllLines(inputFilePath);

            var score = 0;
            foreach (string line in lines)
            {
                var ts = Strings.Split(line, ":");
                if (ts.Length != 2)
                {
                    Console.WriteLine("fail in line, " + line);
                    return;
                }

                var gameNumber = Strings.Split(ts[0], " ")[1];

                var stepsRaw = Strings.Split(ts[1], ";");

                var minRed = 0;
                var minGreen = 0;
                var minBlue = 0;
                foreach (var stepRaw in stepsRaw)
                {
                    var itemsRaw = Strings.Split(stepRaw, ",");
                    foreach (var itemRaw in itemsRaw)
                    {
                        var tmp = Strings.Split(Strings.Trim(itemRaw), " ");
                        if (tmp.Length != 2)
                        {
                            Console.WriteLine("fail in item, " + itemRaw);
                            Console.WriteLine("-> length " + tmp.Length);
                            return;
                        }

                        var itemCount = tmp[0];
                        var itemType = tmp[1];

                        if (itemType == "red")
                        {
                            int x;
                            Int32.TryParse(itemCount, out x); if (x > minRed) minRed = x;
                        }
                        if (itemType == "green")
                        {
                            int x;
                            Int32.TryParse(itemCount, out x); if (x > minGreen) minGreen = x;
                        }
                        if (itemType == "blue")
                        {
                            int x;
                            Int32.TryParse(itemCount, out x); if (x > minBlue) minBlue = x;
                        }

                    }
                }
                score += minRed * minGreen * minBlue;
            }

            Console.WriteLine($"score for p2: {score}");
        }
    }
}