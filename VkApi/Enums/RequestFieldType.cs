using System.ComponentModel;

namespace VkApi.Enums
{
	/// <summary>
	/// Тип дополнительного поля в HTTP-запросе, который необходимо вернуть. 
	/// </summary>
	public enum RequestFieldType
	{
		/// <summary>
		/// Имя.
		/// </summary>
		[Description("first_name")]
		FirstName,

		/// <summary>
		/// Фамилия.
		/// </summary>
		[Description("last_name")]
		LastName,

		/// <summary>
		/// Отчество.
		/// </summary>
		[Description("nickname")]
		MiddleName,

		/// <summary>
		/// Пол.
		/// </summary>
		[Description("sex")]
		Sex,

		/// <summary>
		/// Город.
		/// </summary>
		[Description("city")]
		City,

		/// <summary>
		/// Страна.
		/// </summary>
		[Description("country")]
		Country,

		/// <summary>
		/// Url квадратной фотографии пользователя, имеющей ширину 50 пикселей.
		/// </summary>
		[Description("photo_50")]
		Photo50,

		/// <summary>
		/// Url квадратной фотографии пользователя, имеющей ширину 100 пикселей.
		/// </summary>
		[Description("photo_100")]
		Photo100,

		/// <summary>
		/// Url фотографии пользователя, имеющей ширину 200 пикселей.
		/// </summary>
		[Description("photo_200_orig")]
		PhotoOrig200,

		/// <summary>
		/// Url квадратной фотографии пользователя, имеющей ширину 200 пикселей.
		/// </summary>
		[Description("photo_200")]
		Photo200,

		/// <summary>
		/// Url фотографии пользователя, имеющей ширину 400 пикселей.
		/// </summary>
		[Description("photo_400_orig")]
		PhotoOrig400,

		/// <summary>
		/// Url квадратной фотографии пользователя с максимальной шириной. 
		/// Может быть возвращена фотография, имеющая ширину как 200, так и 100 пикселей. 
		/// </summary>
		[Description("photo_max")]
		PhotoMax,

		/// <summary>
		/// Url фотографии пользователя максимального размера.
		/// Может быть возвращена фотография, имеющая ширину как 400, так и 200 пикселей. 
		/// </summary>
		[Description("photo_max_orig")]
		PhotoMaxOrig,

		/// <summary>
		/// Статус страницы.
		/// </summary>
		[Description("deactivated")]
		Deactivated,

		/// <summary>
		/// Дата рождения.
		/// </summary>
		[Description("bdate")]
		BirthDate,

		/// <summary>
		/// Список ВУЗов, в которых учился пользователь.
		/// </summary>
		[Description("universities")]
		Universities
	}
}
