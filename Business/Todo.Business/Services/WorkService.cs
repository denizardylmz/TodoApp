using AutoMapper;
using FluentValidation;
using Microsoft.EntityFrameworkCore.Storage;
using Todo.Business.Extensions;
using Todo.Business.Interfaces;
using Todo.DataAccess.Interfaces;
using Todo.Entities.Domains;
using TodoApp.Common.Interfaces;
using TodoApp.Common.Responses;
using TodoApp.DTOs.Interfaces;
using TodoApp.DTOs.WorkDtos;

namespace Todo.Business.Services;

public class WorkService : IWorkService
{
    private readonly IUow _uow;
    private readonly IMapper _mapper;
    private readonly IValidator<WorkCreateDto> _createValidator;
    private readonly IValidator<WorkUpdateDto> _updateValidator;

    public WorkService(
        IUow uow,
        IMapper mapper,
        IValidator<WorkCreateDto> createValidator,
        IValidator<WorkUpdateDto> updateValidator)
    {
        _uow = uow;
        _mapper = mapper;
        _createValidator = createValidator;
        _updateValidator = updateValidator;
    }
    
    public async Task<IResponse<List<WorkListDto>>> GetAll()
    {
        var list = _uow.GetRepository<Work>().GetAll().OrderBy(x=> x.Id).ToList();
        if (list.Count != 0)
        {
            var mappedList = _mapper.Map<List<WorkListDto>>(list);
            return new Response<List<WorkListDto>>(ResponseType.Success, mappedList);
        }

        return new Response<List<WorkListDto>>("Not Found", ResponseType.NotFound);

    }

    public async Task<IResponse<WorkCreateDto>> Create(WorkCreateDto dto)
    {
        var validationResult = _createValidator.Validate(dto);
        if (validationResult.IsValid)
        {
            using (IDbContextTransaction transaction = _uow.BeginTransaction())
            {
                var result = _uow.GetRepository<Work>().Create(_mapper.Map<Work>(dto));
                await transaction.CommitAsync();
                await _uow.SaveAsync();
                return new Response<WorkCreateDto>(ResponseType.Success, dto);
            }    
        }
        return new Response<WorkCreateDto>(ResponseType.ValidationError, dto, validationResult.ConvertToValidationError());
        
    }

    public async Task<IResponse<IDto>> GetById<IDto>(string id, bool asNoTracking = true)
    {
        var work = _uow.GetRepository<Work>().GetByFilter(x => x.Id == int.Parse(id) , asNoTracking );
        var data = _mapper.Map<IDto>(work);

        if (data != null)
        {
            return new Response<IDto>(ResponseType.Success, data);
        }

        return new Response<IDto>("Not Found", ResponseType.NotFound);
    }

    public async Task<IResponse> RemoveAsync(string id)
    {
       
        var entityToRemove = _uow.GetRepository<Work>().GetById(id);
        if (entityToRemove != null)
        {
            using (IDbContextTransaction transaction = _uow.BeginTransaction())
            {

                var result = _uow.GetRepository<Work>().Remove(entityToRemove);
                await transaction.CommitAsync();
                await _uow.SaveAsync();
                
                return new Response(ResponseType.Success);
            }    
        }
        else
        {
            return new Response(ResponseType.NotFound);
        }
        
        
    }

    public async Task<IResponse<WorkUpdateDto>> Update(WorkUpdateDto dto)
    {
        var validationResult = _updateValidator.Validate(dto);

        if (validationResult.IsValid)
        {
            var entityToUpdate = _uow.GetRepository<Work>().GetById(dto.Id.ToString());
            if (entityToUpdate != null)
            {
                using (IDbContextTransaction transaction = _uow.BeginTransaction())
                {
                    _uow.GetRepository<Work>().Update(_mapper.Map<Work>(dto), entityToUpdate);
                    await transaction.CommitAsync();
                    await _uow.SaveAsync();
                }

                return new Response<WorkUpdateDto>(ResponseType.Success, dto);
            }

            return new Response<WorkUpdateDto>(ResponseType.NotFound, dto);

        }
        return new Response<WorkUpdateDto>(ResponseType.ValidationError, dto, validationResult.ConvertToValidationError());


        }
}