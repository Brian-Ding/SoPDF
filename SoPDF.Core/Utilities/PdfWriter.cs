using SoPDF.Core.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoPDF.Core.Utilities
{
    internal class PdfWriter
    {
        #region Singleton

        private static PdfWriter _pdfWriter;
        private static Object _object = new Object();

        private PdfWriter()
        {
            _pdfObjects = new List<PdfObject>();
        }

        internal static PdfWriter GetWriter()
        {
            if (_pdfWriter == null)
            {
                lock (_object)
                {
                    if (_pdfWriter == null)
                    {
                        _pdfWriter = new PdfWriter();
                    }
                }
            }

            return _pdfWriter;
        }

        #endregion

        private List<PdfObject> _pdfObjects;
        private PdfRefTable _refTable;

        internal void AddPdfObject(PdfObject pdfObject)
        {
            _pdfObjects.Add(pdfObject);
        }

        internal Byte[] ToBytes()
        {
            if (_pdfObjects == null || _pdfObjects.Count == 0)
            {
                throw new Exception("The PDF file's structure is corrupted!");
            }

            Byte[][] bytes = new Byte[_pdfObjects.Count][];
            _refTable = PdfRefTable.GetPdfRefTable();
            Int32 offset = 0;
            for (Int32 i = 0; i < _pdfObjects.Count; i++)
            {
                bytes[i] = Encoding.UTF8.GetBytes(_pdfObjects[i].ToPDF());
                offset += bytes[i].Length;
                _refTable.Add(offset);
            }

            return CombineBytes(bytes, offset);
        }

        private Byte[] CombineBytes(Byte[][] bytes, Int32 length)
        {
            Byte[] combined = new Byte[length];

            Int32 index = 0;
            for (int i = 0; i < bytes.Length; i++)
            {
                for (int j = 0; j < bytes[i].Length; j++)
                {
                    combined[j + index] = bytes[i][j];
                }
                index += bytes[i].Length;
            }

            return combined;
        }
    }
}
