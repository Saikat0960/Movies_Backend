using DeltaX.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeltaX
{
	public class ProjectDBContext: DbContext
	{
		public ProjectDBContext(DbContextOptions<ProjectDBContext> options) : base(options)
		{

		}

		public DbSet<Actor> Actors { get; set; }
		public DbSet<Movie> Movies { get; set; }
		public DbSet<Producer> Producers { get; set; }
	}
}
