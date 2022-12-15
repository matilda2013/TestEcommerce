using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AngEcommerceApi.Helper
{
    public class ApiResponse 
    {

        public ApiResponse(int statuscode, string msg = null)
        {
            StatusCode = statuscode;
            Message = msg ?? GetDefaultMessageForStatusCode(StatusCode);
        }
        public int StatusCode { get; set; }
        public string Message { get; set; }

        private string GetDefaultMessageForStatusCode(int statusCode)
        {
            return statusCode switch
            {
                400 => "A Badrequest",
                401 => "Unauthorized",
                404 => "Resource not Found",
                500 => "Internal Server Error"
            };
        }
    }


}
