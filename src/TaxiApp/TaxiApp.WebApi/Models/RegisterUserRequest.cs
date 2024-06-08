﻿using TaxiApp.Application.Users.Commands.Register;

namespace TaxiApp.WebApi.Models
{
    public sealed class RegisterUserRequest 
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string RepeatPassword { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }                
        public string Address { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string RoleName { get; set; } 


        public RegisterUserCommand MapToRegisterUserCommand()
            => new RegisterUserCommand(Username, Email, Password, Name, Surname, Address, DateOfBirth, RoleName);
    }
}
