﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebForum.Data;
using WebForum.Entities;
using WebForum.Models.AppUser;

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

		public IActionResult Index()
		{
			return View();
		}

		public IActionResult Detail(string id)
		{
			var user = _userService.GetById(id);
			var userRoles = _userManager.GetRolesAsync(user).Result;

			var model = new ProfileModel(){
				UserId = user.Id,
				UserName = user.UserName,
				UserRating = user.Rating.ToString(),
				Email = user.Email,
				ProfileImgUrl = user.ProfileImageUrl,
				MemberSince = user.MemberSince,
				IsAdmin = userRoles.Contains("Admin")
			};

			return View(model);
		}

		[HttpPost]
		public async Task<IActionResult> PostProfileImg (IFormFile file)
		{
			//
		}
	}
}
