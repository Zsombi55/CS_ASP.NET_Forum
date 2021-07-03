using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebForum.Data;
using WebForum.Entities;

namespace WebForum.Controllers
{
	public class ProfileController : Controller
	{
		private readonly UserManager<ApplicationUser> _userManager;
		private readonly IApplicationUser _userService;
		private readonly IUpload _uploadService;

		public ProfileController(UserManager<ApplicationUser> userManager, IApplicationUser userService, IUpload uploadService)
		{
			_userManager = userManager;
			_userService = userService;
			_uploadService = uploadService; //For file upload handling, ex. profile pictures.
		}

		public IActionResult Detail(string id)
		{
			return View();
		}

		public IActionResult Index()
		{
			return View();
		}
	}
}
