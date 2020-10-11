using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LGA.API.Data;
using LGA.API.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LGA.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatesController : ControllerBase
    {
        private readonly LGAContext _context;
        public StatesController(LGAContext context)
        {
            _context = context;
        }

        // GET: api/<StatesController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<State>>> Get()
        {
            return await _context.States.ToListAsync();
        }

        // GET api/<StatesController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<State>> Get(int id)
        {
            var state = await _context.States.FindAsync(id);
            if (state == null)
                return NotFound();
            return state;
        }
    }
}
