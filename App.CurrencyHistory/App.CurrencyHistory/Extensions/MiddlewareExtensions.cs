using System;
using System.Net;
using App.CurrencyHistory.Common.Responses;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace App.CurrencyHistory.Extensions
{
    public static class MiddlewareExtensions
    {
        public static void RegisterExceptionHandler(this IApplicationBuilder application)
        {
            application.UseExceptionHandler(appError =>
            {
                appError.Run(async context =>
                {
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    context.Response.ContentType = "application/json";
                    await context.Response.WriteAsync(new ErrorResponse() { Code = context.Response.StatusCode, Message = "Internal Server Error" }.ToString());
                });
            });
        }
    }
}
