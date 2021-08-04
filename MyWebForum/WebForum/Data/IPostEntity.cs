using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebForum.Entities;

namespace WebForum.Data
{
	public interface IPostEntity
	{
		PostEntity GetById(int id);
		IEnumerable<PostEntity> GetAll();
		//IEnumerable<PostEntity> GetLatestPosts(int amount); // to get/ load at once.

		//Task Create(PostEntity post);
		//Task Delete(int postId);
		//Task UpdatePostContent(int postId, string newContent);

		//Task AddReply(PostEntity postEntity);
	}
}
