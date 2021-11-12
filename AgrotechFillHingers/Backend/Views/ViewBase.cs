using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgrotechFillHingers.Backend.Views
{
    public abstract class ViewBase
    {
        public string GetConnectionString()
        {
            return "";
        }

    }

    [Serializable]
    class InnerViewException : Exception
    {
        public InnerViewException() { }

        public InnerViewException(string errorText): base(errorText)
        {

        }
    }
}
