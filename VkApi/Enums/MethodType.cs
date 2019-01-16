using System.ComponentModel;

namespace VkApi.Enums
{
	/// <summary>
	/// Тип метода API ВКонтакте.
	/// </summary>
	internal enum MethodType
	{
		/// <summary>
		/// Возвращает список участников сообщества.
		/// </summary>
		[Description("groups.getMembers")]
		GroupsGetMembers,

		/// <summary>
		/// Возвращает информацию о друзьях пользователя.
		/// </summary>
		[Description("friends.get")]
		FriendsGet,

		/// <summary>
		/// Возвращает расширенную информацию о пользователях.
		/// </summary>
		[Description("users.get")]
		UsersGet,

		/// <summary>
		/// Возвращает список пользователей в соответствии с заданным критерием поиска.
		/// </summary>
		[Description("users.search")]
		UsersSearch
	}
}
