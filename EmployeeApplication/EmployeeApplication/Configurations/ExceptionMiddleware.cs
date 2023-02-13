using Microsoft.AspNetCore.Diagnostics;
using EmployeeApplication.Core.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeApplication.Configurations
{
    public static class ExceptionMiddleware
    {
        public static void AddExceptionHandler(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(appError =>
            {
                appError.Run(async context =>
                {
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    context.Response.ContentType = "application/json";
                    var contextFeature = context.Features.Get <IExceptionHandlerFeature>();
                    if(contextFeature!=null)
                    {
                        context.Response.StatusCode = contextFeature.Error switch
                        {
                            NotFoundException => StatusCodes.Status404NotFound,
                            BadRequestException=>StatusCodes.Status400BadRequest,
                            _=>StatusCodes.Status500InternalServerError
                        };
                        await context.Response.WriteAsync(new ErrorDetails()
                        {
                            StatusCode=context.Response.StatusCode,
                            Message=contextFeature.Error.Message,
                        }.ToString());
                    }

                });
            });
        }
    }
}
