using AutoMapper;
using Todo.Entities.Domains;
using TodoApp.DTOs.WorkDtos;

namespace Todo.Business.Mappings;

public class WorkProfile : Profile
{
    public WorkProfile()
    {
        CreateMap<Work, WorkListDto>().ReverseMap();
        CreateMap<Work, WorkUpdateDto>().ReverseMap();
        CreateMap<Work, WorkCreateDto>().ReverseMap();
        CreateMap<WorkListDto, WorkUpdateDto>().ReverseMap();
    }
    
}