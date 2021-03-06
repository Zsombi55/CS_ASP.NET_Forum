﻿using Microsoft.AspNetCore.Identity;
using System;

namespace WebForum.Entities
{
	public class ApplicationUser : IdentityUser
	{
		public int Rating { get; set; }

		public string ProfileImageUrl { get; set; }

		public DateTime MemberSince { get; set; }

		public bool IsActive { get; set; } // True = active /online; False = inactive /offline.
	}
}
