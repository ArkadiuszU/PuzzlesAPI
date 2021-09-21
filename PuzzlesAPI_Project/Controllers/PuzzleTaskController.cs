using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using PuzzlesAPI.Entities;
using System.Collections.Generic;
using System.Linq;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PuzzlesAPI.Controllers
{


    [Route("api/[controller]")]
    [ApiController]
    public class PuzzleTaskController : ControllerBase
    {

        private IWebHostEnvironment environment;
        List<PuzzleTask> puzzletasks = new List<PuzzleTask>();

        public PuzzleTaskController(IWebHostEnvironment _environment)
        {
            environment = _environment;
            puzzletasks.Add(new PuzzleTask { Id = 1, Name = "Budapest", ImagePath = $"https://puzzlesapi.azurewebsites.net/data/budapest.jpg" });
            puzzletasks.Add(new PuzzleTask { Id = 2, Name = "Amsterdam", ImagePath = $"https://puzzlesapi.azurewebsites.net/data/amsterdam.jpg" });
            puzzletasks.Add(new PuzzleTask { Id = 3, Name = "Rome", ImagePath = $"https://puzzlesapi.azurewebsites.net/data/rome.jpg" });
            puzzletasks.Add(new PuzzleTask { Id = 4, Name = "Berlin", ImagePath = $"https://puzzlesapi.azurewebsites.net/data/berlin.jpg" });
            puzzletasks.Add(new PuzzleTask { Id = 5, Name = "Lisbon", ImagePath = $"https://puzzlesapi.azurewebsites.net/data/lisbon.jpg" });
            puzzletasks.Add(new PuzzleTask { Id = 6, Name = "Brussels", ImagePath = $"https://puzzlesapi.azurewebsites.net/data/brussels.jpg" });
            puzzletasks.Add(new PuzzleTask { Id = 7, Name = "London", ImagePath = $"https://puzzlesapi.azurewebsites.net/data/london.jpg" });
            puzzletasks.Add(new PuzzleTask { Id = 8, Name = "Edinburgh", ImagePath = $"https://puzzlesapi.azurewebsites.net/data/edinburgh.jpg" });

        }
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
