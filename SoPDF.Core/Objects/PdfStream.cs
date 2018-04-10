using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoPDF.Core.Objects
{
    internal class PdfStream : PdfObject
    {
        private String _content;

        public PdfStream(String content) : base()
        {
            _content = content;
        }

        public override byte[] ToPDF()
        {
            String stream = String.Empty;
            stream += "BT" + "\n";
            stream += "/F0 36 Tf" + "\n";
            stream += "50 706 Td" + "\n";
            stream += "(" + _content + ") Tj" + "\n";
            stream += "ET" + "\n";


            String pdf = String.Empty;

            pdf += ObjectNum.ToString() + " " + GenerationNum.ToString() + "obj" + "\n";
            pdf += "<< /Length " + Encoding.UTF8.GetBytes(stream).Length.ToString() + "\n";
            pdf += ">>" + "\n";
            pdf += "stream" + "\n";
            pdf += "endstream" + "\n";
            pdf += "endobj" + "\n";

            return Encoding.UTF8.GetBytes(stream);
        }
    }
}
