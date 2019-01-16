using DataLayer.CustomTypes;
using DataLayer.Enums;

using System;
using System.Collections.Generic;

using VkApi.Enums;
using VkApi.JsonResult;

namespace DataLayer.Models
{
	/// <summary>
	/// Модель пользователя ВКонтакте.
	/// </summary>
	public class User
	{
		/// <summary>
		/// Идентификатор пользователя.
		/// </summary>
		public int Id { get; set; }

		/// <summary>
		/// Имя.
		/// </summary>
		public string FirstName { get; set; }

		/// <summary>
		/// Фамилия.
		/// </summary>
		public string LastName { get; set; }

		/// <summary>
		/// Отчетсво.
		/// </summary>
		public string MiddleName { get; set; }

		/// <summary>
		/// Пол.
		/// </summary>
		public SexType SexType { get; set; }

		/// <summary>
		/// Информаия о городе.
		/// </summary>
		public CityJson City { get; set; }

		/// <summary>
		/// Информация о стране.
		/// </summary>
		public CountryJson Country { get; set; }

		/// <summary>
		/// Url квадратной фотографии пользователя, имеющей ширину 50 пикселей.
		/// </summary>
		public string Photo50 { get; set; }

		/// <summary>
		/// Url квадратной фотографии пользователя, имеющей ширину 100 пикселей.
		/// </summary>
		public string Photo100 { get; set; }

		/// <summary>
		/// Url фотографии пользователя, имеющей ширину 200 пикселей.
		/// </summary>
		public string PhotoOrig200 { get; set; }

		/// <summary>
		/// Url квадратной фотографии пользователя, имеющей ширину 200 пикселей.
		/// </summary>
		public string Photo200 { get; set; }

		/// <summary>
		/// Url фотографии пользователя, имеющей ширину 400 пикселей.
		/// </summary>
		public string PhotoOrig400 { get; set; }

		/// <summary>
		/// Url квадратной фотографии пользователя с максимальной шириной. 
		/// Может быть возвращена фотография, имеющая ширину как 200, так и 100 пикселей. 
		/// </summary>
		public string PhotoMax { get; set; }

		/// <summary>
		/// Url фотографии пользователя максимального размера.
		/// Может быть возвращена фотография, имеющая ширину как 400, так и 200 пикселей. 
		/// </summary>
		public string PhotoMaxOrig { get; set; }

		// Url квадратной фотографии пользователя, имеющей наибольшую ширину пикселей. 
		public string Photo
		{
			get
			{
				return PhotoMax ?? Photo200 ?? Photo100 ?? Photo50 ?? String.Empty;
			}
		}

		/// <summary>
		/// Статус страницы. Содержит значение "deleted" или "banned".
		/// </summary>
		public DeactivatedType Deactivated { get; set; }

		/// <summary>
		/// Список ВУЗов, в которых учился пользователь.
		/// </summary>
		public List<UniversityJson> Universities { get; set; }

		/// <summary>
		/// Дата рождения.
		/// </summary>
		public BirthDate BirthDate { get; set; }

		/// <summary>
		/// Факультеты консультантов.
		/// </summary>
		public List<string> Faculties { get; set; }
	}
}
