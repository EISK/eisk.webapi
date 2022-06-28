using System.Globalization;
using System.Net;
using System.Text.Json;

namespace Eisk.WebApi.Middlewares
{
    internal record ApiError(string Id, int StatusCode, string Message)
    {
        public override string ToString() => JsonSerializer.Serialize(this);
    }

    public record ApiExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public ApiExceptionHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext ctx)
        {
            try
            {
                await _next(ctx).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                // Log Exception Message
                // var message = string.Format(GetInnermostExceptionMessage(ex), CultureInfo.CurrentCulture);
                await HandleExceptionAsync(ctx, ex);
            }
        }
        private static async Task HandleExceptionAsync(HttpContext ctx, Exception ex)
        {
            const int statusCode = (int) HttpStatusCode.InternalServerError;
            ApiError apiError = new(
                Guid.NewGuid().ToString(),
                statusCode,
                "Internal Server Error.");

            ctx.Response.StatusCode = statusCode;
            await ctx.Response.WriteAsync(apiError.ToString()).ConfigureAwait(false);
        }

        private string GetInnermostExceptionMessage(Exception ex)
            => ex.InnerException is not null ?
                        GetInnermostExceptionMessage(ex.InnerException) : ex.Message;
    }
}
