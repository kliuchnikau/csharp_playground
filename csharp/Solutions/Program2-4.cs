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

      for (int i = 0; i < numCommands; i++)
      {
        var bracketSequence = ReadString();

        if (TestValidity(bracketSequence))
        {
          output.WriteLine("YES");
        }
        else
        {
					output.WriteLine("NO");
        }
      }
    }

    bool TestValidity(string bracketSequence)
    {
      bool storedVal;
      var stack = new Stack<bool>();
      foreach (char c in bracketSequence)
      {
        switch (c)
        {
          case '(':
            stack.Push(true);
            break;
          case '[':
            stack.Push(false);
            break;
          case ')':
            if (stack.Count == 0)
              return false;
						storedVal = stack.Pop();

            if (storedVal != true)
              return false;
						break;
					case ']':
						if (stack.Count == 0)
							return false;
            
						storedVal = stack.Pop();

            if (storedVal != false)
							return false;
						break;
				}
      }

			return stack.Count == 0;
    }

    private List<int> ReadIntRow()
    {
      return input.ReadLine().Split(' ').Select(str => int.Parse(str)).ToList();
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
