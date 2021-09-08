using System.Collections.Generic;
using System.Net;

namespace MediatrEntity.Entity.ReturnMessage
{
    public class RequestResult
    {
        public RequestResult(HttpStatusCode resultCode, List<string> message, string resultType)
        {
            ResultCode = resultCode;
            Message = message;
            ResultType = resultType;
        }

        public HttpStatusCode ResultCode { get; set; }
        public List<string> Message { get; set; }
        public string ResultType { get; set; }
    }
}
