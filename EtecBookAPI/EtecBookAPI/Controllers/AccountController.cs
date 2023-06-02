using System.Net.Mail;
using System.Text.RegularExpressions;
using EtecBookAPI.Data;
using EtecBookAPI.DataTransferObjects;
using EtecBookAPI.Helpers;
using EtecBookAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EtecBookAPI.Controllers;

    [ApiController]
    [Route("api/[controller]")]
public class AccountController : ControllerBase
{
    private readonly AppDbContext _context;

    public AccountController(AppDbContext context)
    {
        _context = context;
    }

    [HttpPost("authenticate")]
    public async Task<IActionResult> Authenticate([FromBody] LoginDto login) 
    {
        if (login == null)
            return BadRequest();

        if (!ModelState.IsValid)
            return BadRequest();

        AppUser user = new();
        if (IsEmail(login.Email))
        {
            user = await _context.Users.FirstOrDefaultAsync(
                u => u.Email.Equals(login.Email)
            );
        }
        else
        {
            user = await _context.Users.FirstOrDefaultAsync(
                u => u.UserName.Equals(login.Email)
            );
        }

        if (user == null)
            return NotFound(new { Message = "Usuário e/ou Senha Inválidos"});
        if (!PasswordHasher.VerifyPassword(login.Password, user.Password))
            return NotFound(new { Message = "Usuário e/ou Senha Inválidos"});
        
        return Ok(new { Message = "Usuário autenticado" });
    }

    [HttpPost("resgister")]
    public async Task<IActionResult> Register([FromBody] RegisterDto register)
    {
        if (register == null)
            return BadRequest();

        if (!ModelState.IsValid)
            return BadRequest();

        // Chegar se o email já existe
        if ( await _context.Users.AnyAsync(u => u.Email.Equals(register.Email)) )
            return BadRequest(new { message = "Email já cadastrado tente recuperar sua senha ou entre em contato com o administrador!"});
        
        // Chegar a força da senha
    }

    // private string CheckPasswordStrength(string password)
    // {
    //     StringBuilder sb = new();
    //     if (password.Length < 6)
    //         sb.append("A Senha deve possuir no minimo 6 caracteres " + Environment.NewLine);
    //     if (!(Regex.IsMatch(password, "[a-z]" && (Regex.IsMatch(password, "[A-Z]")))
    //         && (Regex.IsMatch(password, ""))))
    //     {
            
    //     }
    // }

    private bool IsEmail(string email)
    {
        try
        {
            MailAddress mail = new(email);
            return true;
        }
        catch
        {
            return false;
        }
    }
}