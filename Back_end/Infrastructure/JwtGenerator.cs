using System;
using System.Security.Claims;
using System.Text;
using Core;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;

namespace Infrastructure;

public static class JwtGenerator
{
    private static string? Key=Environment.GetEnvironmentVariable("JWT_KEY");

    public static string GenerateToken(User user)
    {
        if (Key == null)
        {
            return "";
        }

        var bytes_key=Encoding.UTF8.GetBytes(Key);
        var security_key=new SymmetricSecurityKey(bytes_key);
        var credentials=new SigningCredentials(security_key,SecurityAlgorithms.HmacSha256);

        var claims=new Dictionary<string, object>
        {
            {JwtRegisteredClaimNames.NameId,user.Id.ToString()},
            {JwtRegisteredClaimNames.Name,user.UserName}  
        };

        var tokenDescriptor=new SecurityTokenDescriptor
        {
            Issuer="banana",
            Audience="apple",
            Claims=claims,
            Expires=DateTime.UtcNow.AddMinutes(1),
            SigningCredentials=credentials
        };
        var jsonHandler=new JsonWebTokenHandler();
        return jsonHandler.CreateToken(tokenDescriptor);
    }
}