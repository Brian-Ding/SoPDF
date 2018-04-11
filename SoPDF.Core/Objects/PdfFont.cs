using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoPDF.Core.Objects
{
    internal class PdfFont : PdfObject
    {
        private String _font;
        private String _type;

        public PdfFont() : base()
        {
            _font = "Times-Roman";
            _type = "Type1";
        }

        public override String ToPDF()
        {
            String pdf = String.Empty;

            pdf += ObjectNum.ToString() + " " + GenerationNum.ToString() + " obj " + "\n";
            pdf += "<<" + "\n";
            pdf += "/Font " + "\n";
            pdf += "<<" + "\n";
            pdf += "/F0 " + "\n";
            pdf += "<<" + "\n";
            pdf += "/BaseFont /" + _font + "\n";
            pdf += "/Subtype /" + _type + "\n";
            pdf += "/Type /Font" + "\n";
            pdf += ">>" + "\n";
            pdf += ">>" + "\n";
            pdf += ">>" + "\n";
            pdf += "endobj " + "\n";

            return pdf;
        }
    }
}
