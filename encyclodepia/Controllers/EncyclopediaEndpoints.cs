

using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.OpenApi;
using encyclodepia.Models;
namespace encyclodepia.Controllers;

public static class EncyclopediaEndpoints
{
    public static void MapEncyclopediaEndpoints (this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/Encyclopedia").WithTags(nameof(Encyclopedia));

        group.MapGet("/", () =>
        {
            return new [] { new Encyclopedia() };
        })
        .WithName("GetAllEncyclopedia")
        .WithOpenApi();

        group.MapGet("/{id}", (int id) =>
        {
            return new Encyclopedia { ID = id };
        })
        .WithName("GetEncyclopediaById")
        .WithOpenApi();

        group.MapPut("/{id}", (int id, Encyclopedia input) =>
        {
            return TypedResults.NoContent();
        })
        .WithName("UpdateEncyclopedia")
        .WithOpenApi();

        group.MapPost("/", (Encyclopedia model) =>
        {
            return TypedResults.Created($"/api/Encyclopedia/{model.ID}", model);
        })
        .WithName("CreateEncyclopedia")
        .WithOpenApi();

        group.MapDelete("/{id}", (int id) =>
        {
            return TypedResults.Ok(new Encyclopedia { ID = id });
        })
        .WithName("DeleteEncyclopedia")
        .WithOpenApi();
    }
}
