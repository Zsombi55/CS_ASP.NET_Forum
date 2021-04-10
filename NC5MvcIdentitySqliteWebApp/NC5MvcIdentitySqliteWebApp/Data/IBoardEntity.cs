using NC5MvcIdentitySqliteWebApp.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NC5MvcIdentitySqliteWebApp.Data
{
	interface IBoardEntity
	{
		BoardEntity GetById(int id);
		IEnumerable<BoardEntity> GetAll();
		
		Task Create(BoardEntity board);
		Task Delete(int boardId);
		Task UpdateForumTitle(int boardId, string newTitle);
		Task UpdateForumDescription(int boardId, string newDescription);
	}
}
