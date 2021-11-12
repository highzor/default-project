using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgrotechFillHingers.Backend.Helpers
{
    public class ReturnTypeAttribute:Attribute
    {
        public ReturnTypeAttribute(Type t)
        {

        }
    }
}
