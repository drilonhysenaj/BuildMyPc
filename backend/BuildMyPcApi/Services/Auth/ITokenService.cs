using BuildMyPcApi.Models.Entities;

namespace BuildMyPcApi.Services.Auth;

public interface ITokenService
{
    (string Token, DateTime ExpiresAt) CreateToken(User user);
}