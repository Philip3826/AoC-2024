using System;

namespace Day2;

class Day2
{
    static void Main(string[] args)
    {
        List<List<int>> Reports = new List<List<int>>();

        while (true)
        {
            string input = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(input))
            {
                break;
            }
            string[] numbers = input.Split(' ');
            List<int> parsedNumbers = new List<int>();
            foreach (string number in numbers)
            {
                if (int.TryParse(number, out int parsedNumber))
                {
                    parsedNumbers.Add(parsedNumber);
                }
            }
            Reports.Add(parsedNumbers);
        }
        Console.WriteLine(FindSafeReports(Reports));

    }

    private static int FindSafeReports(List<List<int>> reports)
    {
        int sum = 0;

        foreach (List<int> report in reports)
        {
            

            if (IsSafeReport(report) || ProblemDampener(report))
            {
                sum++;
                
            }
        }
        return sum;
    }

    private static bool ProblemDampener(List<int> report)
    {
        for (int i = 0; i < report.Count; i++)
        {
            var modifiedReport = new List<int>(report);
            modifiedReport.RemoveAt(i);
            if (IsSafeReport(modifiedReport))
                return true;
        }

        return false;
    }

    private static bool IsSafeReport(List<int> report)
    {
        int orientation = report[0] - report[1] > 0 ? 1 : -1;
        if (orientation == 0)
            return false;

        for (int i = 0; i < report.Count - 1; i++)
        {
            int diff = report[i] - report[i + 1];

            if (Math.Abs(diff) == 0 || Math.Abs(diff) > 3)
                return false;

            if (Math.Sign(diff) != Math.Sign(orientation))
                return false;

        }

        return true;
    }
}
