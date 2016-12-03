using System;
using SQLite;

namespace Hantec
{
	public class WordItem
	{
		public WordItem()
		{
		}

		[PrimaryKey, AutoIncrement]
		public int ID { get; set; }
		public string Hantec { get; set; }
		public string Cestina { get; set; }
	}
}
