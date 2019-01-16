using DataLayer.Models;

using System.Collections.Generic;
using System.IO;

namespace DataLayer.Classes
{
	public class Bin
	{
		/// <summary>
		/// Запись идентификаторов новых пользователей группы в файл.
		/// </summary>
		/// <param name="Users">Список пользователей. </param>
		/// <param name="Count">Количество сохраняемых идентификаторов в файл. </param>
		public static void WriteFirstUsers(List<User> Users, int Count = 10)
		{
			var Ids = new string[Count];
			for (int i = 0; i < Count; i++) Ids[i] = Users[i].Id.ToString();
			File.WriteAllLines("Users.bin", Ids);
		}

		/// <summary>
		/// Чтение идентификаторов старых пользователей группы из файла.
		/// </summary>
		public static List<int> ReadLastUsers()
		{
			var userId = new List<int>();
			if (File.Exists("Users.bin"))
			{
				var users = File.ReadAllLines("Users.bin");
				foreach (var user in users)
				{
					if (user != null && user != "")
					{
						userId.Add(int.Parse(user));
					}
				}
				return userId;
			}else
			{
				return null;
			}
		}
	}
}
