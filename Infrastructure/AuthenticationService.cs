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
        var bytes=Encoding.UTF8.GetBytes(Password);
        var sha_bytes=SHA256.HashData(bytes);
        string PasswordHash=Encoding.UTF8.GetString(sha_bytes);

        var result=await _context.Users
        .FirstOrDefaultAsync(u=>
        u.UserName==Username && 
        u.PasswordHash==PasswordHash);

        if (result == null)
        {
            return false;
        }
        else
        {
            return true;
        }
    }
}