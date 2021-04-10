using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace NC5MvcIdentitySqliteWebApp.Entities
{
	public class ApplicationUser : IdentityUser
	{
		public int Rating { get; set; }

		public string ProfileImageUrl { get; set; }

		public DateTime MemberSince { get; set; }

		public bool IsActive { get; set; } // True = active /online; False = inactive /offline.

		public IEnumerable<ThreadEntity> Threads { get; set; }

		public IEnumerable<PostEntity> Posts { get; set; }
	}
}
