using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoPDF.Core.Objects
{
    internal class PdfPageTree : PdfObject
    {
        #region Singleton

        private static PdfPageTree _pdfPageTree;
        private static Object _object = new Object();

        private PdfPageTree() : base()
        {
            _pages = new List<PdfPage>();
        }

        internal static PdfPageTree GetPdfPageTree()
        {
            if (_pdfPageTree == null)
            {
                lock (_object)
                {
                    if (_pdfPageTree == null)
                    {
                        _pdfPageTree = new PdfPageTree();
                    }
                }
            }

            return _pdfPageTree;
        }

        #endregion

        private List<PdfPage> _pages;

        public override Byte[] ToPDF()
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

            return Encoding.UTF8.GetBytes(pdf);
        }

        public void AddPage(PdfPage page)
        {
            _pages.Add(page);
        }
    }
}
