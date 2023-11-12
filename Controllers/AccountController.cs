using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using AuthExercise.Models;
using AuthExercise.DTO;

namespace AuthExercise.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class AccountController : ControllerBase
	{
		private readonly ApplicationDbContext _context;
		private readonly ILogger<DrinkController> _logger;
		private readonly IConfiguration _configuration;
		private readonly UserManager<ApiUser> _userManager;
		private readonly SignInManager<ApiUser> _signInManager;

		public AccountController(ApplicationDbContext context, ILogger<DrinkController> logger, IConfiguration configuration, UserManager<ApiUser> userManager, SignInManager<ApiUser> signInManager)
		{
			_context = context;
			_logger = logger;
			_configuration = configuration;
			_userManager = userManager;
			_signInManager = signInManager;
		}

		public async Task<ActionResult> Register(RegisterDTO input)
		{
			try
			{
                if (ModelState.IsValid)
                {
					var newUser = new ApiUser();
					newUser.UserName = input.Email;
					newUser.Email = input.Email;
					newUser.FullName = input.FullName;
					var result = await _userManager.CreateAsync(newUser, input.Password);
					if (result.Succeeded)
					{
						_logger.LogInformation("User {userName} ({email}) has been created.", newUser.UserName, newUser.Email);
						return StatusCode(201, $"User '{newUser.UserName}' has been created.");
					}
					else
					{
						throw new Exception(string.Format("Error: {0}", string.Join(" ", result.Errors.Select(e => e.Description))));
					}
                }
				else
            }
		}
	}

}
