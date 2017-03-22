using System;
using System.IO;
using System.Linq;

public class best_education
{
  private class Solution
  {
    public int[] First { get; set; }
    public int[] Second { get; set; }
    public int[] Third { get; set; }

    public double Solve() {
      double biggestSqrt = 0.0;

      int[] possibleIndexes = new int[] {0, 1, 2};
      foreach(int firstIdx in possibleIndexes) {
        foreach(int secondIdx in possibleIndexes.Except(new int[] { firstIdx })) {
          int thirdIdx = possibleIndexes.Except(new int[] { firstIdx, secondIdx }).First();

          int a = First[firstIdx];
          int b = Second[secondIdx];
          int c = Third[thirdIdx];

          double currentSqrt = Math.Sqrt(a*a + b*b + c*c);
          if( biggestSqrt < currentSqrt)
            biggestSqrt = currentSqrt;
        }
      }

      return biggestSqrt;
    }
  }

  private static void Main()
  {
    TextReader input;
#if JUDGE
    input = new StreamReader("input.txt");
#else
    input = Console.In;
#endif
    int[] first = input.ReadLine().Split(' ').Select(str => int.Parse(str)).ToArray();
    int[] second = input.ReadLine().Split(' ').Select(str => int.Parse(str)).ToArray();
    int[] third = input.ReadLine().Split(' ').Select(str => int.Parse(str)).ToArray();
    input.Close();

    double answer = new Solution { First = first, Second = second, Third = third }.Solve();

    TextWriter output;
#if JUDGE
    output = new StreamWriter("output.txt");
#else
    output = Console.Out;
#endif
    output.WriteLine(answer);
    output.Close();
  }
}
