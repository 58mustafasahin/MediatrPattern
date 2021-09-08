using System.Collections.Generic;
using System.Net;

namespace MediatrEntity.Entity.ReturnMessage
{
    public class GetReturnMessageResult<T>
    {
        public GetReturnMessageResult(HttpStatusCode resultCode, T result, string resultType)
        {
            ResultCode = resultCode;
            Result = result;
            ResultType = resultType;
        }

        public GetReturnMessageResult(HttpStatusCode resultCode, List<string> message, string resultType)
        {
            ResultCode = resultCode;
            Message = message;
            ResultType = resultType;
        }

        public HttpStatusCode ResultCode { get; set; }
        public T Result { get; set; }
        public List<string> Message { get; set; }
        public string ResultType { get; set; }
    }
}
