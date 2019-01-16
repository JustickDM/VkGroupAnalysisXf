using System.ComponentModel;

namespace VkApi.Enums
{
	/// <summary>
	/// Права доступа для токена пользователя.
	/// </summary>
	public enum AccessRightsForUserType
	{
		/// <summary>
		/// Пользователь разрешил отправлять ему уведомления (для flash/iframe-приложений).
		/// </summary>
		[Description("notify")]
		Notify,

		/// <summary>
		/// Доступ к друзьям.
		/// </summary>
		[Description("friends")]
		Friends,

		/// <summary>
		/// Доступ к фотографиям.
		/// </summary>
		[Description("photos")]
		Photos,

		/// <summary>
		/// Доступ к аудиозаписям.
		/// </summary>
		[Description("audio")]
		Audio,

		/// <summary>
		/// Доступ к видеозаписям.
		/// </summary>
		[Description("video")]
		Video,

		/// <summary>
		/// Доступ к историям.
		/// </summary>
		[Description("stories")]
		Stories,

		/// <summary>
		/// Доступ к wiki-страницам.
		/// </summary>
		[Description("pages")]
		Pages,

		/// <summary>
		/// Доступ к статусу пользователя.
		/// </summary>
		[Description("status")]
		Status,

		/// <summary>
		/// Доступ к заметкам пользователя.
		/// </summary>
		[Description("notes")]
		Notes,

		/// <summary>
		/// Доступ к расширенным методам работы с сообщениями (только для Standalone-приложений).
		/// </summary>
		[Description("messages")]
		Messages,

		/// <summary>
		/// Доступ к обычным и расширенным методам работы со стеной. Данное право доступа по умолчанию недоступно для сайтов 
		/// (игнорируется при попытке авторизации для приложений с типом «Веб-сайт» или по схеме Authorization Code Flow).
		/// </summary>
		[Description("wall")]
		Wall,

		/// <summary>
		/// Доступ к расширенным методам работы с рекламным API. Доступно для авторизации по схеме Implicit Flow или Authorization Code Flow.
		/// </summary>
		[Description("ads")]
		Ads,

		/// <summary>
		/// Доступ к API в любое время (при использовании этой опции параметр expires_in, 
		/// возвращаемый вместе с access_token, содержит 0 — токен бессрочный). Не применяется в Open API.
		/// </summary>
		[Description("offline")]
		Offline,

		/// <summary>
		/// Доступ к документам.
		/// </summary>
		[Description("docs")]
		Docs,

		/// <summary>
		/// Доступ к группам пользователя.
		/// </summary>
		[Description("groups")]
		Groups,

		/// <summary>
		/// Доступ к оповещениям об ответах пользователю.
		/// </summary>
		[Description("notifications")]
		Notifications,

		/// <summary>
		/// Доступ к статистике групп и приложений пользователя, администратором которых он является.
		/// </summary>
		[Description("stats")]
		Stats,

		/// <summary>
		/// Доступ к email пользователя.
		/// </summary>
		[Description("email")]
		Email,

		/// <summary>
		/// Доступ к товарам.
		/// </summary>
		[Description("market")]
		Market
	}
}