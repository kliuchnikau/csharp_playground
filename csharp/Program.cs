using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public class BestEducation
{
  public class Solution
  {
    private TextReader input;
    private TextWriter output;

    public Solution(TextReader input, TextWriter output)
    {
      this.input = input;
      this.output = output;
    }

    public void Solve()
    {
      int numPassengers = ReadIntRow()[0];
      var stackSizes = new List<int>();

      var drinksAmount = ReadIntRow();

      foreach(int drink in drinksAmount)
      {
        if (drink > 0 || stackSizes.Count == 0)
        {
          stackSizes.Insert(0, 1);
        }
        else
        {
          int smallestStackSize = stackSizes[0];
          int indexOfLastSmallest = 0;
          while (indexOfLastSmallest < stackSizes.Count &&
                 stackSizes[indexOfLastSmallest] == smallestStackSize)
          {
            indexOfLastSmallest++;
          }
          stackSizes[--indexOfLastSmallest]++;
        }
      }

      output.WriteLine(stackSizes.Last());
    }

    private List<int> ReadIntRow()
    {
      return input.ReadLine().Split(' ').Select(str => int.Parse(str)).ToList();
    }

    private List<string> ReadStrRow()
    {
      return input.ReadLine().Split(' ').ToList();
    }

    private string ReadString()
    {
      return input.ReadLine();
    }
  }

  private static void Main()
  {
    using (TextWriter output = OutputStream())
      using (TextReader input = InputStream())
      {
        new Solution(input, output).Solve();
      }
  }

  private static TextReader InputStream()
  {
#if JUDGE
    return new StreamReader("input.txt");
#else
    return Console.In;
#endif
  }

  private static TextWriter OutputStream()
  {
#if JUDGE
    return new StreamWriter("output.txt");
#else
    return Console.Out;
#endif
  }
}
