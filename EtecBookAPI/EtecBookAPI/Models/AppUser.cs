using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EtecBookAPI.Models;

    [Table("Users")]
    public class AppUser
{
    [Key]
    public Guid id { get; set; }

    [Required]
    [StringLength(60)]
    public string Name { get; set; }

    [Required]
    [StringLength(20, MinimumLength = 3)]
    public string UserName { get; set; }

    [Required]
    public string Password { get; set; }

    public string Token { get; set; }

    [Required]
    [StringLength(20)]
    public string role { get; set; }

    [Required]
    [StringLength(100)]
    public string Email { get; set; }

    [StringLength(300)]
    public string ProfilePicture { get; set; }
}