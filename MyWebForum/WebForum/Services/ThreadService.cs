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

		/// <summary>
		/// Sets a new Thread.
		/// </summary>
		/// <param name="thread">Obj.: ThreadEntity.</param>
		public async Task Create(ThreadEntity thread)
		{
			_context.Add(thread);
			await _context.SaveChangesAsync();
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
			//return _context.Threads.Include(thread => thread.Posts);
			return _context.Threads
				.Include(thread => thread.User)
				.Include(thread => thread.Posts)
					.ThenInclude(post => post.User)
				.Include(thread => thread.Forum);
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

		public IEnumerable<ThreadEntity> GetLatestThreads(int amount)
		{
			//return GetAll().OrderByDescending<ThreadEntity> (thread => thread.CreatedAt).Take(amount);
			// This was wrong OrderByDescending(<T1>, <T2>) takes 2 arguments not one.

			// Was suggested to do this because the compiler should be able to inferr the desired type.
			return GetAll().OrderByDescending(thread => thread.CreatedAt).Take(amount);
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
	}
}
