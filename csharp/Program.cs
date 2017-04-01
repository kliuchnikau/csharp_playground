using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public class BestEducation
{
  public class ClonableStack
  {
    public long totalMass = 0;

    private List<int> internalList = new List<int>();
    private ClonableStack parent;
    private int parentPopIndex;

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
      internalList.Add(val);

      totalMass += val;
    }

    public int Pop()
    {
      int poppedValue;

      if (internalList.Count > 0)
      {
        poppedValue = internalList.Last();
        internalList.Add(internalList.Count - 1);
      }
      else
      {
        poppedValue = parent[parentPopIndex];
        parentPopIndex--;
      }

      totalMass -= poppedValue;
      return poppedValue;
    }

    public int LastIndex
    {
      get { return parentPopIndex + internalList.Count - 1; }
    }

    public int this[int index]
    {
      get {
        if (LastIndex - index <= parentPopIndex)
        {
          return parent[index];
        }
        else
        {
          return internalList[index];
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

      var snowmans = new List<List<int>>();
      snowmans.Add(new List<int>());

      for(int i = 0; i < numCommands; i++)
      {
        var command = ReadIntRow();
        var toCloneIndex = command[0];

				var clone = new List<int>(snowmans[toCloneIndex]);

        switch (command[1])
        {
          case 0:
            clone.RemoveAt(clone.Count-1);
            break;
          default:
            clone.Add(command[1]);
            break;
        }

        snowmans.Add(clone);
      }

      long totalMass = 0;
      foreach(var snowman in snowmans)
      {
        foreach(var snowball in snowman)
        {
          totalMass += snowball;
        }
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
