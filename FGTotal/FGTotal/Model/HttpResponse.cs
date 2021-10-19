using System.Net;

namespace FGTotal.Model
{
    public class HttpResponse
    {
        public string Content { get; set; }

        public HttpStatusCode HttpStatusCode { get; set; }
    }
}
