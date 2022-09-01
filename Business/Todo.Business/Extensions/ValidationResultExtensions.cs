using FluentValidation.Results;
using TodoApp.Common.Responses;

namespace Todo.Business.Extensions;

public static class ValidationResultExtensions
{
    public static List<CustomValidationError> ConvertToValidationError(this ValidationResult validationResult)
    {
        List<CustomValidationError> errors = new();
        foreach (var error in validationResult.Errors)
        {
            errors.Add(new CustomValidationError()
            {
                ErrorMessage = error.ErrorMessage,
                ProperyName = error.PropertyName
            });
        }

        return errors;
    }
}