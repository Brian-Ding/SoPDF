using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoPDF.Core.Objects
{
    public class PdfObject
    {
        private static Int32 _objectNum = 0;

        public Int32 ObjectNum { get; protected set; }
        public Int32 GenerationNum { get; protected set; }

        // this is a constructor
        public PdfObject()
        {
            ObjectNum = ++_objectNum;
            GenerationNum = 0;
        }

        public virtual string ToPDF()
        {
            throw new NotImplementedException();
        }

        public String GetRefStr()
        {
            return ObjectNum.ToString() + " " + GenerationNum.ToString() + " R";
        }
    }
}
