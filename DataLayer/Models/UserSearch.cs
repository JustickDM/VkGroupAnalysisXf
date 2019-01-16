using System.Collections.Generic;

namespace DataLayer.Models
{
	public class UserSearch
	{
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
		/// День рождения.
		/// </summary>
		public string BirthDay { get; set; }

		/// <summary>
		/// Месяц рождения.
		/// </summary>
		public string BirthMonth { get; set; }

		/// <summary>
		/// Год рождения.
		/// </summary>
		public string BirthYear { get; set; }

		/// <summary>
		/// Год рождения.
		/// </summary>
		public string Hometown { get; set; }

		/// <summary>
		/// Id страницы.
		/// </summary>
		public List<string> Ids { get; set; } = new List<string>();
	}
}
