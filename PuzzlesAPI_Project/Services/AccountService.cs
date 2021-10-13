using PuzzlesAPI.Models;
using PuzzlesAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using PuzzlesAPI_Project;
using System.IdentityModel.Tokens.Jwt;
using PuzzlesAPI.Exceptions;

namespace PuzzlesAPI.Services
{
    public interface IAccountService
    {
        public void RegisterUser(RegisterUserDto dto);
        public string CenerateJwt(LoginUserDto dto);
        public IEnumerable<User> GetAllUsers();

    }

    public class AccountService : IAccountService
    {
        private readonly PuzzleDbContext _dbContext;
        private readonly IPasswordHasher<User> _passwordHasher;
        private readonly AuthenticationSettings _authenticationSettings;

        public AccountService(PuzzleDbContext dbContext, IPasswordHasher<User> passwordHasher, AuthenticationSettings authenticationSettings)
        {
            _dbContext = dbContext;
            _passwordHasher = passwordHasher;
            _authenticationSettings = authenticationSettings;
        }
        public void RegisterUser(RegisterUserDto dto)
        {

            if (dto.RoleId == 0)
            {
                throw new NotFoundException("Role not found");
            }

            var newUser = new User()
            {
                Email = dto.Email,
                RoleId = dto.RoleId,
                FirstName = dto.FirstName,
                LastName = dto.LastName,
            };

            var hashedPass = _passwordHasher.HashPassword(newUser, dto.Password);
            newUser.PasswordHash = hashedPass;

            _dbContext.PuzzleUsers.Add(newUser);
            _dbContext.SaveChanges();
        }



        public IEnumerable<User> GetAllUsers()
        {
            return _dbContext.PuzzleUsers;
        }

        public string CenerateJwt(LoginUserDto dto)
        {
            var user = _dbContext.PuzzleUsers
                .Include(u => u.Role)
                .FirstOrDefault(u => u.Email == dto.Email);

            if(user is null)
            {
                return "user null";
            }

            var result = _passwordHasher.VerifyHashedPassword(user, user.PasswordHash, dto.Password);

            if (result == PasswordVerificationResult.Failed)
            {
                return "pass fail";
            }


            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, $"{user.FirstName} {user.LastName}"),
                new Claim(ClaimTypes.Role, user.Role.Name)
            };


            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_authenticationSettings.JwtKey));
            var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expires = DateTime.Now.AddDays(_authenticationSettings.JwtExpireDays);

            var token = new JwtSecurityToken(_authenticationSettings.JwtIssuer,
                _authenticationSettings.JwtIssuer,
                claims,
                expires: expires,
                signingCredentials: cred);

            var tokenHendler = new JwtSecurityTokenHandler();

            return tokenHendler.WriteToken(token);

        }
    }
} 
