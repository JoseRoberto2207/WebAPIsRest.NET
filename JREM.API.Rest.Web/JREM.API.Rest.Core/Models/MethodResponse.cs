using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JREM.API.Rest.Core
{
    public class MethodResponse<T>
    {
        public object Code { get; set; }
        public object Message { get; set; }
        public object Result { get; set; }
    }
}
