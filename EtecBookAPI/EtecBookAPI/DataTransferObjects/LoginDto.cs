using System.ComponentModel.DataAnnotations;

namespace EtecBookAPI.DataTransferObjects;

public class LoginDto
{
    [Required(ErrorMessage = "Informe o Email ou o Nome de Usúario")]
    [StringLength(100, ErrorMessage = "O Email ou o Nome de possuir no Máximo 100 caracteres")]
    public string Email { get; set; }

    [DataType(DataType.Password)]
    [Required(ErrorMessage = "Informe o Email ou o Nome de Usúario")]
    [StringLength(20, ErrorMessage = "O Email ou o Nome de possuir no Máximo 100 caracteres")]
    public string Password { get; set; }
}