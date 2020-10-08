using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text.Json;
using System.Threading.Tasks;
using Exercise1.Models;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.JSInterop;

namespace Exercise1.Data.Impl
{
    public class CustomAuthenticationStateProvider : AuthenticationStateProvider
    {
        private readonly IJSRuntime _jsRuntime;
        private readonly IUserService _userService;

        private User _cachedUser;

        public CustomAuthenticationStateProvider(IJSRuntime jsRuntime, IUserService userService)
        {
            this._jsRuntime = jsRuntime;
            this._userService = userService;
        }
        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var identity = new ClaimsIdentity();
            if (_cachedUser == null)
            {
                string userAsJson = await _jsRuntime.InvokeAsync<string>("sessionStorage.getItem", "currentUser");
                if (!string.IsNullOrEmpty(userAsJson))
                {
                    _cachedUser = JsonSerializer.Deserialize<User>(userAsJson);
                    identity = SetupClaimsForUser(_cachedUser);
                }
            }
            else
            {
                identity = SetupClaimsForUser(_cachedUser);
            }
            ClaimsPrincipal cachedClaimsPrincipal = new ClaimsPrincipal(identity);
            return await Task.FromResult(new AuthenticationState(cachedClaimsPrincipal));
        }
        public void ValidateRegistration(string username, string city, string role, string password)
        {
            Console.WriteLine("Validating registration");
            if(string.IsNullOrEmpty(username)) throw new Exception("Enter username");
            if(string.IsNullOrEmpty(password)) throw new Exception("Enter password");
            if(string.IsNullOrEmpty(city)) throw new Exception("Enter city");
            if(string.IsNullOrEmpty(role)) throw new Exception("Enter role");
            
            try
            {
                User user = _userService.RegisterUser(username, city,role,password);
                NotifyAboutChange(user);
            }
            catch (Exception e)
            {
                throw;
            }
        }
        public void ValidateLogin(string username, string password)
        {
            Console.WriteLine("Validating log in");
            if(string.IsNullOrEmpty(username)) throw new Exception("Enter username");
            if(string.IsNullOrEmpty(password)) throw new Exception("Enter password");
            
            try
            {
                User user = _userService.ValidateUser(username, password);
               NotifyAboutChange(user);
            }
            catch (Exception e)
            {
                throw;
            }
        }

        private void NotifyAboutChange(User user)
        {
            ClaimsIdentity identity = new ClaimsIdentity();
            identity = SetupClaimsForUser(user);
            string serialisedData = JsonSerializer.Serialize(user);
            _jsRuntime.InvokeVoidAsync("sessionStorage.setItem", "currentUser", serialisedData);
            _cachedUser = user;
            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(new ClaimsPrincipal(identity))));
        }

        public void Logout()
        {
            _cachedUser = null;
            var user = new ClaimsPrincipal(new ClaimsIdentity());
            _jsRuntime.InvokeVoidAsync("sessionStorage.setItem", "currentUser", "");
            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(user)));
        }

       

        private ClaimsIdentity SetupClaimsForUser(User user)
        {
            List<Claim> claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.Name, user.UserName));
            claims.Add(new Claim("Role", user.Role));
            claims.Add(new Claim("City", user.City));
            
            ClaimsIdentity identity = new ClaimsIdentity(claims, "apiauth_type");
            return identity;
        }
    }
}