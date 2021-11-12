using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgrotechFillHingers.Backend.Helpers
{
    public class DbTypeAttribute : Attribute
    {
        public Type type { get; set; }
        public string format { get; set; }

        public DbTypeAttribute(Type _type, string _format)
        {
            type = _type;
            format = _format;
        }
    }
}
