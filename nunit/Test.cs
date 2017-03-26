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
			var input = @"2
60 18000";
      var output = @"1";

      var inputStream = new StringReader(input);
      var outputStream = new StringWriter();
      var obj = new BestEducation.Solution(inputStream, outputStream);

      obj.Solve();

      Assert.That(outputStream.ToString().Trim(), Is.EqualTo(output));
    }

    [Test]
    public void TestCase2()
    {
			var input = @"3
10000 9000 8000";
      var output = @"2";

			var inputStream = new StringReader(input);
			var outputStream = new StringWriter();
			var obj = new BestEducation.Solution(inputStream, outputStream);

			obj.Solve();

      Assert.That(outputStream.ToString().Trim(), Is. EqualTo(output));
    }
  }
}
