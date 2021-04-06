using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebForum.Entities;

namespace WebForum.Data
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
		Task UpdateThreadContent(int threadId, string newContent);

		Task AddReply(PostEntity postEntity);
	}
}
