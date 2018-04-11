using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoPDF.Core.Objects
{
    internal class PdfCatalog : PdfObject
    {
        private PdfPageTree _pageTree;

        public PdfCatalog(PdfPageTree pageTree) : base()
        {
            _pageTree = pageTree;
        }

        public override String ToPDF()
        {
            String pdf = String.Empty;

            pdf += ObjectNum.ToString() + " " + GenerationNum.ToString() + " obj " + "\n";
            pdf += "<<" + "\n";
            pdf += "/Pages " + _pageTree.GetRefStr() + "\n";
            pdf += "/Type /Catalog" + "\n";
            pdf += ">>" + "\n";
            pdf += "endobj " + "\n";

            return pdf;
        }
    }
}
