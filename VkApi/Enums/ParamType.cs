using System.ComponentModel;

namespace VkApi.Enums
{
	/// <summary>
	/// Тип параметра HTTP-запроса.
	/// </summary>
	public enum ParamType
	{
		/// <summary>
		/// Ключ доступа.
		/// </summary>
		[Description("access_token")]
		AccessToken,

		/// <summary>
		/// Идентификатор пользователя.
		/// </summary>
		[Description("user_id")]
		UserId,

		/// <summary>
		/// Cортировка, с которой необходимо вернуть список участников.
		/// </summary>
		[Description("sort")]
		Sort,

		/// <summary>
		/// Идентификатор сообщества.
		/// </summary>
		[Description("group_id")]
		GroupId,

		/// <summary>
		/// Смещение, необходимое для выборки определенного подмножества пользователей.
		/// </summary>
		[Description("offset")]
		Offset,

		/// <summary>
		/// Количество пользователей, которое необходимо получить.
		/// </summary>
		[Description("count")]
		Count,

		/// <summary>
		/// Список дополнительных полей, которые необходимо вернуть. 
		/// </summary>
		[Description("fields")]
		Fields,

		/// <summary>
		/// Версия API ВКонтакте.
		/// </summary>
		[Description("v")]
		Version,

		/// <summary>
		/// Перечисленные через запятую идентификаторы пользователей или их короткие имена (screen_name). 
		/// По умолчанию — идентификатор текущего пользователя. список слов, разделенных через запятую, 
		/// количество элементов должно составлять не более 1000.
		/// </summary>
		[Description("user_ids")]
		UserIds,

		/// <summary>
		/// Падеж для склонения имени и фамилии пользователя.
		/// </summary>
		[Description("name_case")]
		NameCase,

		/// <summary>
		/// Строка поискового запроса.
		/// </summary>
		[Description("q")]
		Q,

		/// <summary>
		/// Название города строкой.
		/// </summary>
		[Description("hometown")]
		Hometown,

		/// <summary>
		/// Возраст, от.
		/// </summary>
		[Description("age_from")]
		AgeFrom,

		/// <summary>
		/// Возраст, до.
		/// </summary>
		[Description("age_to")]
		AgeTo,

		/// <summary>
		/// День рождения.
		/// </summary>
		[Description("birth_day")]
		BirthDay,

		/// <summary>
		/// Месяц рождения.
		/// </summary>
		[Description("birth_month")]
		BirthMonth,

		/// <summary>
		/// Год рождения.
		/// </summary>
		[Description("birth_year")]
		BirthYear
	}
}
