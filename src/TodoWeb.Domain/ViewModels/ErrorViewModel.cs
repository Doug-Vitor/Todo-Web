using System.Collections.Generic;
using System.Net;

namespace TodoWeb.Domain.ViewModels
{
    public class ErrorViewModel
    {
        public HttpStatusCode StatusCode { get; set; }
        public List<string> ErrorsMessage { get; set; } = new();

        public ErrorViewModel()
        {
        }

        public ErrorViewModel(HttpStatusCode statusCode, string errorMessage)
        {
            StatusCode = statusCode;
            ErrorsMessage.Add(errorMessage);
        }

        public ErrorViewModel(HttpStatusCode statusCode, List<string> errorsMessage)
        {
            StatusCode = statusCode;
            ErrorsMessage = errorsMessage;
        }
    }
}
