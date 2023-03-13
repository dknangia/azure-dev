using Chapter02.Models;
using Microsoft.EntityFrameworkCore;

namespace Chapter02.Routes
{
    public class IceCreamHandler : IEndpointRouteHandler
    {
        public void MapEndpoints(IEndpointRouteBuilder app)
        {
            app.MapGet("/icecream", GetIceCreams);
            app.MapPost("/icecream", PostIceCream);
        }

        private static async Task<IResult> PostIceCream(IceCreamDb db, IceCream iceCream)
        {
            await db.IceCreams.AddAsync(iceCream);
            await db.SaveChangesAsync();
            return Results.Created($"/icecream/{iceCream.Id}", iceCream);

        }

        private static async Task<IResult> GetIceCreams(IceCreamDb db, IceCream iceCream)
        {
            if (iceCream.Id == -1) return Results.NotFound();
            var results = await db.IceCreams.FindAsync(iceCream.Id);
            if (results == null) Results.NotFound();
            return Results.Ok(results);

        }
    }


}
