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

        public override String ToPDF()
        {
            String stream = String.Empty;
            stream += "BT" + "\n";
            stream += "/F0 36 Tf" + "\n";
            stream += "50 706 Td" + "\n";
            stream += "(" + _content + ") Tj" + "\n";
            stream += "ET " + "\n";


            String pdf = String.Empty;

            pdf += ObjectNum.ToString() + " " + GenerationNum.ToString() + " obj " + "\n";
            pdf += "<<" + "\n";
            pdf += "/Length " + stream.Length.ToString() + "\n";
            pdf += ">>" + "\n";
            pdf += "stream" + "\n";
            pdf += stream;
            pdf += "endstream " + "\n";
            pdf += "endobj " + "\n";

            return pdf;
        }
    }
}
