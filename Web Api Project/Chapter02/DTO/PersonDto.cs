﻿using System.ComponentModel.DataAnnotations;

namespace Chapter02.DTO
{
    public class PersonDto
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public string? Email { get; set; }

        public string? CompleteAddress { get; set; }
    }
}
