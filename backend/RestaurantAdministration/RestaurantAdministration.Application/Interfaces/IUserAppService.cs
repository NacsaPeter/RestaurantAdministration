using Microsoft.AspNetCore.Identity;
using RestaurantAdministration.Application.Dtos;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantAdministration.Application.Interfaces
{
    public interface IUserAppService
    {
        Task<IdentityResult> Register(RegisterUserDto dto);
        Task<JwtSecurityToken> Login(LoginUserDto dto);
        Task<IEnumerable<UserDto>> GetUsersAsync();
        Task RemoveUserAsync(int userId);
    }
}
