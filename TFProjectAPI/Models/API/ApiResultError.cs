using System;
using System.Net;

namespace TFProjectAPI.Models.API
{
    public class ApiResultError
    {
        private int _statusCode;
        private string _errorMessage;

        public ApiResultError(HttpStatusCode statusCode, Exception e)
        {
            StatusCode = (int)statusCode;
            ErrorMessage = e.Message;
        }
        public int StatusCode
        {
            get
            {
                return _statusCode;
            }

            set
            {
                _statusCode = value;
            }
        }

        public string ErrorMessage
        {
            get
            {
                return _errorMessage;
            }

            set
            {
                _errorMessage = value;
            }
        }
    }
}
