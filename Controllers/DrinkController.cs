using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AuthExercise.Models;
using AuthExercise.DTO;
using Microsoft.AspNetCore.Mvc.ActionConstraints;
using System.ComponentModel;

namespace AuthExercise.Controllers
{

	[ApiController]
	[Route("[controller]")]
	public class DrinkController : ControllerBase
	{
		private readonly MyDBContext _context;

		public DrinkController(MyDBContext context)
		{
			_context = context;
		}

		[HttpGet("ReadDrinks")]
		public async Task<ActionResult<List<Drink>>> ReadDrinks()
		{
			var query = await _context.Drinks
				.OrderBy(a => a.DrinkId)
				.ToListAsync();

			return query;
		}

		[HttpGet("ReadDrink")]
		public async Task<ActionResult<List<Drink>>> ReadDrink(int id)
		{
			var query = await _context.Drinks.Where(a => a.DrinkId == id)
				.ToListAsync();

			return query;
		}

		[HttpPost("CreateDrink")]
		public async Task<ActionResult<Drink>> CreateDrink(DrinkDTO model)
		{
			var drink = new Drink()
			{
				Name = model.Name,
				Price = model.Price
			};
			_context.Drinks.Add(drink);
			await _context.SaveChangesAsync();

			return drink;
		}

		[HttpDelete("DeleteDrink")]
		public async Task<ActionResult<Drink>> DeleteDrink(int id)
		{
			var drink = await _context.Drinks
				.Where(a => a.DrinkId == id)
				.FirstOrDefaultAsync();
			if (drink != null)
			{
				_context.Drinks.Remove(drink);
				await _context.SaveChangesAsync();
				return NoContent();
			}
			return NotFound();
		}
	}
}