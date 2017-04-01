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
			var input = @"7
8 9 + 1 7 - *";
			var output = @"-102";

      var inputStream = new StringReader(input);
      var outputStream = new StringWriter();
      var obj = new BestEducation.Solution(inputStream, outputStream);

      obj.Solve();

      Assert.That(outputStream.ToString().Trim(), Is.EqualTo(output));
    }
  }
}
