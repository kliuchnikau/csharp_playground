using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public class BestEducation
{
  public class ClonableStack
  {
    public long totalMass = 0;

    private int? topElement = null;
    private ClonableStack parent;
    private int parentPopIndex;

    public ClonableStack()
    {
      parent = null;
      parentPopIndex = 0;
      totalMass = 0;
    }

    public ClonableStack(ClonableStack stackToClone)
    {
      parent = stackToClone;
      parentPopIndex = stackToClone.LastIndex;
      totalMass = stackToClone.totalMass;
    }

    public ClonableStack Clone()
    {
      return new ClonableStack(this);
    }

    public void Push(int val)
    {
      topElement = val;

      totalMass += val;
    }

    public int Pop()
    {
      int poppedValue;

      poppedValue = parent[parentPopIndex];
      parentPopIndex--;

      totalMass -= poppedValue;
      return poppedValue;
    }

    public int LastIndex
    {
      get { return parentPopIndex + (topElement.HasValue ? 1 : 0 ); }
    }

    public int this[int index]
    {
      get {
        if (index <= parentPopIndex)
        {
          return parent[index];
        }
        else
        {
          return topElement.Value;
        }
      }
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
      snowmans.Add(new ClonableStack());

      long totalMass = 0;
      for(int i = 0; i < numCommands; i++)
      {
        var command = ReadIntRow();
        var toCloneIndex = command[0];

        var clone = new ClonableStack(snowmans[toCloneIndex]);

        switch (command[1])
        {
          case 0:
            clone.Pop();
            break;
          default:
            clone.Push(command[1]);
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
