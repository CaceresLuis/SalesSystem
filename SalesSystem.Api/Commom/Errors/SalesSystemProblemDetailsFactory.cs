using ErrorOr;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using SalesSystem.Api.Commom.Http;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace SalesSystem.Api.Commom.Errors
{
    public class SalesSystemProblemDetailsFactory : ProblemDetailsFactory
    {
        private readonly ApiBehaviorOptions _options;

        public SalesSystemProblemDetailsFactory(ApiBehaviorOptions options)
        {
            _options = options ?? throw new ArgumentNullException(nameof(options));
        }

        public override ProblemDetails CreateProblemDetails(HttpContext httpContext, int? statusCode = null, string? title = null, string? type = null, string? detail = null, string? instance = null)
        {
            statusCode ??= 500;

            ProblemDetails problemDetails = new()
            {
                Status = statusCode,
                Title = title,
                Type = type,
                Detail = detail,
                Instance = instance
            };

            ApplyProblemDetailsDefaults(httpContext, problemDetails, statusCode.Value);

            return problemDetails;
        }

        public override ValidationProblemDetails CreateValidationProblemDetails(HttpContext httpContext, ModelStateDictionary modelStateDictionary, int? statusCode = null, string? title = null, string? type = null, string? detail = null, string? instance = null)
        {
            if (modelStateDictionary is null)
                throw new ArgumentNullException(nameof(modelStateDictionary));

            statusCode ??= 400;

            ValidationProblemDetails problemDetails = new(modelStateDictionary)
            {
                Status = statusCode,
                Type = type,
                Detail = detail,
                Instance = instance
            };

            if (title is not null)
                problemDetails.Title = title;

            ApplyProblemDetailsDefaults(httpContext, problemDetails, statusCode.Value);

            return problemDetails;
        }

        private void ApplyProblemDetailsDefaults(HttpContext httpContext, ProblemDetails problemDetails, int statusCode)
        {
            problemDetails.Status ??= statusCode;

            if (_options.ClientErrorMapping.TryGetValue(statusCode, out ClientErrorData? clientErrorData))
            {
                problemDetails.Title ??= clientErrorData.Title;
                problemDetails.Type ??= clientErrorData.Link;
            }

            string traceId = Activity.Current?.Id ?? httpContext.TraceIdentifier;
            if (traceId is not null)
                problemDetails.Extensions["traceId"] = traceId;

            List<Error>? errors = httpContext?.Items[HttpContextItemKeys.Errors] as List<Error>;
            if (errors is not null)
                problemDetails.Extensions.Add("errorCodes", errors.Select(e => e.Code));
        }
    }
}
