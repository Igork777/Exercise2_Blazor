using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Text.RegularExpressions;
using Exercise1.Models;

namespace Exercise1.Data.Impl
{
   
    public class InMemoryUserService : IUserService
    {
        private string usersFile = "users.json";
        private IList<User> users = new List<User>();

        public InMemoryUserService()
        {
            if (!File.Exists(usersFile))
            {
                WriteTodosToFile(out string productsAsJson);
            }
            else
            {
                ReadUsers();
            }
        }

        private void ReadUsers()
        {
            string content = File.ReadAllText(usersFile);
            users = JsonSerializer.Deserialize<List<User>>(content);
        }

        public IList<User> GetUsers()
        {
            List<User> tmp = new List<User>(users);
            return tmp;
        }
        

        private void WriteTodosToFile(out string productAsJson)
        {
            productAsJson = JsonSerializer.Serialize(users);
            File.WriteAllText(usersFile, productAsJson);
        }

        public User ValidateUser(string userName, string password)
        {
            User first = users.FirstOrDefault(user => user.UserName.Equals(userName));
            if (first == null)
            {
                throw new Exception("User not found");
            }

            if (!first.Password.Equals(password))
            {
                throw new Exception("Incorrect password");
            }

            return first;
        }

        public User RegisterUser(string userName, string city, string role, string password)
        {
            Regex userNameAndCityRegex = new Regex(@"^[a-zA-Z ]+$"),
                roleRegex = new Regex(@"^[BOSS]|[MANAGER]|[EMPLOYEE]$", RegexOptions.IgnoreCase),
                passwordRegex = new Regex(@"^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{8,}$");

            if (!userNameAndCityRegex.IsMatch(userName))
            {
                throw new Exception("Username should contain only latin letters or spaces. Registration failed");
            }

            if (!userNameAndCityRegex.IsMatch(city))
            {
                throw new Exception("City should contain only latin letters or spaces. Registration failed");
            }

            if (!roleRegex.IsMatch(role))
            {
                throw new Exception("Role can be either boss, manager or employee. Registration failed");
            }

            if (!passwordRegex.IsMatch(password))
            {
               throw new Exception("The password must be at least 8 characters, at least one letter, one number and one special character. Registration failed");
            }
            
            User user = new User{UserName = userName, City = city, Password = password, Role = role};
            if (users == null)
            {
                users = new List<User>();
                user.UserId = 0;
            }
            else if(users.FirstOrDefault(x => x.UserName.Equals(user.UserName)) != null)
            {
                throw new Exception("User " + user.UserName + " already exists");
            }
            else
            {
                user.UserId = users.Count;
            }
            users.Add(user);
           WriteTodosToFile(out string productsAsJson);
            return user;
        }
    }
}