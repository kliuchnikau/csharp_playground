using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

public class BestEducation
{
  public struct Coordinates
  {
    public double x;
    public double y;
  }

  public class Solution
  {
    private TextReader input;
    private TextWriter output;

    private List<Tuple<int, string>> blockInfo;
    private Dictionary<Char, Coordinates> symbolToCoords;

    public Solution(TextReader input, TextWriter output)
    {
      this.input = input;
      this.output = output;

      this.symbolToCoords = new Dictionary<Char, Coordinates>();
      this.blockInfo = new List<Tuple<int,string>>();
    }

    public void Solve()
    {
      var matrixParams = ReadIntRow();
      int matrixWidth = matrixParams[0];
      int matrixHeight = matrixParams[1];

      for (int heightI = matrixHeight; heightI > 0; heightI--)
      {
        var currentRow = ReadString();
        for (int widthI = 1; widthI <= matrixWidth; widthI++)
        {
          char symbolValue = currentRow[widthI-1];
          symbolToCoords[symbolValue] = new Coordinates { x = widthI, y = heightI };
        }
      }

      for (int i = 0; i < 3; i++)
      {
        ProcessBlock();
      }

      var bestCodeBlock = blockInfo[0];
      for (int i = 1; i < blockInfo.Count(); i++)
      {
        var currentBlock = blockInfo[i];
        if (currentBlock.Item1 < bestCodeBlock.Item1)
          bestCodeBlock = currentBlock;
      }

      output.WriteLine(bestCodeBlock.Item2);
      output.WriteLine(bestCodeBlock.Item1);
    }

    private int[] ReadIntRow()
    {
      return input.ReadLine().Split(' ').Select(str => int.Parse(str)).ToArray();
    }

    private string ReadString()
    {
      return input.ReadLine();
    }

    private void ProcessBlock()
    {
      var languageName = ReadString();
      ReadString(); // %TEMPLATE-START%

      string fullTemplate = "";
      var currentLine = ReadString();
      while (currentLine != "%TEMPLATE-END%")
      {
        fullTemplate += currentLine;

        currentLine = ReadString();
      }

      var timeToType = CountTimeToTypeTemplate(fullTemplate);

      blockInfo.Add(new Tuple<int, string>(timeToType, languageName));
    }

    private int CountTimeToTypeTemplate(string fullTemplate)
    {
      var timeToType = 0;

      var acceptableChars = fullTemplate.Where((char arg) => 32 < (int)arg && (int)arg <= 126).ToArray();

      for (int charIdx = 1; charIdx < acceptableChars.Length; charIdx++)
      {
        char previousChar = acceptableChars[charIdx-1];
        char currentChar = acceptableChars[charIdx];

        timeToType += DistanceBetween(previousChar, currentChar);

        previousChar = currentChar;
      }

      return timeToType;
    }

    private int DistanceBetween(char previousChar, char currentChar)
    {
      if (!symbolToCoords.ContainsKey(previousChar) || !symbolToCoords.ContainsKey(currentChar))
      {
        Console.WriteLine("alarm");
      }
      var coordPrev = symbolToCoords[previousChar];
      var coordCurr = symbolToCoords[currentChar];

      return (int)Math.Max(Math.Abs(coordPrev.x - coordCurr.x), Math.Abs(coordPrev.y - coordCurr.y));
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
