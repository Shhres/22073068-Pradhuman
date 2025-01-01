using Microsoft.AspNetCore.Components;
using MauiApp1.Models;
using System.Collections.Generic;
using System.Linq;

namespace MauiApp1.Components.Pages
{
    public partial class Login : ComponentBase
    {
        private string LoginUsername = "";
        private string LoginPassword = "";
        private string Message = "";
        private string SelectedCurrency = "NPR"; // Default currency

        private List<User> Users = new();

        protected override void OnInitialized()
        {
            // Load users from UserService when the component is initialized
            Users = UserService.LoadUsers();
        }

        private void LoginPage()
        {
            // Try to find a user by username
            var user = Users.FirstOrDefault(u => u.Username == LoginUsername);

            if (user != null && UserService.ValidatePassword(LoginPassword, user.Password))
            {
                // Redirect to dashboard if login is successful
                NavigationManager.NavigateTo("/dashboard");
            }
            else
            {
                // Show an error message if login fails
                Message = "Invalid username or password.";
            }
        }
    }
}