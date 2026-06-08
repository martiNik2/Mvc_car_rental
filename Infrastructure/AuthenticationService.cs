using Core;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;

namespace Infrastructure;

public class AuthenticationService : IAuthService
{
    private readonly AppDbContext _context;

    public AuthenticationService(AppDbContext context)
    {
        _context=context;
    }
    public async Task<bool> AuthUserAsync(string Username,string Password)
    {
        var passwordHash=GetPasswordHash(Password);

        var result=await _context.Users
        .FirstOrDefaultAsync(u=>
        u.UserName==Username && 
        u.PasswordHash==passwordHash);

        if (result == null)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    public string GetPasswordHash(string password)
    {
        var bytes=Encoding.UTF8.GetBytes(password);
        var sha_bytes=SHA256.HashData(bytes);
        return Convert.ToBase64String(sha_bytes);
    }
}