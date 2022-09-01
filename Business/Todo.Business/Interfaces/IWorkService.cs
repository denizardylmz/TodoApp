using Todo.Entities.Domains;
using TodoApp.Common.Interfaces;
using TodoApp.DTOs.Interfaces;
using TodoApp.DTOs.WorkDtos;

namespace Todo.Business.Interfaces;

public interface IWorkService
{
    Task<IResponse<List<WorkListDto>>> GetAll();
    Task<IResponse<WorkCreateDto>> Create(WorkCreateDto data);

    Task<IResponse<IDto>> GetById<IDto>(string id, bool asNoTracking = true);

    Task<IResponse> RemoveAsync(string id);

     Task<IResponse<WorkUpdateDto>> Update(WorkUpdateDto dto);

}