using DeltaX.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DeltaX.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ActorsController : ControllerBase
	{
		private readonly ProjectDBContext _dbContext;
		public ActorsController(ProjectDBContext dbContext)
		{
			_dbContext = dbContext;
		}

		// GET: api/<ActorsController>
		[HttpGet]
		public async Task<ActionResult<IEnumerable<Actor>>> GetActors()
		{
			try
			{
				return Ok(await _dbContext.Actors.ToListAsync());
			}
			catch (Exception)
			{
				return StatusCode(500, "Internal server error. An error occured while retriving actors list.");
			}
		}

		// GET api/<// GET api/<ActorsController>/5>/5
		[HttpGet("{id}")]
		public async Task<ActionResult<Actor>> GetActors(int id)
		{
			try
			{
				var actor = await _dbContext.Actors.FindAsync(id);

				if (actor == null) return NotFound();

				return Ok(actor);
			}
			catch (Exception)
			{
				return StatusCode(500, "Internal server error. An error occured while retriving data for the actor.");
			}
		}
	}
}
