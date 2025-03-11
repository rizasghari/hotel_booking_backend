using System;
using System.ComponentModel.DataAnnotations;
using HotelBooking.App.Dtos;
using HotelBooking.src.App.Dtos;

namespace HotelBooking.src.Api.Filters;

public class CreateCategoryFilter : IEndpointFilter
{
    public async ValueTask<object?> InvokeAsync(EndpointFilterInvocationContext context, EndpointFilterDelegate next)
    {
        var createCategoryDto = context.GetArgument<CreateCategoryDto>(0);
        var validationResults = new List<ValidationResult>();
        var validationContext = new ValidationContext(createCategoryDto);
        bool isValid = Validator.TryValidateObject(createCategoryDto, validationContext, validationResults, true);
        if (!isValid)
        {
            return Results.BadRequest(new ApiResponse<dynamic>
            {
                Successful = false,
                Errors = [.. validationResults.Select(x => x.ErrorMessage)]
            });
        }

        return await next(context);
    }
}
