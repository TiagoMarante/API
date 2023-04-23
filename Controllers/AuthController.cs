using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using Catalog.Controllers.Test;

namespace Catalog.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IConfiguration _configuration;

    public AuthController(IConfiguration configuration)
    {
        this._configuration = configuration;
    }

    public static User _user = new User();

    [HttpPost("Register")]
    public async Task<ActionResult<User>> Register(UserDTO request)
    {
        CreatePasswordHash(request.Password, out var passwordHash, out var passwordSalt);
        _user.Username = request.Username;
        _user.PasswordHash = passwordHash;
        _user.PasswordSalt = passwordSalt;
        return Ok(_user);
    }


    private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
    {
        using (var hmac = new HMACSHA512())
        {
            passwordSalt = hmac.Key;
            passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
        }
    }


    [HttpPost("Login")]
    public async Task<ActionResult<string>> Login(UserDTO request)
    {
        if (_user.Username != request.Username)
        {
            return BadRequest("User not found");
        }

        if (!VerifyPasswordHash(request.Password, _user.PasswordHash, _user.PasswordSalt))
        {
            return BadRequest("Wrong Password");
        }

        string token = CreateToken(_user);
        return Ok(token);
    }


    private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
    {
        using (var hmac = new HMACSHA512(passwordSalt))
        {
            var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            return computedHash.SequenceEqual(passwordHash);
        }
    }


    private string CreateToken(User user)
    {
        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, user.Username),
            new Claim(ClaimTypes.Role, "Admin")
        };

        var key = new SymmetricSecurityKey(
            System.Text.Encoding.UTF8.GetBytes(_configuration.GetSection("AppSettings:Token").Value ?? throw new
                InvalidOperationException()));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

        var token = new JwtSecurityToken
        (
            claims: claims,
            expires: DateTime.Now.AddDays(1),
            signingCredentials: creds
        );

        var jwt = new JwtSecurityTokenHandler().WriteToken(token);
        return jwt;
    }
}