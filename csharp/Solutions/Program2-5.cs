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
      var allCommands = ReadStrRow();

      var stack = new Stack<long>();

      foreach(string command in allCommands)
      {
        switch (command)
        {
          case "+":
            long sum = stack.Pop() + stack.Pop();
            stack.Push(sum);
            break;
          case "-":
            long second = stack.Pop();
            long first = stack.Pop();
            stack.Push(first - second);
            break;
          case "*":
            long perm = stack.Pop() * stack.Pop();
            stack.Push(perm);
            break;
          default:
            stack.Push(long.Parse(command));
            break;
        }
      }

      output.WriteLine(stack.Pop());
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
