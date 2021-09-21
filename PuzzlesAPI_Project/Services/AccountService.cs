using PuzzlesAPI.Models;
using PuzzlesAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace PuzzlesAPI.Services
{
    public interface IAccountService
    {
        public void RegisterUser(RegisterUserDto dto);
    }

    public class AccountService : IAccountService
    {
        private readonly PuzzleDbContext _dbContext;
        private readonly IPasswordHasher<User> _passwordHasher;

        public AccountService(PuzzleDbContext dbContext, IPasswordHasher<User> passwordHasher)
        {
            _dbContext = dbContext;
            _passwordHasher = passwordHasher;
        }
        public void RegisterUser(RegisterUserDto dto)
        {
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

    }
}
