using Microsoft.EntityFrameworkCore;
using PuzzlesAPI.Entities;
using PuzzlesAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PuzzlesAPI
{
    public class PuzzleSeeder
    {
        private readonly PuzzleDbContext _dbContext;

        public PuzzleSeeder(PuzzleDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Seed()
        {
            if(_dbContext.Database.CanConnect())
            {
               var pendingMigrations = _dbContext.Database.GetPendingMigrations();

                if(pendingMigrations != null && pendingMigrations.Any())
                {
                    _dbContext.Database.Migrate();
                }

                if(!_dbContext.PuzzleRoles.Any())
                {
                    var roles = GetRoles();
                    _dbContext.PuzzleRoles.AddRange(roles);
                    _dbContext.SaveChanges();
                }

                if (!_dbContext.PuzzleTasks.Any())
                {
                    var puzzleTasks = GetPuzzleTasks();
                    _dbContext.PuzzleTasks.AddRange(puzzleTasks);
                    _dbContext.SaveChanges();
                }

            }
        }
 
        private IEnumerable<PuzzleTask> GetPuzzleTasks()
        {
            string baseUrl = "https://localhost:5001";
            baseUrl = "https://puzzlesapi.azurewebsites.net";

            List<PuzzleTask> puzzletasks = new List<PuzzleTask>();
            puzzletasks.Add(new PuzzleTask { Name = "Budapest", ImagePath = $"{baseUrl}/data/budapest.jpg" });
            puzzletasks.Add(new PuzzleTask { Name = "Amsterdam", ImagePath = $"{baseUrl}/data/amsterdam.jpg" });
            puzzletasks.Add(new PuzzleTask { Name = "Rome", ImagePath = $"{baseUrl}/data/rome.jpg" });
            puzzletasks.Add(new PuzzleTask { Name = "Berlin", ImagePath = $"{baseUrl}/data/berlin.jpg" });
            puzzletasks.Add(new PuzzleTask { Name = "Lisbon", ImagePath = $"{baseUrl}/data/lisbon.jpg" });
            puzzletasks.Add(new PuzzleTask { Name = "Brussels", ImagePath = $"{baseUrl}/data/brussels.jpg" });
            puzzletasks.Add(new PuzzleTask { Name = "London", ImagePath = $"{baseUrl}/data/london.jpg" });
            puzzletasks.Add(new PuzzleTask { Name = "Edinburgh", ImagePath = $"{baseUrl}/data/edinburgh.jpg" });
            return puzzletasks;
        }

        private IEnumerable<Role> GetRoles()
        {
            List<Role> roles = new List<Role>() {
                new Role { Name = "Admin" }, 
                new Role { Name = "User" }, 
                new Role { Name = "Guest" }
            };
            
            return roles;
        }
    }
}
