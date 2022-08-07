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
	public class ProducersController : ControllerBase
	{
		private readonly ProjectDBContext _dbContext;
		public ProducersController(ProjectDBContext dbContext)
		{
			_dbContext = dbContext;
		}

		// GET: api/<ProducersController>
		[HttpGet]
		public async Task<ActionResult<IEnumerable<Producer>>> GetProducers()
		{
			try
			{
				return Ok(await _dbContext.Producers.ToListAsync());
			}
			catch (Exception)
			{
				return StatusCode(500, "Internal server error. An error occured while retriving producers list.");
			}
		}

		// GET api/<ProducersController>/5
		[HttpGet("{id}")]
		public async Task<ActionResult<Producer>> GetProducers(int id)
		{
			try
			{
				var producer = await _dbContext.Producers.FindAsync(id);

				if (producer == null) return NotFound();

				return Ok(producer);
			}
			catch (Exception)
			{
				return StatusCode(500, "Internal server error. An error occured while retriving data for the producer.");
			}
		}
	}
}
