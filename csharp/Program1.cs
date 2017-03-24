using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

public class BestEducation2
{
  public class Solution
  {
    public int Solve(int highestNumber)
    {
      var firstNumberWithMaximalFactors = 0;
      var maximalFactors = 0;
			for (int currentNum = 20160; currentNum <= highestNumber; currentNum++)
      {
        var currentNumFactorsCount = CountFactors(currentNum);

        if (maximalFactors < currentNumFactorsCount)
        {
          firstNumberWithMaximalFactors = currentNum;
          maximalFactors = currentNumFactorsCount;
        }
      }

      var howManyTests = highestNumber - firstNumberWithMaximalFactors + 1;
      return howManyTests;

    }

    private int CountFactors(int number)
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
  }
}
