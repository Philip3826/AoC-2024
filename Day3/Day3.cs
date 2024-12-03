using System;
using System.Text.RegularExpressions;

namespace Day3;

class Day3
{
    static void Main(string[] args)
    {
        string input = string.Empty;
        string currentLine;
        while (!string.IsNullOrWhiteSpace(currentLine = Console.ReadLine()))
        {
            input += currentLine;
        }
        Console.WriteLine(AddMuls(input));
        Console.WriteLine(AddMulsWithDisables(input));
    }

    static int AddMulsWithDisables(string input)
    {
        string pattern = @"(mul\((\d{1,3}),(\d{1,3})\)|do\(\)|don't\(\))";

        Regex regex = new Regex(pattern);
        MatchCollection matches = regex.Matches(input);

        int sum = 0;
        bool disable = false;
        foreach (Match match in matches)
        {
            if (match.Value == "don't()")
            {
                disable = true;
                continue;
            }

            if (match.Value == "do()")
            {
                disable = false;
                continue;
            }

            if (disable)
            {
                continue;
            }

            int num1 = int.Parse(match.Groups[2].Value);
            int num2 = int.Parse(match.Groups[3].Value);
            sum += num1 * num2;
        }

        return sum;
    }

    static int AddMuls(string input)
    {
        string pattern = @"mul\((\d{1,3}),(\d{1,3})\)";

        Regex regex = new Regex(pattern);
        MatchCollection matches = regex.Matches(input);

        int sum = 0;

        foreach (Match match in matches)
        {
            int num1 = int.Parse(match.Groups[1].Value);
            int num2 = int.Parse(match.Groups[2].Value);
            sum += num1 * num2;
        }

        return sum;
    }
}
