using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;

namespace SoPDF.Core.UnitTest
{
    [TestClass]
    public class PdfTest
    {
        [TestMethod]
        public void Test()
        {
            PdfDocument document = new PdfDocument("Hello World!");
            document.Save("test.pdf");
        }
    }
}
