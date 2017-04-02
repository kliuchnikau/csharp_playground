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
      int indexOfLastSmallest = -1;

      var drinksAmount = ReadIntRow();

      foreach(int drink in drinksAmount)
      {
        if (drink > 0 || stackSizes.Count == 0)
        {
					if (stackSizes.Count == 0 || stackSizes[indexOfLastSmallest] != 1)
					{
						indexOfLastSmallest = 0;
					}
					else
					{
						indexOfLastSmallest++;
					}

          stackSizes.Insert(0, 1);
        }
        else
        {
          stackSizes[indexOfLastSmallest]++;

          if (indexOfLastSmallest > 0)
          {
            indexOfLastSmallest--;
          }
          else
          {
						int newIndexOfLastSmallest = indexOfLastSmallest + 1;
            int currentMinValue = stackSizes[indexOfLastSmallest];
            while (newIndexOfLastSmallest < stackSizes.Count &&
                   stackSizes[newIndexOfLastSmallest] == currentMinValue)
            {
              newIndexOfLastSmallest++;
            }
            indexOfLastSmallest = newIndexOfLastSmallest - 1;
          }
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
