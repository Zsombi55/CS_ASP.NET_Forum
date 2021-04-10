using System.Collections.Generic;
using System.Threading.Tasks;
using NC5MvcIdentitySqliteWebApp.Entities;

namespace NC5MvcIdentitySqliteWebApp.Data
{
	public interface IThreadEntity
	{
		ThreadEntity GetById(int id);
		IEnumerable<ThreadEntity> GetAll();
		IEnumerable<ThreadEntity> GetThreadsByForum(int id);
		IEnumerable<ThreadEntity> GetFilteredThreads(string searchQuery);

		Task Create(ThreadEntity thread);
		Task Delete(int threadId);
		Task UpdateThreadTitle(int threadId, string newTitle);
		
		Task AddPost(PostEntity postEntity);
	}
}
