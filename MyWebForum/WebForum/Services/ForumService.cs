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
	/// Also allows the injection of single instances of the Service to Controllers for all interactions. 
	/// </summary>
	public class ForumService : IForumEntity
	{
		private readonly ApplicationDbContext _context;

		/// <summary>
		/// ForumService uses EF to interact with the actual Data.
		/// </summary>
		public ForumService(ApplicationDbContext context)
		{
			_context = context;
		}

		/// <summary>
		/// Sets a new Forum.
		/// </summary>
		/// <param name="forum">Obj.: ForumEntity.</param>
		public async Task Create(ForumEntity forum)
		{
			_context.Add(forum);
			await _context.SaveChangesAsync();
		}

		/// <summary>
		/// Deletes an existing Forum.
		/// </summary>
		/// <param name="forumId">Integer: a specific ForumEntity's ID.</param>
		/// <remarks>Not actually implemented for use.</remarks>
		public async Task Delete(int forumId)
		{
			var forum = GetById(forumId);
			_context.Remove(forum);
			await _context.SaveChangesAsync();
		}
		
		/// <summary>
		/// Gets all Forums & their Threads.
		/// </summary>
		/// <returns>Every instance of the ForumEntity object.</returns>
		/// <remarks>If not all threads are to be loaded, modify or overload this.</remarks>
		public IEnumerable<ForumEntity> GetAll()
		{
			return _context.Forums.Include(forum => forum.Threads);
		}

		public IEnumerable<ApplicationUser> GetAllActiveUsers()
		{
			throw new NotImplementedException();
		}

		/// <summary>
		/// Gets a Forum object by its ID, and its Threads.
		/// </summary>
		/// <param name="id">Int: forum ID, primary key in DB.</param>
		/// <returns>ForumEntity object: a forum.</returns>
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
