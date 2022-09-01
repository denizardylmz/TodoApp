using TodoApp.Common.Interfaces;

namespace TodoApp.Common.Responses;

public class Response : IResponse 
{
    public Response(ResponseType responseType)
    {
        ResponseType = responseType;
    }

    public Response(string message, ResponseType responseType) : this(responseType)
    {
        Message = message;
    }
    
    public string? Message { get; set; }
    
    public ResponseType ResponseType { get; set; }
}

public enum ResponseType
{
    Success,
    ValidationError,
    NotFound
}