using DeltaX.Models;
using Microsoft.AspNetCore.Http;
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
	public class MoviesController : ControllerBase
	{
		private readonly ProjectDBContext _dbContext;
		public MoviesController(ProjectDBContext dbContext)
		{
			_dbContext = dbContext;
		}

		// GET: api/<MoviesController>
		[HttpGet]
		public async Task<ActionResult<IEnumerable<Movie>>> GetMovies()
		{
			try
			{
				return Ok(await _dbContext.Movies.ToListAsync());
			}
			catch (Exception)
			{
				return StatusCode(500, "Internal server error. An error occured while retriving movies list.");
			}
		}

		// GET api/<MoviesController>/5
		[HttpGet("{id}")]
		public async Task<ActionResult<Movie>> GetMovies(int id)
		{
			try
			{
				var movie = await _dbContext.Movies.FindAsync(id);

				if (movie == null) return NotFound();

				return Ok(movie);
			}
			catch (Exception)
			{
				return StatusCode(500, "Internal server error. An error occured while retriving data for the movie.");
			}
		}

		// POST api/<MoviesController>
		[HttpPost]
		public async Task<ActionResult<Movie>> AddMovie(Movie movie)
		{
			try
			{
				if (movie == null)
					return BadRequest();

				await _dbContext.Movies.AddAsync(movie);
				await _dbContext.SaveChangesAsync();

				return CreatedAtAction(nameof(GetMovies),
					new { id = movie.Id }, movie);
			}
			catch (Exception)
			{
				return StatusCode(500, "Internal server error. An error occured while creating the movie.");
			}
		}

		// PUT api/<MoviesController>/5
		[HttpPut("{id}")]
		public async Task<ActionResult<Movie>> UpdateMovie(string id, Movie movie)
		{
			try
			{
				if (!id.Equals(movie.Id)) return BadRequest();

				_dbContext.Entry(movie).State = EntityState.Modified;
				await _dbContext.SaveChangesAsync();

				return NoContent();
			}
			catch (Exception)
			{
				return StatusCode(500, "Internal server error. An error occured while updating data for the movie.");
			}
		}

	}
}
