using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace Fisher.Bookstore.Api.Models
{
    public class ApplicationUser : IdentityUser
    {
        [NotMapped]
        [Required]
        [StringLength(100, MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string Password {get; set;}

    }
}