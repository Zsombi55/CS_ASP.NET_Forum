using NC5MvcIdentitySqliteWebApp.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NC5MvcIdentitySqliteWebApp.Data
{
	interface IPostEntity
	{
		PostEntity GetById(int id);
		IEnumerable<PostEntity> GetAll();
		
		Task Create(PostEntity post);
		Task Delete(int postId);
		Task UpdatePostContent(int postId, string newContent);
	}
}
