using System.ComponentModel.DataAnnotations;

namespace BlazorServerApp.Model
{
    public class Roles
    {
        public int Id { get; set; }

        [Required]
        public string RoleName { get; set; }

        public bool IsChecked { get; set; }
    }
}
