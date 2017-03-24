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

			int controlValue = new BestEducation2.Solution().Solve(highestNumber);
			if (controlValue != howManyTests)
				throw new NotImplementedException();
      
      output.WriteLine(howManyTests);
    }

    public int Calculate(int highestNumber)
    {
      // 2 because it is dividable by 1 and by self
			var memo = Enumerable.Repeat(2, highestNumber+1).ToList(); 
			
      //int checkLimit = (int)Math.Round(Math.Sqrt(highestNumber), 0);
			int checkLimit = highestNumber / 2;
			for (int currentNum = 2; currentNum <= checkLimit; currentNum++)
			{
        for (int tryDivide = currentNum+1; tryDivide <= highestNumber; tryDivide++)
        {
          if (tryDivide % currentNum == 0)
						memo[tryDivide] += 1;
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
