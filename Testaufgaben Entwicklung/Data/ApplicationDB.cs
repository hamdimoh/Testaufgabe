using System;
using Microsoft.EntityFrameworkCore;
using Testaufgaben_Entwicklung.Models;

namespace Testaufgaben_Entwicklung.Data
{
	public class ApplicationDB : DbContext
	{
		public ApplicationDB(DbContextOptions<ApplicationDB> options) : base(options)
		{

		}
		public DbSet<Club> clubs { get; set; }
    }
}

