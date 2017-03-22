using System;
using System.IO;

public class aplusb_square
{
	private static void Main()
	{
		TextReader input;
#if JUDGE
        input = new StreamReader("input.txt");
#else
		input = Console.In;
#endif
		string[] numbers = input.ReadLine().Split(' ');
		input.Close();

		int a = int.Parse(numbers[0]);
		long b = int.Parse(numbers[1]);
		long bSquare = b * b;
		long answer = a + bSquare;

		TextWriter output;
#if JUDGE
        output = new StreamWriter("output.txt");
#else
		output = Console.Out;
#endif
		output.WriteLine(answer);
		output.Close();
	}
}