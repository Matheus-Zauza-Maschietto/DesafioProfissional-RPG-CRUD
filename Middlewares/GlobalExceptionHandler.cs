using System.Net;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.EntityFrameworkCore;
using RpgApi.DTOs;

namespace RpgApi.Middlewares;

public class GlobalExceptionHandler : IExceptionHandler
{
    public async ValueTask<bool> TryHandleAsync(
            HttpContext context,
            Exception exception,
            CancellationToken cancellationToken
        )
    {
        ResponsePattern response;
        if (exception.GetType() == typeof(ApplicationException))
        {
            response = new ResponsePattern(exception.Message);
            context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
        }
        else
        {
            response = new ResponsePattern("Houve um erro na api, por favor tente novamente mais tarde.");
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
        }
        
        await context.Response.WriteAsJsonAsync(response, cancellationToken);
        return true;
    }
}