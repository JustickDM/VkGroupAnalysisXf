using DataLayer.CustomTypes;
using DataLayer.Enums;
using DataLayer.Models;

using vk = VkApi.JsonResult;

//using rep = Repository.Entities;

namespace DataLayer.Converters
{
	/// <summary>
	/// Преобразует значения различных типов данных к типу User.
	/// </summary>
	public class UserConverter
	{
		/// <summary>
		/// Преобразует объект типа UserJson к типу User.
		/// </summary>
		/// <param name="userJson">Объект, который требуется преобразовать.</param>
		public static User Convert(vk.UserJson userJson)
		{
			User user = new User
			{
				Id = userJson.Id,
				FirstName = userJson.FirstName,
				LastName = userJson.LastName,
				MiddleName = userJson.MiddleName,
				SexType = userJson.SexType,
				City = userJson.City,
				Country = userJson.Country,
				Photo50 = userJson.Photo50,
				Photo100 = userJson.Photo100,
				PhotoOrig200 = userJson.PhotoOrig200,
				Photo200 = userJson.Photo200,
				PhotoOrig400 = userJson.PhotoOrig400,
				PhotoMax = userJson.PhotoMax,
				PhotoMaxOrig = userJson.PhotoMaxOrig,
				Deactivated = DeactivatedConvert(userJson.Deactivated),
				Universities = userJson.Universities,
				BirthDate = BirthDateConvert(userJson.BirthDate)
			};

			return user;
		}

		///// <summary>
		///// Преобразует объект типа UserDataLayer к типу UserRepository.
		///// </summary>
		///// <param name="userJson">Объект, который требуется преобразовать.</param>
		//public static rep.User Convert(User user)
		//{
		//	rep.User userRep = new rep.User
		//	{
		//		Id = user.Id,
		//		FirstName = user.FirstName,
		//		LastName = user.LastName,
		//		MiddleName = user.MiddleName,
		//		SexType = user.SexType.ToString(),
		//		City = user.City != null ? user.City.Title : null,
		//		Country = user.Country != null ? user.Country.Title : null,
		//		BirthDate = user.BirthDate != null ? user.BirthDate.ToString() : null
		//	};

		//	return userRep;
		//}

		/// <summary>
		/// Преобразует строковое значение <paramref name="value"/> в тип перечисления DeactivatedType.
		/// </summary>
		/// <param name="value">Значение, которое необходимо преобразовать.</param>
		private static DeactivatedType DeactivatedConvert(string value)
		{
			DeactivatedType type = DeactivatedType.Actived;

			if (value != null)
			{
				if (value == "deleted") type = DeactivatedType.Deleted;
				if (value == "banned") type = DeactivatedType.Banned;
			}

			return type;
		}

		/// <summary>
		/// Преобразует строковое значение даты рождения <paramref name="date"/> в тип BirthDate.
		/// </summary>
		/// <param name="value">Значение, которое необходимо преобразовать.</param>
		private static BirthDate BirthDateConvert(string date)
		{
			if (date == null) return null;

			string[] parts = date.Split('.');

			int day = int.Parse(parts[0]);
			int month = int.Parse(parts[1]);
			int? year = parts.Length == 3 ? (int?)int.Parse(parts[2]) : null;

			return new BirthDate(day, month, year);
		}
	}
}