using PuzzlesAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PuzzlesAPI.Services
{

    public interface IPuzzleTaskService
    {
        public IEnumerable<PuzzleTask> AllTasks();
        public PuzzleTask Task(int taskId);
    }
    public class PuzzleTaskService : IPuzzleTaskService
    {
        private readonly PuzzleDbContext _dbContext;

        public PuzzleTaskService(PuzzleDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<PuzzleTask> AllTasks()
        {
            return _dbContext.PuzzleTasks.ToArray();
        }

        public PuzzleTask Task(int taskId)
        {
            return _dbContext.PuzzleTasks.FirstOrDefault(t => t.Id == taskId);
        }
    }
}
