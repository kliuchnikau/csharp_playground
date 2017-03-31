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

		public class OurStack
    {
      private int? currentMin;
      private Stack<KeyValuePair<int, int>> stack;

      public OurStack()
      {
        stack = new Stack<KeyValuePair<int, int>>();
      }

      public void EmptyMinimum()
      {
        currentMin = null;
      }

      public void Push(int val)
      {
        stack.Push(new KeyValuePair<int, int>(val, minValue(val)));
      }

      public int Pop()
			{
        return stack.Pop().Key;
      }

      public int? Min()
      {
        if (IsEmpty())
        {
          return null;
        }
        else
        {
          return stack.Peek().Value;
        }
      }

      public bool IsEmpty()
      {
        return stack.Count == 0;
      }

      private int minValue(int val)
      {
        if (!this.currentMin.HasValue || val < this.currentMin)
          this.currentMin = val;

        return (int)this.currentMin;
      }
    }

    public class OurQueue
    {
      private OurStack inbox, outbox;

      public OurQueue()
      {
        inbox = new OurStack();
        outbox = new OurStack();
      }

      public void Enqueue(int val)
      {
        inbox.Push(val);
      }

      public int Dequeue()
      {
        if (outbox.IsEmpty())
        {
          outbox.EmptyMinimum();
          while (!inbox.IsEmpty())
          {
            outbox.Push(inbox.Pop());
            inbox.EmptyMinimum();
          }
        }

        return outbox.Pop();
      }

      public int Min()
      {
        if (inbox.IsEmpty())
        {
					return outbox.Min().Value;
        }

				if (outbox.IsEmpty())
				{
					return inbox.Min().Value;
				}


        if (inbox.Min() < outbox.Min())
        {
          return inbox.Min().Value;
        }
        else
        {
          return outbox.Min().Value;
        }
      }
    }

    public void Solve()
    {
      int numCommands = ReadIntRow()[0];

      var queue = new OurQueue();

      for (int i = 0; i < numCommands; i++)
      {
        var command = ReadStrRow();
        if (command[0] == "+")
        {
          int addedValue = int.Parse(command[1]);
          queue.Enqueue(addedValue);
        }
        else if (command[0] == "-")
        {
          queue.Dequeue();
        }
        else
        {
          var minVal = queue.Min();
          output.WriteLine(minVal);
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
