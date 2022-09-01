using TodoApp.Common.Responses;

namespace TodoApp.Common.Interfaces;

public interface IResponse
{
     string Message { get; set; }
     
     ResponseType ResponseType { get; set; }
}