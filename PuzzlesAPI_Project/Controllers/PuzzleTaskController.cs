using Microsoft.AspNetCore.Mvc;
using PuzzlesAPI.Models;
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
        List<PuzzleTask>  puzzletasks = new List<PuzzleTask> { new PuzzleTask { Id = 1, Name = "Budapest", ImagePath="https://localhost:5001/data/budapest.jpg" },
                new PuzzleTask { Id = 2, Name = "Amsterdam", ImagePath="https://localhost:5001/data/amsterdam.jpg" },
                new PuzzleTask { Id = 3, Name = "Rome", ImagePath = "https://localhost:5001/data/rome.jpg" },
                new PuzzleTask { Id = 4, Name = "Berlin", ImagePath = "https://localhost:5001/data/berlin.jpg" },
                new PuzzleTask { Id = 5, Name = "Lisbon", ImagePath = "https://localhost:5001/data/lisbon.jpg" },
                new PuzzleTask { Id = 6, Name = "Brussels", ImagePath = "https://localhost:5001/data/brussels.jpg" },
                new PuzzleTask { Id = 7, Name = "London", ImagePath = "https://localhost:5001/data/london.jpg" },
                new PuzzleTask { Id = 8, Name = "Edinburgh", ImagePath = "https://localhost:5001/data/edinburgh.jpg" }};
// GET: api/<PuzzleTaskController>
[HttpGet]
        public IEnumerable<PuzzleTask> Get()
        {
            return puzzletasks;
               
        }

        // GET api/<PuzzleTaskController>/5
        [HttpGet("{id}")]
        public PuzzleTask Get(int id)
        {
            return puzzletasks.FirstOrDefault(x => x.Id == id);
        }

        // POST api/<PuzzleTaskController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<PuzzleTaskController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<PuzzleTaskController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
