using System;

namespace Day1;

class Day1

{
    static void Main(string[] args)
    {
        List<int> destinationList1 = new List<int>();
        List<int> destinationList2 = new List<int>();

        string input;
        while (!string.IsNullOrWhiteSpace(input = Console.ReadLine()))
        {

            string[] parts = input.Split("   ");
            if (parts.Length != 2 || !int.TryParse(parts[0], out var num1) || !int.TryParse(parts[1], out var num2))
            {
                Console.WriteLine("Please enter exactly two numbers separated by three spaces.");
                continue;
            }


            destinationList1.Add(num1);
            destinationList2.Add(num2);

        }
        destinationList1.Sort();
        destinationList2.Sort();

        Console.WriteLine(FindSimilarityScore(destinationList1, destinationList2));
        Console.WriteLine(FindTotalSimilarityScore(destinationList1, destinationList2));

    }

    private static int FindSimilarityScore(List<int> destinationList1, List<int> destinationList2)
    {
        int sum = 0;

        for (int dest1 = 0, dest2 = 0; dest1 < destinationList1.Count; dest1++, dest2++)
        {
            sum += Math.Abs(destinationList1[dest1] - destinationList2[dest2]);
        }
        return sum;
    }

    private static int FindTotalSimilarityScore(List<int> destinationList1, List<int> destinationList2)
    {
        int totalSum = 0;
        foreach (int dest1 in destinationList1)
        {
            totalSum += dest1 * destinationList2.Where(dest2 => dest1 == dest2).Count();
        }

        return totalSum;
    }
}