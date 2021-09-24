using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using SistemaBusquedaHoteles.Api.Infrastructure.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaBusquedaHoteles.Api.Infrastructure.Filters
{
    public class ValidationFilter : IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            if (!context.ModelState.IsValid)
            {
                var errorsInModelState = context.ModelState
                    .Where(p => p.Value.Errors.Count > 0)
                    .ToDictionary(keyValuePair => keyValuePair.Key, keyValuePair => keyValuePair.Value.Errors.Select(p => p.ErrorMessage)).ToArray();

                var errorResponse = new ErrorResponse();

                foreach (var error in errorsInModelState)
                {
                    foreach (var subError in error.Value)
                    {
                        var errorModel = new Error
                        {
                            FieldName = error.Key,
                            Message = subError
                        };

                        errorResponse.Errors.Add(errorModel);
                    }
                }
                context.Result = new BadRequestObjectResult(errorResponse);

                return;
            }

            await next();
        }
    }
}
