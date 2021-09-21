using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using PuzzlesAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PuzzlesAPI.Controllers
{


    [Route("api/[controller]")]
    [ApiController]
    public class PuzzleTaskController : ControllerBase
    {
        private readonly PuzzleDbContext _dbContext;

        public PuzzleTaskController(PuzzleDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public IEnumerable<PuzzleTask> Get()
        {
            var puzzleTasks = _dbContext.PuzzleTasks.ToList();
            return puzzleTasks;
        }


        [HttpGet("{id}")]
        public ActionResult<PuzzleTask> Get(int id)
        {
            var puzzleTask = _dbContext.PuzzleTasks.FirstOrDefault(p => p.Id == id);

            if (puzzleTask is null)
                return NotFound();

            return Ok(puzzleTask);
         
        }

        //// POST api/<PuzzleTaskController>
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        //// PUT api/<PuzzleTaskController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<PuzzleTaskController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
