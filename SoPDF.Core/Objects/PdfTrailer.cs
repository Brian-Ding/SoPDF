using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoPDF.Core.Objects
{
    internal class PdfTrailer
    {
        #region Singleton

        private static PdfTrailer _pdfTrailer;
        private static Object _object = new Object();

        private PdfTrailer() { }
        internal static PdfTrailer GetPdfTrailer()
        {
            if (_pdfTrailer == null)
            {
                lock (_object)
                {
                    if (_pdfTrailer == null)
                    {
                        _pdfTrailer = new PdfTrailer();
                    }
                }
            }

            return _pdfTrailer;
        }

        internal Byte[] ToPdf()
        {
            String pdf = String.Empty;
            pdf += "trailer" + "\n" + "\n";
            pdf += "<<" + "\n";
            pdf += "/Root " + PdfCatalog.GetPdfCatalog().GetRefStr() + "\n";
            pdf += "/Size " +/* (_buffers.Count - 1).ToString() +*/ "\n";
            pdf += ">>" + "\n";
            pdf += "startxref" + "\n" + _offset.ToString() + "\n" + "%%EOF\n";
        }

        #endregion
    }
}
