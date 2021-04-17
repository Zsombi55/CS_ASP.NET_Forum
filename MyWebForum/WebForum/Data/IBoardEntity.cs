using System.Collections.Generic;
using System.Threading.Tasks;
using WebForum.Entities;

namespace WebForum.Data
{
	public interface IBoardEntity
	{
		BoardEntity GetById(int id);
		IEnumerable<BoardEntity> GetAll();

		Task Create(BoardEntity board);
		Task Delete(int boardId);
		Task UpdateBoardTitle(int boardId, string newTitle);
	}
}
