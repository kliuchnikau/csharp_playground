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
      ReadIntRow();
      var secondsPerTask = ReadIntRow().ToList();

      int result = Solve(secondsPerTask);
        
      output.WriteLine(result);
    }

    private int Solve(List<int> secondsPerTask)
    {
			int maxSeconds = 60 * 300;

			secondsPerTask.Sort();

			int result = 0;
			int sumSeconds = 0;
      foreach (int secondsInCurrentTask in secondsPerTask)
      {
        sumSeconds += secondsInCurrentTask;
        if (sumSeconds <= maxSeconds)
          result++;
      }
      return result;
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
