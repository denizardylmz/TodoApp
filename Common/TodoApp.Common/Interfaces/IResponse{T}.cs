using TodoApp.Common.Responses;

namespace TodoApp.Common.Interfaces;

public interface IResponse<T> : IResponse
{
    public T Data { get; set; }
    
    public List<CustomValidationError> ValidationErrors { get; set; }
}