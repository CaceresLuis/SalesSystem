﻿using Microsoft.AspNetCore.Mvc;
using SalesSystem.Api.Commom.Http;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace SalesSystem.Api.Controllers
{
    [ApiController]
    public class ApiController : ControllerBase
    {
        protected IActionResult Problem(List<Error> errors)
        {
            if (errors.Count is 0)
                return Problem();

            if (errors.All(error => error.Type == ErrorType.Validation))
                return ValidationProblem(errors);

            HttpContext.Items[HttpContextItemKeys.Errors] = errors;

            return Problem(errors[0]);
        }

        private IActionResult Problem(Error error)
        {
            int statusCode = error.Type switch
            {
                ErrorType.Conflict => StatusCodes.Status409Conflict,
                ErrorType.NotFound => StatusCodes.Status404NotFound,
                _ => StatusCodes.Status500InternalServerError
            };

            return Problem(statusCode: statusCode, title: error.Code, detail: error.Description);
        }

        private IActionResult ValidationProblem(List<Error> errors)
        {
            ModelStateDictionary modelStateDictionary = new();

            foreach (Error error in errors)
            {
                modelStateDictionary.AddModelError(error.Code, error.Description);
            }

            return ValidationProblem(modelStateDictionary);
        }
    }
}
