// See https://aka.ms/new-console-template for more information

using EFTesting.Models;
using Microsoft.EntityFrameworkCore;

Console.WriteLine("Hello, World!");

var db = new PreqDbContext();
var result = db.PreQuals.ToList();
foreach (var preQual in result)
{
    Console.WriteLine(preQual.CatId);
}