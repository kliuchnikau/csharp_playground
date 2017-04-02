using System;
using System.IO;
using NUnit.Framework;

namespace nunit
{
  [TestFixture]
  public class Test
  {
    [Test]
    public void TestCase1()
    {
			var input = @"5
1 0 0 2 0";
			var output = @"3";

      var inputStream = new StringReader(input);
      var outputStream = new StringWriter();
      var obj = new BestEducation.Solution(inputStream, outputStream);

      obj.Solve();

      Assert.That(outputStream.ToString().Trim(), Is.EqualTo(output));
    }

		[Test]
		public void TestCase2()
		{
			var input = @"1
0";
			var output = @"1";

			var inputStream = new StringReader(input);
			var outputStream = new StringWriter();
			var obj = new BestEducation.Solution(inputStream, outputStream);

			obj.Solve();

			Assert.That(outputStream.ToString().Trim(), Is.EqualTo(output));
		}
  }
}
