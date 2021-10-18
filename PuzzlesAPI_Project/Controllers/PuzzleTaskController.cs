using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using PuzzlesAPI.Entities;
using PuzzlesAPI.Services;
using System.Collections.Generic;
using System.Linq;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PuzzlesAPI.Controllers
{


    [Route("api/[controller]")]
    [ApiController]
    public class PuzzleTaskController : ControllerBase
    {
        private readonly IPuzzleTaskService _puzzleTaskService;

        public PuzzleTaskController(IPuzzleTaskService puzzleTaskService)
        {
            _puzzleTaskService = puzzleTaskService;
        }

        //GET: api/<PuzzleTaskController>
        [HttpGet]
        public IEnumerable<PuzzleTask> Get()
        {
            return _puzzleTaskService.AllTasks();
        }

        // GET api/<PuzzleTaskController>/5
        [HttpGet("{id}")]
        public PuzzleTask Get(int id)
        {
            return _puzzleTaskService.Task(id);
        }
    }
}
