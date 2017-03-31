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
      int numCommands = ReadIntRow()[0];

      var queue = new Queue<int>();

      int? currentMinimum = null;

      for (int i = 0; i < numCommands; i++)
      {
        var command = ReadStrRow();
        if (command[0] == "+")
        {
          int addVal = int.Parse(command[1]);
          queue.Enqueue(addVal);

          if (currentMinimum.HasValue && addVal < currentMinimum)
            currentMinimum = addVal;
        }
        else if (command[0] == "-")
        {
          int removedElement = queue.Dequeue();

          if (removedElement == currentMinimum)
					  currentMinimum = null;
        }
        else
        {
          if (!currentMinimum.HasValue)
            currentMinimum = queue.Min();
          
          output.WriteLine(currentMinimum);
        }
      }
    }

    private List<int> ReadIntRow()
    {
      return input.ReadLine().Split(' ').Select(str => int.Parse(str)).ToList();
    }

		private List<string> ReadStrRow()
		{
      return input.ReadLine().Split(' ').ToList();
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
