using Microsoft.VisualStudio.TestTools.UnitTesting;
using SoPDF.Core;

namespace SoPDF.Core.Tests
{
    [TestClass]
    public class PdfTests
    {
        [TestMethod]
        public void TestCreatePdf()
        {
            PdfDocument document = new PdfDocument("Hello World! Again!");
            document.Save("test.pdf");

            System.IO.File.WriteAllText("a.txt", (double.Parse("5818.92") - double.Parse("6338.48")).ToString("f2"));
        }
    }
}
