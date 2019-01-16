using Newtonsoft.Json;

using System.Collections.Generic;

using VkApi.Enums;

namespace VkApi.JsonResult
{
	/// <summary>
	/// Возвращаемая информация о пользователе ВКонтакте.
	/// </summary>
	public class UserJson
	{
		/// <summary>
		/// Идентификатор пользователя.
		/// </summary>
		[JsonProperty("id")]
		public int Id { get; set; }

		/// <summary>
		/// Имя.
		/// </summary>
		[JsonProperty("first_name")]
		public string FirstName { get; set; }

		/// <summary>
		/// Фамилия.
		/// </summary>
		[JsonProperty("last_name")]
		public string LastName { get; set; }

		/// <summary>
		/// Отчетсво.
		/// </summary>
		[JsonProperty("nickname")]
		public string MiddleName { get; set; }

		/// <summary>
		/// Пол.
		/// </summary>
		[JsonProperty("sex")]
		public SexType SexType { get; set; }

		/// <summary>
		/// Информаия о городе.
		/// </summary>
		[JsonProperty("city")]
		public CityJson City { get; set; }

		/// <summary>
		/// Информация о стране.
		/// </summary>
		[JsonProperty("country")]
		public CountryJson Country { get; set; }

		/// <summary>
		/// Url квадратной фотографии пользователя, имеющей ширину 50 пикселей.
		/// </summary>
		[JsonProperty("photo_50")]
		public string Photo50 { get; set; }

		/// <summary>
		/// Url квадратной фотографии пользователя, имеющей ширину 100 пикселей.
		/// </summary>
		[JsonProperty("photo_100")]
		public string Photo100 { get; set; }

		/// <summary>
		/// Url фотографии пользователя, имеющей ширину 200 пикселей.
		/// </summary>
		[JsonProperty("photo_200_orig")]
		public string PhotoOrig200 { get; set; }

		/// <summary>
		/// Url квадратной фотографии пользователя, имеющей ширину 200 пикселей.
		/// </summary>
		[JsonProperty("photo_200")]
		public string Photo200 { get; set; }

		/// <summary>
		/// Url фотографии пользователя, имеющей ширину 400 пикселей.
		/// </summary>
		[JsonProperty("photo_400_orig")]
		public string PhotoOrig400 { get; set; }

		/// <summary>
		/// Url квадратной фотографии пользователя с максимальной шириной. 
		/// Может быть возвращена фотография, имеющая ширину как 200, так и 100 пикселей. 
		/// </summary>
		[JsonProperty("photo_max")]
		public string PhotoMax { get; set; }

		/// <summary>
		/// Url фотографии пользователя максимального размера.
		/// Может быть возвращена фотография, имеющая ширину как 400, так и 200 пикселей. 
		/// </summary>
		[JsonProperty("photo_max_orig")]
		public string PhotoMaxOrig { get; set; }

		/// <summary>
		/// Статус страницы. Содержит значение "deleted" или "banned".
		/// </summary>
		[JsonProperty("deactivated")]
		public string Deactivated { get; set; }

		/// <summary>
		/// Список ВУЗов, в которых учился пользователь.
		/// </summary>
		[JsonProperty("universities")]
		public List<UniversityJson> Universities { get; set; }

		/// <summary>
		/// Дата рождения.
		/// </summary>
		[JsonProperty("bdate")]
		public string BirthDate { get; set; }
	}
}