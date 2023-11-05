using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace AuthExercise.Models
{
	public class ApiUser : IdentityUser
	{
		[MaxLength(100)]
		public string? FullName { get; set; }
	}
}
