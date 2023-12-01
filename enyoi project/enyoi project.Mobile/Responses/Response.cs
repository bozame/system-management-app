using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace enyoi_project.Mobile.Responses
{
    public class Response
    {

        public bool IsSuccess { get; set; }

        public String Message { get; set; }

        public object Result { get; set; }
    }
}
