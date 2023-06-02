using System.ComponentModel.DataAnnotations;

namespace EtecBookAPI.DataTransferObjects;

public class RegisterDto
{
    [Required(ErrorMessage = "Informe o Nome")]
    [StringLength(60, ErrorMessage = "O Nome deve possuir no máximo 60 caractéres")]
    public string Name { get; set; }

    [Required(ErrorMessage = "Informe o Email")]
    [EmailAddress(ErrorMessage = "Informe um Email Válido!")]
    [StringLength(100, ErrorMessage = "O Nome deve possuir no máximo 100 caractéres")]
    public string Email { get; set; }

    [DataType(DataType.Password)]
    [Required(ErrorMessage = "Informe sua Senha")]
    [StringLength(20, MinimumLength = 6, ErrorMessage = "O Nome deve possuir no máximo 20 caractéres")]
    public string Password { get; set; }
}