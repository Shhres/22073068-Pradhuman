using Microsoft.AspNetCore.Components;
using MauiApp1.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MauiApp1.Components.Pages
{
    public partial class Register : ComponentBase
    {
        private string RegisterUsername = "";
        private string RegisterPassword = "";
        private string ConfirmPassword = "";
        private string RegisterEmail = "";
        private string RegisterFullName = "";
        private string RegisterContactNumber = "";
        private string Message = "";
        private bool IsEmailValid { get; set; } = true;
        private List<User> Users = new();

        private void ValidateEmail(ChangeEventArgs e)
        {
            RegisterEmail = e.Value?.ToString();
            IsEmailValid = System.Text.RegularExpressions.Regex.IsMatch(RegisterEmail ?? string.Empty,
                @"^[^@\s]+@[^@\s]+\.[^@\s]+$");
        }

        protected override void OnInitialized()
        {
            // Load users from UserService when the component is initialized
            Users = UserService.LoadUsers();
        }

        private void HandleRegistration()
        {
            // Validate input fields
            if (string.IsNullOrWhiteSpace(RegisterUsername) || string.IsNullOrWhiteSpace(RegisterPassword) ||
                string.IsNullOrWhiteSpace(RegisterFullName) || string.IsNullOrWhiteSpace(RegisterContactNumber))
            {
                Message = "All fields are required.";
                return;
            }

            if (RegisterPassword != ConfirmPassword)
            {
                Message = "Passwords do not match.";
                return;
            }

            if (Users.Any(u => u.Username == RegisterUsername))
            {
                Message = "Username already exists.";
                return;
            }

            // Create a new user and add them to the list
            var newUser = new User
            {
                Username = RegisterUsername,
                Password = UserService.HashPassword(RegisterPassword),
                Email = RegisterEmail,
                FullName = RegisterFullName,
                ContactNumber = RegisterContactNumber
            };

            Users.Add(newUser);
            UserService.SaveUsers(Users);

            Message = "Registration successful. Redirecting to login...";
            Task.Delay(2000).ContinueWith(_ => NavigationManager.NavigateTo("/"));
        }
    }
}