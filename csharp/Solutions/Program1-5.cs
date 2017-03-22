using System;
using System.IO;
using System.Linq;

public class BestEducation
{
  public struct Coordinates
  {
    public double x;
    public double y;
  }

  public class Solution
  {
    public int[] Sides { get; set; }

    public double Solve()
    {
      var hypotenuse = Sides.Max();
      var hypotenuseIdx = Array.IndexOf(Sides, hypotenuse);
      int? side1 = null;
      int? side2 = null;
      for(int i = 0; i < 3; i++) {
        if(i == hypotenuseIdx)
          continue;

        if(side1 == null) {
          side1 = Sides[i];
        } else {
          side2 = Sides[i];
        }
      }

      Coordinates firstCorner = new Coordinates { x = 0, y = 0 };
      Coordinates secondCorner = new Coordinates { x = hypotenuse, y = 0 };
      Coordinates thirdCorner = FindCoordinatesOfThirdCorner(hypotenuse, side1.Value, side2.Value);

      Coordinates middleFirstSec = MiddleOf(firstCorner, secondCorner);
      Coordinates middleFirstThird = MiddleOf(firstCorner, thirdCorner);
      Coordinates middleSecondThird = MiddleOf(secondCorner, thirdCorner);

			double distance1 = EuclideanDistanceBetween(middleFirstThird, middleFirstSec);
      double distance2 = EuclideanDistanceBetween(middleFirstSec, middleSecondThird);
      double distance3 = EuclideanDistanceBetween(middleFirstThird, middleSecondThird);

      double averageDistance = (distance1 + distance2 + distance3)/3;
      return averageDistance;
    }

    private Coordinates FindCoordinatesOfThirdCorner(int hypotenuse, int side1, int side2) {
      double x_divisible = side1 * side1 + hypotenuse * hypotenuse - side2 * side2;
      double x_divider = 2 * hypotenuse;
      double x = x_divisible / x_divider;
      double y = Math.Sqrt(side1*side1 - x*x);

      return new Coordinates { x = x, y = y };
    }

    private Coordinates MiddleOf(Coordinates point1, Coordinates point2) {
      var middleX = Math.Abs(point1.x + point2.x)/2;
      var middleY = Math.Abs(point1.y + point2.y)/2;
      return new Coordinates { x = middleX, y = middleY };
    }

    private double EuclideanDistanceBetween(Coordinates point1, Coordinates point2) {
      return Math.Sqrt( Math.Pow(point1.x - point2.x, 2) + Math.Pow(point1.y - point2.y, 2) );
    }
  }

  private static void Main()
  {
    int[] sides;
    using (TextReader input = InputStream())
    {
      sides = input.ReadLine().Split(' ').Select(str => int.Parse(str)).ToArray();
    }

    double answer = new Solution { Sides = sides }.Solve();

    using (TextWriter output = OutputStream())
    {
      output.WriteLine(answer);
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
