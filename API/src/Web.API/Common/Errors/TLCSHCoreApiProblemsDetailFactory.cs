﻿using ErrorOr;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Diagnostics;
using Web.API.Common.Http;

namespace Web.API.Common.Errors;

public class TLCSHCoreApiProblemsDetailFactory : ProblemDetailsFactory
{
    private readonly ApiBehaviorOptions _options;

    public TLCSHCoreApiProblemsDetailFactory(ApiBehaviorOptions options)
    {
        _options = options ?? throw new ArgumentNullException(nameof(options));
    }

    public override ProblemDetails CreateProblemDetails(
        HttpContext httpContext, 
        int? statusCode = null, 
        string? title = null, 
        string? type = null, 
        string? detail = null, 
        string? instance = null
        )
    {
        statusCode ??= 500;

        var problemDetails = new ProblemDetails
        {
            Status = statusCode,
            Title = title,
            Type = type,
            Detail = detail,
            Instance = instance
        };

        ApplyProblemsDetailsDefauls(httpContext, problemDetails, statusCode.Value);

        return problemDetails;
    }

    public override ValidationProblemDetails CreateValidationProblemDetails(
        HttpContext httpContext,
        ModelStateDictionary modelStateDictionary,
        int? statusCode = null,
        string? title = null,
        string? type = null,
        string? detail = null,
        string? instance = null)
    {
        if (modelStateDictionary == null)
            throw new ArgumentNullException(nameof(modelStateDictionary));

        statusCode ??= 400;

        var problemDetails= new ValidationProblemDetails(modelStateDictionary)
        {
            Status = statusCode,
            Type = type,
            Detail = detail,
            Instance = instance
        };

        if (title != null)
            problemDetails.Title = title;

        ApplyProblemsDetailsDefauls(httpContext, problemDetails, statusCode.Value);

        return problemDetails;
    }

    private void ApplyProblemsDetailsDefauls (HttpContext httpContext, ProblemDetails problemDetails, int statusCode)
    {
        problemDetails.Status ??= statusCode;

        if (_options.ClientErrorMapping.TryGetValue(statusCode, out var clientErrorData))
        {
            problemDetails.Title ??= clientErrorData.Title;
            problemDetails.Type ??= clientErrorData.Link;
        }

        var traceID = Activity.Current?.Id ?? httpContext.TraceIdentifier;

        if(traceID != null)
        {
            problemDetails.Extensions["traceId"] = traceID;
        }

        var errors = httpContext?.Items[HttpContextItemKeys.Errors] as List<Error>;

        if(errors is not null)
        {
            problemDetails.Extensions.Add("errorCodes", errors.Select(e => e.Code));
        }
    }
}
