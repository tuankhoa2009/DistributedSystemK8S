using AuthorizationApi.Abstractions;
using Carter;
using MediatR;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace AuthorizationApi.APIs.Identity
{
    public class TokenApi : ApiEndpoint, ICarterModule
    {
        private const string BaseUrl = "/api/v{version:apiVersion}/token";

        public void AddRoutes(IEndpointRouteBuilder app)
        {
            var group1 = app.NewVersionedApi("Token")
          .MapGroup(BaseUrl).HasApiVersion(1).RequireAuthorization();

            group1.MapPost("refresh", RefreshV1);
            group1.MapPost("revoke", RevokeV1);
        }
        public static async Task<IResult> RefreshV1(ISender sender, HttpContext httpContext, [FromBody] DistributedSystem.Contract.Services.V1.Identity.Query.Token token)
        {
            var AccessToken = await httpContext.GetTokenAsync("access_token");
            var result = await sender.Send(new DistributedSystem.Contract.Services.V1.Identity.Query.Token(AccessToken, token.RefreshToken));

            if (result.IsFailure)
                return HandlerFailure(result);

            return Results.Ok(result);
        }

        public static async Task<IResult> RevokeV1(ISender sender, HttpContext httpContext)
        {
            var AccessToken = await httpContext.GetTokenAsync("access_token");

            var result = await sender.Send(new DistributedSystem.Contract.Services.V1.Identity.Command.Revoke(AccessToken));

            return Results.Ok(result);
        }
    }
}
