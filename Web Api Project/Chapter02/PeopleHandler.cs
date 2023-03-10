﻿using Microsoft.VisualBasic;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using MiniValidation;

namespace Chapter02
{
    public class PeopleHandler : IEndpointRouteHandler
    {
        public void MapEndpoints(IEndpointRouteBuilder app)
        {
            app.MapGet("/api/people", GetList).ExcludeFromDescription();

            app.MapGet("/api/people/{id:guid}", Get)
                .Produces<PeopleService>().WithTags("People API").WithName("Get people by GUID");

            app.MapPost("/api/people", Insert)
                .ProducesValidationProblem();
            //app.MapPut("/api/people/{id:guid}", Update);
            //app.MapDelete("/api/people/{id:guid}", Delete);
        }

        private static IResult? GetList()
        {
            return Results.Ok(null);
        }


        private static IResult Get(IConfiguration configuration, Guid id)
        {
            var s = configuration.GetValue<string>("MyCustoms:Section1");
            return Results.Ok(new PeopleService());

        }

        private static IResult Insert(Person person, IWeatherService people)
        {
            var isValid = MiniValidator.TryValidate(person, out var errors);

            if (!isValid)
            {
                Results.ValidationProblem(errors); 
            }
            return Results.NoContent();
        }
        private static IResult Update(Guid id, Person person, PeopleService people)
        { return Results.Ok(); }
        private static IResult Delete(Guid id) { return Results.Ok(); }
    }

    internal class Person
    {

        [Required]
        [MaxLength(30)]
        public string? FirstName { get; set; }

        [Required]
        [MaxLength(30)]
        public string? LastName { get; set; }

        [EmailAddress]
        [StringLength(100, MinimumLength = 6)]
        public string? Email { get; set; }
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