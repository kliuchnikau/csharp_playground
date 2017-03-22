using System;
using System.IO;
using System.Linq;

public class best_education
{
  private static void Main()
  {
    TextReader input;
#if JUDGE
    input = new StreamReader("input.txt");
#else
    input = Console.In;
#endif
    int days = int.Parse(input.ReadLine()); // 2 <= days <= 100
    int[] practicePref = input.ReadLine().Split(' ').Select(str => int.Parse(str)).ToArray();
    int[] theoryPref = input.ReadLine().Split(' ').Select(str => int.Parse(str)).ToArray();
    input.Close();

    int answer = CalculateResult(days, practicePref, theoryPref);

    TextWriter output;
#if JUDGE
    output = new StreamWriter("output.txt");
#else
    output = Console.Out;
#endif
    output.WriteLine(answer);
    output.Close();
  }

  private static int CalculateResult(int days, int[] practicePref, int[] theoryPref) {
    int[] deltas = new int[days];
    for(int dayIndex = 0; dayIndex < days; dayIndex++) {
      deltas[dayIndex] = practicePref[dayIndex] - theoryPref[dayIndex];
    }

    var bestDaysPair = GetBestGuessPracticeAndTheoryIndex(deltas, practicePref, theoryPref);

    int answer = 0;
    for(int dayIndex = 0; dayIndex < days; dayIndex++) {
      if(dayIndex == bestDaysPair.Item1) {
        answer += practicePref[dayIndex];
      } else if(dayIndex == bestDaysPair.Item2) {
        answer += theoryPref[dayIndex];
      } else if(deltas[dayIndex] > 0) {
        answer += practicePref[dayIndex];
      } else {
        answer += theoryPref[dayIndex];
      }
    }

    return answer;
  }

  private static Tuple<int, int> GetBestGuessPracticeAndTheoryIndex(int[] delta, int[] practicePref, int[] theoryPref) {
    int biggestDelta = delta.Max();

    int bestPracticeIndex, bestTheoryIndex;
    if(biggestDelta > 0) {
      bestPracticeIndex = getBestPracticeIndex(delta, practicePref);
      bestTheoryIndex = getBestTheoryIndex(delta, theoryPref, bestPracticeIndex);
    } else {
      bestTheoryIndex = getBestTheoryIndex(delta, theoryPref);
      bestPracticeIndex = getBestPracticeIndex(delta, practicePref, bestTheoryIndex);
    }

    return new Tuple<int, int>(bestPracticeIndex, bestTheoryIndex);
  }

  private static int getBestPracticeIndex(int[] delta, int[] practicePref, int? bestTheoryIndex = null) {
    int biggestDelta = delta.Max();

    int? bestIndex = null;
    for(int i = 0; i < practicePref.Length; i++) {
      if(i != bestTheoryIndex && biggestDelta == delta[i]) {
		if(bestIndex == null || practicePref[(int)bestIndex] < practicePref[i]) {
          bestIndex = i;
        }
      }
    }

    return (int)bestIndex;
  }

  static int getBestTheoryIndex(int[] delta, int[] theoryPref, int? bestPracticeIndex = null) {
    int smallestDelta = delta.Min();

    int? bestIndex = null;
   	for(int i = 0; i < theoryPref.Length; i++) {
	    if(i != bestPracticeIndex && smallestDelta == delta[i]) {
		    if(bestIndex == null || theoryPref[i] < theoryPref[(int)bestIndex]) {
          bestIndex = i;
        }
      }
    }

	  return (int)bestIndex;
  }
}