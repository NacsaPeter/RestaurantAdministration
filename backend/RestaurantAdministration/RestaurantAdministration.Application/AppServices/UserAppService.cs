using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using RestaurantAdministration.Application.Dtos;
using RestaurantAdministration.Application.Interfaces;
using RestaurantAdministration.Domain.Models;
using RestaurantAdministration.EF.Interfaces;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantAdministration.Application.AppServices
{
    public class UserAppService : IUserAppService
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _loginManager;

        public UserAppService(
            UserManager<User> userManager,
            SignInManager<User> loginManager)
        {
            this._userManager = userManager;
            this._loginManager = loginManager;
        }

        public async Task<IEnumerable<UserDto>> GetUsersAsync()
        {
            var users = await _userManager.Users.ToListAsync();
            var usersDto = new List<UserDto>();
            foreach (var user in users)
            {
                usersDto.Add(new UserDto
                {
                    Id = user.Id,
                    Email = user.Email,
                    UserName = user.UserName,
                    Role = (await _userManager.GetRolesAsync(user))[0]
                });
            }
            return usersDto;
        }

        public async Task<JwtSecurityToken> Login(LoginUserDto dto)
        {
            var login = await _loginManager.PasswordSignInAsync(dto.UserName, dto.Password, false, false);
            if (login.Succeeded)
            {
                var user = await _userManager.FindByNameAsync(dto.UserName);
                var role = (await _userManager.GetRolesAsync(user))[0];

                return CreateToken(user, role);
            }
            else
            {
                return null;
            }
        }

        private JwtSecurityToken CreateToken(User user, string role)
        {
            var claims = new[]
                {
                    new Claim("userName", user.UserName),
                    new Claim(ClaimTypes.Email, user.Email),
                    new Claim("userId", user.Id.ToString()),
                    new Claim(ClaimTypes.Role, role)
                };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("kYp3s6v9y$B?E(H+MbQeThWmZq4t7w!z%C*F)J@NcRfUjXn2r5u8x/A?D(G+KaPd"));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                "https://localhost:44319",
                "https://localhost:44319",
                claims,
                expires: DateTime.Now.AddMonths(6),
                signingCredentials: creds
            );

            return token;
        }


        public async Task<IdentityResult> Register(RegisterUserDto dto)
        {
            var createdUser = await _userManager.CreateAsync(new User
            {
                Email = dto.Email,
                UserName = dto.UserName
            }, dto.Password);

            if (createdUser.Succeeded)
            {
                var user = await _userManager.FindByNameAsync(dto.UserName);
                await _userManager.AddToRoleAsync(user, dto.Role);
            }

            return createdUser;
        }

        public async Task RemoveUserAsync(int userId)
        {
            var user = await _userManager.FindByIdAsync(userId.ToString());
            await _userManager.DeleteAsync(user);
        }
    }
}
