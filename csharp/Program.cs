using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

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

      var allPrimes = AllPrimeNumbers(highestNumber);

      var firstNumberWithMaximalFactors = 0;
      var maximalFactors = 0;
      for (int currentNum = 2; currentNum <= highestNumber; currentNum++)
      {
        var currentNumFactorsCount = CountFactors(currentNum, allPrimes);

        if (maximalFactors < currentNumFactorsCount)
        {
          firstNumberWithMaximalFactors = currentNum;
          maximalFactors = currentNumFactorsCount;
        }
      }

      var howManyTests = highestNumber - firstNumberWithMaximalFactors + 1;

			output.WriteLine(howManyTests);
    }

    private int[] ReadIntRow()
    {
      return input.ReadLine().Split(' ').Select(str => int.Parse(str)).ToArray();
    }

    private int CountFactors(int number, List<int> knownPrimeNumbers)
    {
      if (number == 1)
        return 1;

      var factors = 2; // always include 1 and self
      int possibleFactor = 2;
      for(; possibleFactor < Math.Sqrt(number); possibleFactor++)
      {
        if(number % possibleFactor == 0)
          factors += 2;
      }

      if(possibleFactor*possibleFactor == number)
        factors += 1;

			return factors;
    }

    private List<int> AllPrimeNumbers(int maxNumber)
    {
			var result = new List<int>();

      int checkLimit = (int)Math.Round( Math.Sqrt(maxNumber), 0);
      for (int currentNum = 2; currentNum <= checkLimit; currentNum++)
      {
        if (CountFactors(currentNum, result) == 2)
          result.Add(currentNum);
      }

      return result;
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
