using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoPDF.Core.Objects
{
    internal class PdfPage : PdfObject
    {
        private PageSize _pageSize;
        private PdfObject _resource;
        private List<PdfObject> _contents;

        public PdfPage() : base()
        {
            _pageSize = new PageSize(8.5, 11);
            _contents = new List<PdfObject>();
        }

        public override Byte[] ToPDF()
        {
            String pdf = String.Empty;

            pdf += ObjectNum.ToString() + " " + GenerationNum.ToString() + "obj" + "\n";
            pdf += "<< /Type /Page" + "\n";
            pdf += "/MediaBox [0 0 " + _pageSize.Width.ToString() + " " + _pageSize.Height.ToString() + "]" + "\n";
            pdf += "/Resources " + _resource.GetRefStr() + "\n";
            pdf += "/Contents [";

            String contentsStr = String.Empty;
            foreach (PdfObject pdfObject in _contents)
            {
                contentsStr += pdfObject.GetRefStr() + " ";
            }
            pdf += contentsStr.TrimEnd(' ');
            pdf += "]" + "\n";

            pdf += ">>" + "\n";
            pdf += "endobj" + "\n";

            return Encoding.UTF8.GetBytes(pdf);
        }

        public void AddContent(PdfStream stream)
        {
            _contents.Add(stream);
        }

        public void SetFont(PdfFont font)
        {
            _resource = font;
        }
    }

    public struct PageSize
    {
        public Int32 Width { get; private set; }
        public Int32 Height { get; private set; }

        public PageSize(Double width, Double height)
        {
            Height = (Int32)(height * 72);
            Width = (Int32)(width * 72);
        }
    }
}
