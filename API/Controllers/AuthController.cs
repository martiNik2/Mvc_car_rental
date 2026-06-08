using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;
using Core;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;
    private readonly IUserRepository _userRepository;

    public AuthController(IAuthService authService, IUserRepository userRepository)
    {
        _authService=authService;
        _userRepository=userRepository;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginRequest loginRequest)
    {
        bool result= await _authService.AuthUserAsync(loginRequest.Username,loginRequest.Password);
        if (result)
        {
            return Ok();
        }
        else
        {
            return Unauthorized();
        }
    }
    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterRequest registerRequest)
    {
        var passwordhash=_authService.GetPasswordHash(registerRequest.Password);
        var user = new User{
            UserName=registerRequest.Username,
            PasswordHash=passwordhash,
            LicenceNumber=registerRequest.LicenceNumber,
            SSN=registerRequest.SSN
        };

        var result=await _userRepository.AddUserAsync(user);


        if (result == true)
        {
            return Ok("success");
        }
        else
        {
            return BadRequest();
        }
    }
}