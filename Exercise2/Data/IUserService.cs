﻿using Exercise1.Models;

namespace Exercise1.Data
{
    public interface IUserService
    {
        User ValidateUser(string userName, string password);
        User RegisterUser(string userName, string city, string role, string password);
    }
}