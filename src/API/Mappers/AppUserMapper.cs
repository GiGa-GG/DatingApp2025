using API.DTOs;
using API.Entities;
using API.Interfaces;

namespace API.Mappers;

public static class AppUserMapper
{
    public static UserResponse ToDto(this AppUser appUser, ITokenService tokenService)
    {
        var token = tokenService.CreateToken(appUser);
        return new UserResponse
        {
            Id = appUser.Id,
            DisplayName = appUser.DisplayName,
            Email = appUser.Email,
            ImageUrl = appUser.ImageUrl,
            Token = token
        };
    }

}