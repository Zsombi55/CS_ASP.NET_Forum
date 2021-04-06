using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebForum.Data;
using WebForum.Entities;

namespace WebForum.Services
{
	public class ThreadService : IThreadEntity
	{
		private readonly ApplicationDbContext _context;

		/// <summary>
		/// ThreadService uses EF to interact with the actual Data.
		/// </summary>
		public ThreadService(ApplicationDbContext context)
		{
			_context = context;
		}

		public Task AddReply(PostEntity postEntity)
		{
			throw new NotImplementedException();
		}

		public Task Create(ThreadEntity thread)
		{
			throw new NotImplementedException();
		}

		public Task Delete(int threadId)
		{
			throw new NotImplementedException();
		}

		/// <summary>
		/// Gets all Threads & their Posts.
		/// </summary>
		/// <returns>Every instance of the ThreadEntity object.</returns>
		public IEnumerable<ThreadEntity> GetAll()
		{
			return _context.Threads.Include(thread => thread.Posts);
		}

		/// <summary>
		/// Gets 1 Thread & its reply Posts.
		/// </summary>
		public ThreadEntity GetById(int id)
		{
			var thread = _context.Threads.Where(thread => thread.Id == id)
				.Include(thread => thread.User)
				.Include(thread => thread.Posts)
					.ThenInclude(post => post.User)
				.Include(thread => thread.Forum)
				.First();

			return thread;
		}

		public IEnumerable<ThreadEntity> GetFilteredThreads(string searchQuery)
		{
			throw new NotImplementedException();
		}

		public IEnumerable<ThreadEntity> GetThreadsByForum(int id)
		{
			return _context.Forums.Where(forum => forum.Id == id)
				.First().Threads;
					
			//var threads = _context.Forums.Where(forum => forum.Id == id)
			//	.First().Threads;
			//
			//return threads;
		}

		public Task UpdateThreadContent(int threadId, string newContent)
		{
			throw new NotImplementedException();
		}

		public Task UpdateThreadTitle(int threadId, string newTitle)
		{
			throw new NotImplementedException();
		}
	}
}
