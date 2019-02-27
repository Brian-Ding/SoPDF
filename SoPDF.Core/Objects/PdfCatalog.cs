using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoPDF.Core.Objects
{
    internal class PdfCatalog : PdfObject
    {
        #region Singleton

        private static Object _object = new Object();
        private static PdfCatalog _pdfCatalog;

        private PdfCatalog() : base() { }

        internal static PdfCatalog GetPdfCatalog()
        {
            if (_pdfCatalog == null)
            {
                lock (_object)
                {
                    if (_pdfCatalog == null)
                    {
                        _pdfCatalog = new PdfCatalog();
                    }
                }
            }

            return _pdfCatalog;
        }

        #endregion

        public override Byte[] ToPDF()
        {
            String pdf = String.Empty;

            pdf += ObjectNum.ToString() + " " + GenerationNum.ToString() + " obj " + "\n";
            pdf += "<<" + "\n";
            pdf += "/Pages " + _pageTree.GetRefStr() + "\n";
            pdf += "/Type /Catalog" + "\n";
            pdf += ">>" + "\n";
            pdf += "endobj " + "\n";

            return Encoding.UTF8.GetBytes(pdf);
        }
    }
}
