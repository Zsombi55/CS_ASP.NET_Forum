using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebForum.Entities;

namespace WebForum.Data
{
	public interface IForumEntity
	{
		ForumEntity GetById(int id);
		IEnumerable<ForumEntity> GetAll();
		IEnumerable<ApplicationUser> GetAllActiveUsers();

		Task Create(ForumEntity forum);
		Task Delete(int forumId);
		Task UpdateForumTitle(int forumId, string newTitle);
		Task UpdateForumDescription(int forumId, string newDescription);
	}
}
