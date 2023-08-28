using System.ComponentModel.DataAnnotations;

namespace BlazorServerApp.Models
{
    public class Employee
    {
        public int Id { get; set; }

        [Required]
        public string? Name { get; set; }

        [Required]
        public string? City { get; set;}

        [Required, EmailAddress]
        public string? Email { get; set; }

        [Required]
        public string? Phone { get; set;}
    }
}