using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoPDF.Core.Objects
{
    internal class PdfPageTree : PdfObject
    {
        private List<PdfPage> _pages;

        public PdfPageTree() : base()
        {
            _pages = new List<PdfPage>();
        }

        public override String ToPDF()
        {
            String pdf = String.Empty;

            pdf += pdf += ObjectNum.ToString() + " " + GenerationNum.ToString() + " obj " + "\n";
            pdf += "<<" + "\n";

            pdf += "/Kids [";
            String pagesStr = String.Empty;
            foreach (PdfPage page in _pages)
            {
                pagesStr += page.GetRefStr() + " ";
            }
            pdf += pagesStr.TrimEnd(' ');
            pdf += "]" + "\n";

            pdf += "/Count " + _pages.Count.ToString() + "\n";
            pdf += "/Type /Pages" + "\n";


            pdf += ">>" + "\n";
            pdf += "endobj " + "\n";

            return pdf;
        }

        public void AddPage(PdfPage page)
        {
            _pages.Add(page);
        }
    }
}
