﻿using Microsoft.VisualBasic;
using System.Collections.Generic;
using AutoMapper;
using Chapter02.DTO;
using Microsoft.AspNetCore.Mvc;
using MiniValidation;
using Chapter02.Models;

namespace Chapter02
{
    public class PeopleHandler : IEndpointRouteHandler
    {
        public void MapEndpoints(IEndpointRouteBuilder app)
        {
            app.MapGet("/api/people", GetList).ExcludeFromDescription();

            app.MapGet("/api/people/{id:guid}", Get)
                .Produces(StatusCodes.Status200OK, typeof(PersonDto)).WithTags("Person DTO API").WithName("Get people by GUID");

            app.MapPost("/api/people", Insert)
                .ProducesValidationProblem();
            //app.MapPut("/api/people/{id:guid}", Update);
            //app.MapDelete("/api/people/{id:guid}", Delete);
        }

        private static IResult? GetList()
        {
            return Results.Ok(null);
        }


        private static IResult Get(IConfiguration configuration, IMapper mapper, Guid id)
        {
            var p = PersonData.GetData();
            var result = mapper.Map<PersonDto>(p);
            return Results.Ok(result);

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

    public class PeopleService
    {
        public string Id { get; set; }
    }

    public interface IEndpointRouteHandler
    {
        public void MapEndpoints(IEndpointRouteBuilder app);
    }
}
