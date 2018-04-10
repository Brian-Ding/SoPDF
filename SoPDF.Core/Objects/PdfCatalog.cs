using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoPDF.Core.Objects
{
    internal class PdfCatalog : PdfObject
    {
        private PdfPage _firstPage;

        public PdfCatalog(PdfPage firstPage) : base()
        {
            _firstPage = firstPage;
        }

        public override byte[] ToPDF()
        {
            String pdf = String.Empty;

            pdf += ObjectNum.ToString() + " " + GenerationNum.ToString() + "obj" + "\n";
            pdf += "<< /Type /Catalog" + "\n";
            pdf += "/Pages" + _firstPage.GetRefStr() + "\n";
            pdf += ">>" + "\n";
            pdf += "endobj" + "\n";

            return Encoding.UTF8.GetBytes(pdf);
        }
    }
}
