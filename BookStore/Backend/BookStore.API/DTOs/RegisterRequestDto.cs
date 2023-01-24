﻿using System.ComponentModel.DataAnnotations;

namespace BookStore.API.DTOs
{
    public class RegisterRequestDto
    {

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}