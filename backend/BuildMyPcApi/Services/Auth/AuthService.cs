using BuildMyPcApi.Database;
using BuildMyPcApi.Models.Dtos.Auth;
using BuildMyPcApi.Models.Entities;
using BuildMyPcApi.Models.Enums;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace BuildMyPcApi.Services.Auth;

public class AuthService : IAuthService
{
    private readonly BuildMyPcDbContext _db;
    private readonly IPasswordHasher<User> _passwordHasher;
    private readonly ITokenService _tokenService;

    public AuthService(
        BuildMyPcDbContext db,
        IPasswordHasher<User> passwordHasher,
        ITokenService tokenService)
    {
        _db = db;
        _passwordHasher = passwordHasher;
        _tokenService = tokenService;
    }

    public async Task<AuthResponseDto> RegisterAsync(RegisterRequestDto dto)
    {
        var email = dto.Email.Trim().ToLowerInvariant();

        var exists = await _db.Users.AnyAsync(u => u.Email == email);
        if (exists)
            throw new InvalidOperationException("Ky email është i regjistruar tashmë.");

        var user = new User
        {
            FullName = dto.FullName.Trim(),
            Email = email,
            Role = UserRole.User
        };

        user.PasswordHash = _passwordHasher.HashPassword(user, dto.Password);

        _db.Users.Add(user);
        await _db.SaveChangesAsync();

        return CreateAuthResponse(user);
    }

    public async Task<AuthResponseDto?> LoginAsync(LoginRequestDto dto)
    {
        var email = dto.Email.Trim().ToLowerInvariant();

        var user = await _db.Users.FirstOrDefaultAsync(u => u.Email == email);
        if (user == null) return null;

        var result = _passwordHasher.VerifyHashedPassword(user, user.PasswordHash, dto.Password);
        if (result == PasswordVerificationResult.Failed) return null;

        if (result == PasswordVerificationResult.SuccessRehashNeeded)
        {
            user.PasswordHash = _passwordHasher.HashPassword(user, dto.Password);
            await _db.SaveChangesAsync();
        }

        return CreateAuthResponse(user);
    }

    private AuthResponseDto CreateAuthResponse(User user)
    {
        var (token, expiresAt) = _tokenService.CreateToken(user);

        return new AuthResponseDto
        {
            Token = token,
            ExpiresAt = expiresAt,
            UserId = user.Id,
            FullName = user.FullName,
            Email = user.Email,
            Role = user.Role.ToString()
        };
    }
}