using TodoApp.Common.Interfaces;

namespace TodoApp.Common.Responses;

public class Response<T> : Response, IResponse<T>
{
    public T Data { get; set; }
    public List<CustomValidationError> ValidationErrors { get; set; }

    public Response(ResponseType responseType, T data) : base(responseType)
    {
        Data = data;
    }
    
    public Response(ResponseType responseType, T data, List<CustomValidationError> errors) : base(responseType)
    {
        Data = data;
        ValidationErrors = errors;
    }

    public Response(string message, ResponseType responseType) : base(message, responseType)
    {
    }
    
    
    
}