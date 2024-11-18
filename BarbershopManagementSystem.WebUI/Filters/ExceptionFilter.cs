﻿using BarbershopManagementSystem.WebUI.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;

namespace BarbershopManagementSystem.WebUI.Filters;

public class ExceptionFilter : IExceptionFilter
{
    public void OnException(ExceptionContext context)
    {
        if (context.Exception is HttpRequestException apiException)
        {
            var code = GetStatusCode(apiException.StatusCode);
            context.Result = new RedirectToActionResult("ErrorHandler", "Home", new { statusCode = code });
            context.ExceptionHandled = true;
        }
        else if (context.Exception is UnauthorizedException)
        {
            context.Result = new RedirectToActionResult("ErrorHandler", "Home", new { statusCode = 401 });
            context.ExceptionHandled = true;
        }
        else
        {
            context.Result = new RedirectToActionResult("ErrorHandler", "Home", new { statusCode = 500 });
            context.ExceptionHandled = true;
        }
    }

    private static int GetStatusCode(HttpStatusCode? code) =>
        code switch
        {
            HttpStatusCode.NotFound => 404,
            HttpStatusCode.Unauthorized => 401,
            HttpStatusCode.Forbidden => 403,
            _ => 500
        };
}
