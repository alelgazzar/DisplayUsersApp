using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace DisplayUsersApp.Models
{
    public class User
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
       
        public string? Email { get; set; }
    }
}
