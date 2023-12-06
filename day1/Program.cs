

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

            var totalSum = 0;
            foreach (string line in lines)
            {
                var digits = line.Where(char.IsDigit).ToArray();

                if (digits.Length > 0)
                {
                    int res = int.Parse(digits.First().ToString() + digits.Last().ToString());
                    totalSum += res;
                }
            }
            Console.WriteLine($"sum p1-> {totalSum}");
        }

        public static readonly ImmutableDictionary<string, string> WordToDigitDictionary = 
        ImmutableDictionary.CreateRange( new KeyValuePair<string, string>[] {
                // no clash
                KeyValuePair.Create("four", "4"),
                KeyValuePair.Create("six", "6"),

                // clash in both
                KeyValuePair.Create("one", "o1e"),
                KeyValuePair.Create("two", "t2o"),

                // clash in end
                KeyValuePair.Create("three", "3e"),
                KeyValuePair.Create("five", "5e"),
                KeyValuePair.Create("seven", "7n"),
                KeyValuePair.Create("eight", "8t"),
                KeyValuePair.Create("nine", "9e"),
        });

        static void Part2(string[] args)
        {
            if (args.Length != 1)
            {
                Console.WriteLine("Be sure you use the command correctly. Correct usage:");
                Console.WriteLine("dotnet run {input file path}");
                return;
            }

            var inputFilePath = args[0];
            var file = File.ReadAllText(inputFilePath);

            var sb = new StringBuilder(file);
            foreach (var kv in WordToDigitDictionary)
            {
                sb = new StringBuilder(Strings.Replace(sb.ToString(), kv.Key, kv.Value));
            }

            var totalSum = 0;
            foreach (string line in Strings.Split(sb.ToString(), "\n"))
            {
                var digits = line.Where(char.IsDigit).ToArray();

                if (digits.Length > 0)
                {
                    int res = int.Parse(digits.First().ToString() + digits.Last().ToString());
                    totalSum += res;
                }
            }
            Console.WriteLine($"sum p2-> {totalSum}");
        }
    }
}