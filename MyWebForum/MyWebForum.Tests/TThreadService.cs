using WebForum.Data;
using WebForum.Entities;
using WebForum.Services;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System;
using System.Linq;

namespace MyWebForum.Tests
{
	[TestFixture]
	public class TThreadService
	{
		[TestCase("coffee", 3)]
		[TestCase("tea", 1)]
		[TestCase("water", 0)]
		public void Return_Filtered_Results_Matching_Query(string query, int expectedNr)
		{
			var options = new DbContextOptionsBuilder<ApplicationDbContext>()
					.UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()).Options;

			// Arrange.
			using (var ctx = new ApplicationDbContext(options))
			{
				ctx.Forums.Add(new ForumEntity
				{
					Id = 19
				});

				ctx.Threads.Add(new ThreadEntity
				{
					Forum = ctx.Forums.Find(19),
					Id = 23523,
					Title = "First Thread",
					Content = "Coffee"
				});

				ctx.Threads.Add(new ThreadEntity
				{
					Forum = ctx.Forums.Find(19),
					Id = -2144,
					Title = "Coffee",
					Content = "Some Content"
				});

				ctx.Threads.Add(new ThreadEntity
				{
					Forum = ctx.Forums.Find(19),
					Id = 223,
					Title = "Tea",
					Content = "Coffee"
				});

				ctx.SaveChanges();
			}

			// Act.
			using (var ctx = new ApplicationDbContext(options))
			{
				var threadService = new ThreadService(ctx);

				var result = threadService.GetFilteredThreads(query);

				var threadCount = result.Count();

				// Assert.
				Assert.AreEqual(expectedNr, threadCount); // true
				//Assert.AreEqual(4, threadCount); // false
				//Assert.AreEqual(0, threadCount); // false
				//Assert.AreEqual(1, threadCount); // false
			}
		}
	}
}
