using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.OpenApi;
using Microsoft.EntityFrameworkCore;
using encyclodepia.Data;
using encyclodepia.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace encyclodepia.Controllers
{

public static class ItemEndpoints
{
	public static void MapItemEndpoints (this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/Item").WithTags(nameof(Item));

        group.MapGet("/", async (encyclodepiaContext db) =>
        {
            return await db.Item.ToListAsync();
        })
        .WithName("GetAllItems")
        .WithOpenApi();

        group.MapGet("/{id}", async Task<Results<Ok<Item>, NotFound>> (int id, encyclodepiaContext db) =>
        {
            return await db.Item.AsNoTracking()
                .FirstOrDefaultAsync(model => model.Id == id)
                is Item model
                    ? TypedResults.Ok(model)
                    : TypedResults.NotFound();
        })
        .WithName("GetItemById")
        .WithOpenApi();

        group.MapPut("/{id}", async Task<Results<Ok, NotFound>> (int id, Item item, encyclodepiaContext db) =>
        {
            var affected = await db.Item
                .Where(model => model.Id == id)
                .ExecuteUpdateAsync(setters => setters
                  .SetProperty(m => m.Id, item.Id)
                  );
            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithName("UpdateItem")
        .WithOpenApi();

        group.MapPost("/", async (Item item, encyclodepiaContext db) =>
        {
            db.Item.Add(item);
            await db.SaveChangesAsync();
            return TypedResults.Created($"/api/Item/{item.Id}",item);
        })
        .WithName("CreateItem")
        .WithOpenApi();

        group.MapDelete("/{id}", async Task<Results<Ok, NotFound>> (int id, encyclodepiaContext db) =>
        {
            var affected = await db.Item
                .Where(model => model.Id == id)
                .ExecuteDeleteAsync();
            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithName("DeleteItem")
        .WithOpenApi();
    }
}}
