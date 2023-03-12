using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.DataProtection;

namespace Chapter02.Models;

public class Person
{

    public int Id { get; set; }
    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? Email { get; set; }

    public string? City { get; set; }
    public string? Address1 { get; set; }
    public string? Address2 { get; set; }
    public string? ZipCode { get; set; }
}


public static class PersonData
{
    public static Person GetData()
    {
        var dataList = new List<Person>
        {
            new Person()
            {
                Email = "John@gmail.com",
                Address1 = "West Street1",
                Address2 = "Apt 102",
                City = "Toronto",
                FirstName = "John",
                Id = 101,
                LastName = "Smith",
                ZipCode = "N2L415"


            },
            new Person()
            {
                Email = "nathe@gmail.com",
                Address1 = "East Street1",
                Address2 = "Apt 505",
                City = "Toronto",
                FirstName = "Naathe",
                Id = 102,
                LastName = "White",
                ZipCode = "N2L415"


            }
        };

        return dataList[0];

    }
}