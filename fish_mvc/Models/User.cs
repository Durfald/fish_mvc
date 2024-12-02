using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.PortableExecutable;

namespace fish_mvc.Models;

/*[Table("user")]*/
public class User
{
    [Key]
    [Column("id")]
    public Guid Id { get; set; }

    [Column("username", TypeName = "NVARCHAR(16)")]
    [MaxLength(16, ErrorMessage = "Role can be only 16 symbols long")]
    [MinLength(3, ErrorMessage = "Password should be at least 3 symbols long")]
    [DisplayName("Логин")]
    public string Username { get; set; } = string.Empty;

    [Column("password", TypeName = "NVARCHAR(16)")]
    [MaxLength(16, ErrorMessage = "Role can be only 16 symbols long")]
    [MinLength(3, ErrorMessage = "Password should be at least 3 symbols long")]
    [DisplayName("Пароль")]
    public string Password { get; set; } = string.Empty;

    [Column("role", TypeName = "NVARCHAR(5)")]
    [MaxLength(5, ErrorMessage = "Role can be only 5 symbols long")]
    [MinLength(5, ErrorMessage = "Role slould be at least 5 symbols long")]
    [DisplayName("Роль")]
    public string Role { get; set; } = string.Empty;
}