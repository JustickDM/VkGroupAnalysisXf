using System;
using System.Collections.Generic;
using System.IO;

namespace DataLayer.Models
{
	/// <summary>
	/// Модель консультанта.
	/// </summary>
	public class Consultant
	{
		/// <summary>
		/// Идентификатор консультанта.
		/// </summary>
		public string Id { get; set; }
		/// <summary>
		/// Имя.
		/// </summary>
		public string FirstName { get; set; }
		/// <summary>
		/// Фамилия.
		/// </summary>
		public string LastName { get; set; }
		/// <summary>
		/// Отчество.
		/// </summary>
		public string MiddleName { get; set; }
		/// <summary>
		/// Факультет.
		/// </summary>
		public string Faculty { get; set; }
		/// <summary>
		/// Друзья консультанта.
		/// </summary>
		public List<User> Friends = new List<User>();
	}

	public class CreateListConssultant
	{
		public static List<Consultant> Creating()
		{
			List<Consultant> temp = new List<Consultant>();
			string[] tempStrings1;
			int id = 0;
			if (!File.Exists("INF.txt"))
			{
				FileStream S = new FileStream("INF.txt", FileMode.CreateNew);
				S.Close();
				return temp = null;
			}
			string str = File.ReadAllText("INF.txt");
			if (str.Length != 0)
			{
				tempStrings1 = str.Split(new char[] { ' ' });
				try
				{
					for (int j = 0; j < tempStrings1.Length; j++)
					{
						if (id >= tempStrings1.Length) break;
						else
						{
							temp.Add(new Consultant { FirstName = tempStrings1[id], LastName = tempStrings1[id + 1], Id = tempStrings1[id + 2], Faculty = tempStrings1[id + 3] });
							id = id + 4;
						}
					}
				}
				catch (Exception)
				{
					return temp = null;
				}
				return temp;
			}
			else
				return temp = null;
		}
	}
}
