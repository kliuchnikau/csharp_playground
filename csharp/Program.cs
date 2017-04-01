using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public class BestEducation
{
  public class ClonableStack
  {
    public long totalMass;
    public int parentIndex;
    public int topElement;

    private int thisIndex;
    private List<ClonableStack> fullList;

    public ClonableStack(
        List<ClonableStack> fullList,
        int thisIndex = 0,
        int parentIndex = 0,
        int topElement = 0,
        long totalMass = 0)
    {
      this.fullList = fullList;
      this.thisIndex = thisIndex;
      this.parentIndex = parentIndex;
      this.topElement = topElement;
      this.totalMass = totalMass;
    }

    public ClonableStack CloneAndPush(int val, int newIndex)
    {
      long newTotalMass = this.totalMass + val;
      return new ClonableStack(fullList, newIndex, thisIndex, val, newTotalMass);
    }

    public ClonableStack CloneAndPop()
    {
      return fullList[parentIndex];
    }
  }

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

      var snowmans = new List<ClonableStack>();
      snowmans.Add(new ClonableStack(snowmans));

      long totalMass = 0;
      for(int i = 1; i <= numCommands; i++)
      {
        var command = ReadIntRow();
        var toCloneIndex = command[0];
        var toCloneSnowman = snowmans[toCloneIndex];

        ClonableStack clone;
        switch (command[1])
        {
          case 0:
            clone = toCloneSnowman.CloneAndPop();
            break;
          default:
            clone = toCloneSnowman.CloneAndPush(command[1], i);
            break;
        }

        totalMass += clone.totalMass;

        snowmans.Add(clone);
      }

      output.WriteLine(totalMass);
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
