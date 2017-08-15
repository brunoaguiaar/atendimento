using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Atendimento.Controllers
{
    public abstract class ControllerBase : ApiController
    {
        public HttpResponseMessage ResponderOK(object result = null)
        {
            return Request.CreateResponse(HttpStatusCode.OK, new { result });
        }
    }
}
