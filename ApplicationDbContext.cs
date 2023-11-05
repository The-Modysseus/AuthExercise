using AuthExercise.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AuthExercise
{
	public class ApplicationDbContext : IdentityDbContext<ApiUser>
	{
		private const string DbName = "AuthExercise";
		private const string ConnectionString = $"Data Source=localhost;Initial Catalog={DbName};User ID=SA;Password=Modi13040921;Connect Timeout=30;Encrypt=False;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False";
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) 
		: base(options)
		{ }

		DbSet<ApiUser> Users { get; set; }

	}
}
