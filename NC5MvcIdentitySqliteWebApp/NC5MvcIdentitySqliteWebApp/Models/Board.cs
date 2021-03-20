using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NC5MvcIdentitySqliteWebApp.Models
{
	public class Board
	{
		public int Id { get; set; }

		public string Name { get; set; }

		public List<Forum> Forums { get; set; }
	}
}
