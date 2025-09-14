﻿using Microsoft.AspNetCore.Diagnostics;
using System.Net;
using System.Text.Json;
using TalentDataTracker.Application.Exceptions;

namespace TalentDataTracker.API.Extensions
{
    public static class MiddlewareExtensions
    {
        internal static void UseGlobalExceptionHandler(this WebApplication app, ILogger<Program> logger)
        {
            app.UseExceptionHandler(builder =>
            {
                builder.Run(async context =>
                {
                    context.Response.ContentType = "application/json";
                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();

                    if(contextFeature != null )
                    {
                        logger.LogError("An error occurred: {Error}", contextFeature.Error);
                        var message = "An unexpected error occurred.";
                        switch (contextFeature.Error)
                        {
                            case BadRequestException: 
                                context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                                message = contextFeature.Error.Message;
                                break;
                            case NotFoundException:
                                context.Response.StatusCode = (int)HttpStatusCode.NotFound;
                                message = contextFeature.Error.Message;
                                break;
                            default:
                                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                                break;
                        }

                        await context.Response.WriteAsync(JsonSerializer.Serialize(new ErrorResponse
                        {
                            Status = context.Response.StatusCode,
                            Message = message
                        }));
                    }
                });
            });
        }
    }
}
