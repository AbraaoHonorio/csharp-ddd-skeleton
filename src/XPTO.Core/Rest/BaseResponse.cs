using System.Collections.Generic;
using System.Net;

namespace XPTO.Core.Rest
{
    public abstract class BaseResponse<TResponse>
    {
        public HttpStatusCode Status { get; set; }
        public TResponse Response { get; set; }
        public IEnumerable<string> Errors { get; set; }

        public BaseResponse<TResponse> GetObject() => this;
    }
}