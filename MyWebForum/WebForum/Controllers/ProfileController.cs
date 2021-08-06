using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
//using Microsoft.Net.Http.Headers;
using System.Net.Http.Headers;
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
		private readonly IConfiguration _configuration;

		public ProfileController(UserManager<ApplicationUser> userManager, IApplicationUser userService, IUpload uploadService, IConfiguration configService)
		{
			_userManager = userManager;
			_userService = userService;
			_uploadService = uploadService; //For file upload handling, ex. profile pictures.

			_configuration = configService;
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

		/// <summary>
		/// Usfinished !!  Would have used MS Azure web-app cloud storage for storinguploaded files like profile images, however i decided not to spend time on this now, because I am unwilling to pay for storage space when i only need less than 250 MB's for storing a few placeholder/ test images for a personal test project like this. Thus, I will follow the tutorial, write the code, but it will not be tested, so it's unlikely to work even if there is an Azure storage to connect to.
		/// </summary>
		[HttpPost]
		public async Task<IActionResult> PostProfileImg (IFormFile file)
		{
			var userId = _userManager.GetUserId(User);

			// NOTE: to use Azure web-app storage see:
			// https://docs.microsoft.com/en-us/azure/azure-app-configuration/quickstart-aspnet-core-app?tabs=core5x

			// Connect to Azure Storage Account Container.
			var connectionString = _configuration.GetConnectionString("AzureStorageAccount");

			// Get Blob Container.
			var container = _uploadService.GetBlobContainer(connectionString, "profile-images");

			// Parse the Content Disposition response header
			var contantDisposition = ContentDispositionHeaderValue.Parse(file.ContentDisposition);

			// Grab the filename
			var fileName = contantDisposition.FileName.Trim('"');

			// Get a reference to a Block Blob
			var blockBlob = container.GetBlockBlobReference(fileName);

			// On that, upload our file <-- file uploaded to the cloud
			await blockBlob.UploadFromStreamAsync(file.OpenReadStream());

			// Set the User's Profle Image to the URI
			await _userService.SetProfileImg(userId, blockBlob.Uri);

			// Rediredt to the User's profile page.
			return RedirectToAction("Detail", "Profile", new { id = userId });
		}
	}
}
