using System.Collections.Generic;
using System.Threading.Tasks;
using WebForum.Entities;

namespace WebForum.Data
{
	public interface IThreadEntity
	{
		ThreadEntity GetById(int id);
		IEnumerable<ThreadEntity> GetAll();
		IEnumerable<ThreadEntity> GetThreadsByForum(int id); // forum id ; was used in ForumController.
		IEnumerable<ThreadEntity> GetFilteredThreads(string searchQuery);
		IEnumerable<ThreadEntity> GetFilteredThreads(ForumEntity forum, string searchQuery);
		IEnumerable<ThreadEntity> GetLatestThreads(int amount); // to get/ load at once.

		Task Create(ThreadEntity thread);
		Task Delete(int threadId);
		Task UpdateThreadContent(int threadId, string newContent);

		Task AddPost(PostEntity post);
	}
}
