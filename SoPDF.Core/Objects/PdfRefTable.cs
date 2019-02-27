using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoPDF.Core.Objects
{
    internal class PdfRefTable
    {
        #region Singleton

        private static PdfRefTable _pdfRefTable;
        private static Object _object = new Object();

        private PdfRefTable() { }

        internal static PdfRefTable GetPdfRefTable()
        {
            if (_pdfRefTable == null)
            {
                lock (_object)
                {
                    if (_pdfRefTable == null)
                    {
                        _pdfRefTable = new PdfRefTable();
                    }
                }
            }

            return _pdfRefTable;
        }

        #endregion


        private String _head = "xref\n";
        private String _table = "0000000000 65535 f \n";
        private Int32 _count = 0;


        internal void Add(Int32 offset)
        {
            _table += offset.ToString().PadLeft(10, '0') + " " + "00000" + " " + "n " + "\n";
            _count++;
        }


        internal Byte[] ToBytes()
        {
            return Encoding.UTF8.GetBytes(_head + "0 " + _count.ToString() + "\n" + _table);
        }
    }
}
