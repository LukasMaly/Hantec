using System;
using SQLite;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;

namespace Hantec
{
	public class WordItemDatabase
	{
		static object locker = new object();

		SQLiteConnection database;

		public WordItemDatabase()
		{
			database = DependencyService.Get<ISQLite>().GetConnection();
			// create the tables
			database.CreateTable<WordItem>();
		}

		public IEnumerable<WordItem> GetItems()
		{
			lock (locker)
			{
				return (from i in database.Table<WordItem>() select i).ToList();
			}
		}

		public IEnumerable<WordItem> GetItemsOrdered()
		{
			string column = App.IsHantecToCestina ? "Hantec" : "Cestina";

			return GetItemsOrderedBy(column);
		}

		public IEnumerable<WordItem> GetItemsOrderedBy(string column)
		{
			lock (locker)
			{
				return database.Query<WordItem>(String.Format("SELECT * FROM [WordItem] ORDER BY [{0}]", column));
			}
		}

		public IEnumerable<WordItem> GetWord(string word)
		{
			if (App.IsHantecToCestina)
			{
				return GetWordInHantec(word);
			}
			else
			{
				return GetWordInCestina(word);
			}
		}

		public IEnumerable<WordItem> GetWordInHantec(string hantec)
		{
			lock (locker)
			{
				return database.Query<WordItem>(String.Format("SELECT * FROM [WordItem] WHERE [Hantec] LIKE \"{0}%\"", hantec));
			}
		}

		public IEnumerable<WordItem> GetWordInCestina(string cestina)
		{
			lock (locker)
			{
				return database.Query<WordItem>(String.Format("SELECT * FROM [WordItem] WHERE [Cestina] LIKE \"{0}%\"", cestina));
			}
		}

		public WordItem GetItem(int id)
		{
			lock (locker)
			{
				return database.Table<WordItem>().FirstOrDefault(x => x.ID == id);
			}
		}

		public int SaveItem(WordItem item)
		{
			lock (locker)
			{
				if (item.ID != 0)
				{
					database.Update(item);
					return item.ID;
				}
				else {
					return database.Insert(item);
				}
			}
		}

		public int DeleteItem(int id)
		{
			lock (locker)
			{
				return database.Delete<WordItem>(id);
			}
		}
	}
}
