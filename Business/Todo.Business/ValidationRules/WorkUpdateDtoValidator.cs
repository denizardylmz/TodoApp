using FluentValidation;
using TodoApp.DTOs.WorkDtos;

namespace Todo.Business.ValidationRules;

public class WorkUpdateDtoValidator : AbstractValidator<WorkUpdateDto>
{
    public WorkUpdateDtoValidator()
    {
        RuleFor(w => w.Definition)
            .NotEmpty()
            .NotNull()
                .WithMessage("Definition is required");

        RuleFor(w => w.Id)
            .NotEmpty()
            .NotNull()
                .WithMessage("Id is required");
    }
}