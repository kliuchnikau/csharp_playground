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
      var input = @"3 1
abc
LanguageA
%TEMPLATE-START%
a
%TEMPLATE-END%
LanguageAB
%TEMPLATE-START%
ab
%TEMPLATE-END%
LanguageB
%TEMPLATE-START%
b
%TEMPLATE-END%";
      var output = @"LanguageA
0";

      var inputStream = new StringReader(input);
      var outputStream = new StringWriter();
      var obj = new BestEducation.Solution(inputStream, outputStream);

      obj.Solve();

      Assert.That(outputStream.ToString().Trim(), Is.EqualTo(output));
    }

    [Test]
    public void TestCase2()
    {
      var input = @"10 9
1234567890
!@#$%^&*()
qwertyuiop
QWERTYUIOP
asdfghjkl;
ASDFGHJKL:
zxcvbnm,./
ZXCVBNM<>?
[]{}='""-|+
Pascal
%TEMPLATE-START%
begin
  reset(input, 'filename.in');
  rewrite(output, 'filename.out');
end.
%TEMPLATE-END%
C
%TEMPLATE-START%
int main()
{
    freopen(""filename.in"", ""r"", stdin);
    freopen(""filename.out"", ""w"", stdout);
}
%TEMPLATE-END%
Java
%TEMPLATE-START%
public class Main {
    public static void main(String[] args) {
        try (IO.Scanner in = IO.newScanner();
             IO.Printer out = IO.newPrinter()) {
    }
}
%TEMPLATE-END%";
      var output = @"Pascal
240";

			var inputStream = new StringReader(input);
			var outputStream = new StringWriter();
			var obj = new BestEducation.Solution(inputStream, outputStream);

			obj.Solve();

      Assert.That(outputStream.ToString().Trim(), Is. EqualTo(output));
    }
  }
}
