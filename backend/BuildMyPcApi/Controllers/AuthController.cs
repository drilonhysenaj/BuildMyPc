using BuildMyPcApi.Models.Dtos.Auth;
using BuildMyPcApi.Services.Auth;
using Microsoft.AspNetCore.Mvc;

namespace BuildMyPcApi.Controllers;

[ApiController]
[Route("api/auth")]
public class AuthController(IAuthService authService) : ControllerBase
{
    /// <summary>
    /// Regjistron një përdorues të ri dhe kthen token-in JWT.
    /// </summary>
    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterRequestDto dto)
    {
        try
        {
            var result = await authService.RegisterAsync(dto);
            return StatusCode(StatusCodes.Status201Created, result);
        }
        catch (InvalidOperationException ex)
        {
            return Conflict(new { message = ex.Message });
        }
    }

    /// <summary>
    /// Kyç përdoruesin me email dhe fjalëkalim, dhe kthen token-in JWT.
    /// </summary>
    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginRequestDto dto)
    {
        var result = await authService.LoginAsync(dto);

        if (result == null)
            return Unauthorized(new { message = "Email ose fjalëkalim i gabuar." });

        return Ok(result);
    }
}