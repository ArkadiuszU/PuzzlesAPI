using PuzzlesAPI.Entities;
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
                if(!_dbContext.PuzzleTasks.Any())
                {
                    var puzzleTasks = GetPuzzleTasks();
                    _dbContext.PuzzleTasks.AddRange(puzzleTasks);
                    _dbContext.SaveChanges();
                }
            }
        }

        private IEnumerable<PuzzleTask> GetPuzzleTasks()
        {
            List<PuzzleTask> puzzletasks = new List<PuzzleTask>();
            puzzletasks.Add(new PuzzleTask { Name = "Budapest", ImagePath = $"https://puzzlesapi.azurewebsites.net/data/budapest.jpg" });
            puzzletasks.Add(new PuzzleTask { Name = "Amsterdam", ImagePath = $"https://puzzlesapi.azurewebsites.net/data/amsterdam.jpg" });
            puzzletasks.Add(new PuzzleTask { Name = "Rome", ImagePath = $"https://puzzlesapi.azurewebsites.net/data/rome.jpg" });
            puzzletasks.Add(new PuzzleTask { Name = "Berlin", ImagePath = $"https://puzzlesapi.azurewebsites.net/data/berlin.jpg" });
            puzzletasks.Add(new PuzzleTask { Name = "Lisbon", ImagePath = $"https://puzzlesapi.azurewebsites.net/data/lisbon.jpg" });
            puzzletasks.Add(new PuzzleTask { Name = "Brussels", ImagePath = $"https://puzzlesapi.azurewebsites.net/data/brussels.jpg" });
            puzzletasks.Add(new PuzzleTask { Name = "London", ImagePath = $"https://puzzlesapi.azurewebsites.net/data/london.jpg" });
            puzzletasks.Add(new PuzzleTask { Name = "Edinburgh", ImagePath = $"https://puzzlesapi.azurewebsites.net/data/edinburgh.jpg" });
            return puzzletasks;
        }
    }
}
