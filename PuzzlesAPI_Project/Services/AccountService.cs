using PuzzlesAPI.Models;
using PuzzlesAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PuzzlesAPI.Services
{
    public interface IAccountService
    {
        public void RegisterUser(RegisterUserDto dto);
    }

    public class AccountService : IAccountService
    {
        private readonly PuzzleDbContext _dbContext;

        public AccountService(PuzzleDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void RegisterUser(RegisterUserDto dto)
        {
            var newUser = new User()
            {
                Email = dto.Email,
                PasswordHash = dto.Password,
                RoleId = dto.RoleId,
                FirstName = dto.FirstName,
                LastName = dto.LastName,
            };

            _dbContext.PuzzleUsers.Add(newUser);
            _dbContext.SaveChanges();

        }

    }
}
