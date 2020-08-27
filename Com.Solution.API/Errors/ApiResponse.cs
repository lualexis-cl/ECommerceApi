using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Com.Solution.API.Errors
{
    public class ApiResponse
    {
        public ApiResponse(int statusCode, string message = null)
        {
            StatusCode = statusCode;
            Message = message ?? DefaultStatusMessage(StatusCode);
        }
        public int StatusCode { get; set; }
        public string Message { get; set; }

        private string DefaultStatusMessage(int status)
        {
            return status switch
            {
                400 => "A bad request, you have made",
                401 => "Authorized, you are not",
                404 => "Resource Found, it was not",
                500 => "Errors",
                _ => null
            };
        }
    }
}
