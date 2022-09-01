using FluentValidation;
using TodoApp.DTOs.WorkDtos;

namespace Todo.Business.ValidationRules;

public class WorkCreateDtoValidator : AbstractValidator<WorkCreateDto>
{
    public WorkCreateDtoValidator()
    {
        RuleFor(w => w.Definition)
            .NotEmpty()
            .NotNull()
                .WithMessage("Definition is required");
    }
}