using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Faradid.Tracking.Domain.Entities.ApiResult
{
    public class ApiResult
    {
        public HttpStatusCode StatusCode { get; set; }
        public object Result { get; set; }
        public bool IsSuccess { get; set; }
        public List<string> ErrorMessages { get; set; }
    }
}
