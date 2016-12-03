using System;
using SQLite;

namespace Hantec
{
	public interface ISQLite
	{
		SQLiteConnection GetConnection();
	}
}
