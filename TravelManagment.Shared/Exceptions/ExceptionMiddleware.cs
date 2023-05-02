using Microsoft.AspNetCore.Http;
using System.Text.Json;
using TravelManagement.Shared.Abstractions.Exceptions;

namespace TravelManagement.Shared.Exceptions
{
    internal sealed class ExceptionMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
			try
			{
				await next(context);
			}
			catch (TravelerCheckListException ex)
			{
				context.Response.StatusCode = 400;
				context.Response.Headers.Add("content-type","application/json");

				var errorCode = ToUnderScoreCase(ex.GetType().Name.Replace("Exception", string.Empty));
                var json = JsonSerializer.Serialize(new { ErrorCode = errorCode, ex.Message });
				await context.Response.WriteAsync(json);
			}
        }

        public static string ToUnderScoreCase(string value)
            => string.Concat((value ?? string.Empty).Select((x, i) => i > 0 && char.IsUpper(x) && !char.IsUpper(value[i - 1]) ? $"_{x}" : x.ToString())).ToLower();

    }
}
