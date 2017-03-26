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
      int highestNumber = ReadIntRow()[0];

      var howManyTests = Calculate(highestNumber);
        
      output.WriteLine(howManyTests);
    }

    public int Calculate(int highestNumber)
    {
			var memo = Enumerable.Repeat(1, highestNumber+1).ToList();

      int checkLimit = highestNumber / 2;

      for (int currentPrime = 2; currentPrime <= checkLimit; currentPrime++)
			{
        if (IsPrime(currentPrime, memo))
        {
          for (int multiplier = 1; multiplier <= highestNumber / currentPrime; multiplier++)
          {
            int testedNum = currentPrime * multiplier;
            memo[testedNum] *= (PowerOfFactor(currentPrime, multiplier) + 1 + 1);
          }
        }
 			}

      int maximalFactor = 0;
			int firstNumberWithMaximalFactors = 0;
      for (int i = 2; i <= highestNumber; i++)
      {
        if (maximalFactor < memo[i])
        {
          maximalFactor = memo[i];
          firstNumberWithMaximalFactors = i;
        }
      }

			var howManyTests = highestNumber - firstNumberWithMaximalFactors + 1;
      return howManyTests;
    }

    int PowerOfFactor(int currentPrime, int multiplier)
    {
      int result = 0;
      int testedNum = multiplier;
      while (testedNum % currentPrime == 0)
      {
        result += 1;
        testedNum = testedNum / currentPrime;
      }

      return result;
    }

    bool IsPrime(int currentNum, List<int> memo)
    {
      return (memo[currentNum] == 1);
    }

    private int[] ReadIntRow()
    {
      return input.ReadLine().Split(' ').Select(str => int.Parse(str)).ToArray();
    }
  }

  private static void Main()
  {
    using (TextReader input = InputStream())
    {
      using (TextWriter output = OutputStream())
      {
        new Solution(input, output).Solve();
      }
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
