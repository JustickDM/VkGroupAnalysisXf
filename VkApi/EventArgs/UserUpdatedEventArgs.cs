using System.Collections.Generic;

using VkApi.JsonResult;

namespace VkApi.EventArgs
{
	/// <summary>
	///  Содержит данные о возвращаемой информации пользователей Вконтакте.
	/// </summary>
	public class UserUpdatedEventArgs : System.EventArgs
	{
		/// <summary>
		/// Общее количество выгружаемых пользователей.
		/// </summary>
		public int CountTotalUsers { get; set; }

		/// <summary>
		/// Количество выгруженных пользователей.
		/// </summary>
		public int CountDownloadedUsers { get; set; }

		/// <summary>
		/// Информация о пользователях.
		/// </summary>
		public List<UserJson> Users { get; set; }

		public UserUpdatedEventArgs()
		{
			Users = new List<UserJson>();
		}
	}
}