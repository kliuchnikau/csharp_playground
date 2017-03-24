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
      for (int highestNumber = 20160; highestNumber < 20200; highestNumber++)
      {
        //int highestNumber = ReadIntRow()[0];
        int checkLimit = (int)Math.Round(Math.Sqrt(highestNumber), 0);

				var allPrimes = AllPrimeNumbers(checkLimit);
				var allPrimePermutations = AllPermutations(allPrimes, checkLimit);

        var firstNumberWithMaximalFactors = 0;
        var maximalFactors = 0;
        for (int currentNum = 20160; currentNum <= highestNumber; currentNum++)
        {
          var currentNumFactorsCount = CountFactors(currentNum, allPrimePermutations);

          if (maximalFactors < currentNumFactorsCount)
          {
            firstNumberWithMaximalFactors = currentNum;
            maximalFactors = currentNumFactorsCount;
          }
        }

        var howManyTests = highestNumber - firstNumberWithMaximalFactors + 1;

        int controlValue = new BestEducation2.Solution().Solve(highestNumber);
        if (controlValue != howManyTests)
          throw new NotImplementedException();

        output.WriteLine(highestNumber);
        //output.WriteLine(howManyTests);
      }
    }

    private int[] ReadIntRow()
    {
      return input.ReadLine().Split(' ').Select(str => int.Parse(str)).ToArray();
    }

    private int CountFactors(int number, List<int> knownPrimeNumbers)
    {
      if (number == 1)
        return 1;

      int factors = 2; // always include 1 and self
      double sqrtOfMax = Math.Sqrt(number);
      var possibleFactors = knownPrimeNumbers.TakeWhile(possibleFactor => possibleFactor < sqrtOfMax);

      foreach(int possibleFactor in possibleFactors)
      {
        if(number % possibleFactor == 0)
          factors += 2;
      }

      int intSqrtOfMax = (int)sqrtOfMax;
			if (intSqrtOfMax * intSqrtOfMax == number)
        factors += 1;

			return factors;
    }

		private List<int> AllPrimeNumbers(int checkLimit)
    {
			var result = new List<int>();

      for (int currentNum = 2; currentNum <= checkLimit; currentNum++)
      {
        if (CountFactors(currentNum, result) == 2)
          result.Add(currentNum);
      }

      return result;
    }

    private List<int> AllPermutations(List<int> allPrimes, int valueLimit)
    {
      if (valueLimit == 90)
      {
        Console.WriteLine(1);
      }
      
      var result = new SortedSet<int>(allPrimes);

      foreach (int item1 in allPrimes)
      {
        // get all powers that are less than valueLimit
        int pow = 2;
        int powered = (int)Math.Pow(item1, pow);

        while (powered < valueLimit)
        {
          result.Add(powered);
          pow++;
          powered = (int)Math.Pow(item1, pow);
        }
      }

      int[] primeAndTheirPowers = result.ToArray();
			foreach (int item1 in primeAndTheirPowers)
			{
				foreach (int item2 in primeAndTheirPowers.Where(num => num > item1))
				{
					var permutation = item1 * item2;
					if (permutation > valueLimit)
						continue;

          result.Add(permutation);
				}
      }

      return result.ToList();
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
