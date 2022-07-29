using aspnetcorewebapiminimalapi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace aspnetcorewebapiminimalapi.Endpoints
{
    public static class ItemEndpoint
    {
        public static void ItemEndpoints(this WebApplication app)
        {
            //app.MapGet("/products/{id}", (int id) => { return Results.Ok(); });
            app.MapGet("/items", async ([FromServices] accounting_systemContext db) => await db.Items.ToListAsync()).RequireCors("_myAllowSpecificOrigins");

            app.MapPost("/items", async([FromBody] Item item, [FromServices] accounting_systemContext db, HttpResponse response) =>
            {
                db.Items.Add(item);
                await db.SaveChangesAsync();
                response.StatusCode = 201;
            });
        }
    }
}
