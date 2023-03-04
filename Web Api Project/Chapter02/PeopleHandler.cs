using Microsoft.VisualBasic;
using System.Collections.Generic;

namespace Chapter02
{
    public class PeopleHandler : IEndpointRouteHandler
    {
        public void MapEndpoints(IEndpointRouteBuilder app)
        {
            //app.MapGet("/api/people", GetList);
            app.MapGet("/api/people/{id:guid}", Get)
                .Produces<PeopleService>().WithTags("People API").WithName("Get people by GUID");
            //app.MapPost("/api/people", Insert);
            //app.MapPut("/api/people/{id:guid}", Update);
            //app.MapDelete("/api/people/{id:guid}", Delete);
        }

        private static IResult? GetList()
        {
            return Results.Ok(null);
        }


        private static IResult Get(Guid id)
        {

            return Results.Ok(new PeopleService());

        }

        private static IResult Insert(Person person, PeopleService people)
        { return Results.Ok(); }
        private static IResult Update(Guid id, Person person, PeopleService people)
        { return Results.Ok(); }
        private static IResult Delete(Guid id) { return Results.Ok(); }
    }

    internal class Person
    {
        //todo : need to implement Try parse or BindAsync to extract the values
    }

    public class PeopleService
    {
        public string Id { get; set; }
    }

    public interface IEndpointRouteHandler
    {
        public void MapEndpoints(IEndpointRouteBuilder app);
    }
}
