using System.Collections.Generic;
using System.Threading.Tasks;
using NC5MvcIdentitySqliteWebApp.Entities;

namespace NC5MvcIdentitySqliteWebApp.Data
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
