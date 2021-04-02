using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebForum.Data;
using WebForum.Entities;

namespace WebForum.Services
{
	/// <summary> MAYBE :
	/// Take data from the "Data Layer" and Serve it to the WebForum's various controllers.
	/// 
	/// Eg.: if a controller has an Idex() action to display all forums,
	/// this server will ask the ApplicationDbContext with the Entity models to GET it;
	/// then the server gets it from the DataBase, hands it bundled back to the ApplicationDbContext,
	/// which then forwards it to the appropriate Controller for further manipulation & display.
	/// 
	/// Also allows the injection of single instances of the Srvice to Controllers for all interactions. 
	/// </summary>
	public class ForumServices : IForumEntity
	{
		private readonly ApplicationDbContext _context;

		/// <summary>
		/// ForumService uses EF to interact with the actual Data.
		/// </summary>
		public ForumServices(ApplicationDbContext context)
		{
			_context = context;
		}

		public Task Create(ForumEntity forum)
		{
			throw new NotImplementedException();
		}

		public Task Delete(int forumId)
		{
			throw new NotImplementedException();
		}
		
		/// <summary>
		/// Gets all Forums & their Threads.
		/// </summary>
		/// <returns>Every instance of the ForumEntity object.</returns>
		public IEnumerable<ForumEntity> GetAll()
		{
			return _context.Forums.Include(forum => forum.Threads);
		}

		public IEnumerable<ApplicationUser> GetAllActiveUsers()
		{
			throw new NotImplementedException();
		}

		public ForumEntity GetById(int id)
		{
			var forum = _context.Forums.Where(forum => forum.Id == id)
				.Include(forum => forum.Threads)
					.ThenInclude(thread => thread.User)
				.Include(forum => forum.Threads)
					.ThenInclude(thread => thread.Posts)
						.ThenInclude(post => post.User)
				.FirstOrDefault();

			return forum;
		}

		public Task UpdateForumDescription(int forumId, string newDescription)
		{
			throw new NotImplementedException();
		}

		public Task UpdateForumTitle(int forumId, string newTitle)
		{
			throw new NotImplementedException();
		}
	}
}
