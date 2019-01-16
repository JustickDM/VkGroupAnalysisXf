using DataLayer.Comparers;
using DataLayer.Converters;
using DataLayer.Models;

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using VkApi;
using VkApi.Classes;

namespace DataLayer.Classes
{
	public class Search
	{
		/// <summary>
		/// Возвращает список всех друзей консультантов.
		/// </summary>
		/// <param name="Token">Токен авторизованного пользователя. </param>
		/// <param name="Fields">Поля в HTTP-запросе, которые необходимо вернуть. </param>
		/// <param name="ListOfConsultant">Список всех консультантов. </param>
		private async Task<List<Consultant>> GetAllFriendsOfConsultant(string Token, RequestFields Fields, List<Consultant> ListOfConsultant)
		{
			var VkApi = new VkApiMethods();
			return await Task.Run(() =>
			{
				foreach (var Consultant in ListOfConsultant)
				{
					var Friends = VkApi.FriendsGetAsync(Token, int.Parse(Consultant.Id), fields: Fields).Result;
					Consultant.Friends.AddRange(Friends.Response.ConvertAll(In => UserConverter.Convert(In)));
				}
				return ListOfConsultant;
			});
		}

		/// <summary>
		/// Возвращает список общих пользователей между друзьями консультантов и пользователями группы.
		/// </summary>
		/// <param name="Users">Список пользователей группы. </param>
		/// <param name="ListOfConsultant">Список всех консультантов. </param>
		private async Task<List<List<User>>> GetIntersectFriendsWithGroup(List<User> Users, List<Consultant> ListOfConsultant)
		{
			var Intersect = new List<List<User>>();
			return await Task.Run(() =>
			{
				for (var i = 0; i < ListOfConsultant.Count; i++)
					Intersect.Add(Users.Intersect(ListOfConsultant[i].Friends, new UserComparer()).ToList());
				return Intersect;
			});
		}

		/// <summary>
		/// Возвращает список общих друзей всех консультантов.
		/// </summary>
		/// <param name="Users">Список общих пользователей между друзьями консультантов и пользователями группы. </param>
		private async Task<List<User>> GetListOfMutualFriends(List<List<User>> Users)
		{
			var Mutual = new List<User>();
			return await Task.Run(() =>
			{
				for (var i = 0; i < Users.Count; i++)
					for (var j = i + 1; j < Users.Count; j++)
						Mutual.AddRange(Users[i].Intersect(Users[j]));
				return Mutual.Distinct().ToList();
			});
		}

		/// <summary>
		/// Возвращает список пользователей, распределенных по факультетам.
		/// </summary>
		/// <param name="Token">Токен авторизованного пользователя. </param>
		/// <param name="Fields">Поля в HTTP-запросе, которые необходимо вернуть. </param>
		/// <param name="Users">Список пользователей группы. </param>
		/// <param name="ListOfConsultant">Список всех консультантов. </param>
		public async Task<List<User>> MainMethod(string Token, RequestFields Fields, List<User> Users, List<Consultant> ListOfConsultant)
		{
			//Заполнить список друзей каждого консультанта
			var ConsultantFriends = await GetAllFriendsOfConsultant(Token, Fields, ListOfConsultant);
			//Найти пользователей группы, которые пересекаются с консультантами 
			//(1 юзер : 1 консультант(факультет))
			var Intersect = await GetIntersectFriendsWithGroup(Users, ListOfConsultant);
			//Найти пользователей группы, которые пересекаются с несколькими консультантами 
			//(1 юзер : N консультантов(факультетов))
			var Mutual = await GetListOfMutualFriends(Intersect);
			return await Task.Run(() =>
			{
				for (var i = 0; i < Intersect.Count; i++)
				{
					for (var j = 0; j < Intersect[i].Count; j++)
					{
						//Получаем пользоваля из списка 1:1
						var User = Users.FirstOrDefault(x => x.Id == Intersect[i][j].Id);
						//Находим индекс полученного пользователя в общем списке пользователей группы
						var UserIndex = Users.IndexOf(User);
						//Ищем пользовалеля в списке 1:N
						var UserFromMutual = Mutual.FirstOrDefault(x => x.Id == User.Id);
						//Создаем список факультетов для пользователя
						Users[UserIndex].Faculties = new List<string>();
						if (UserFromMutual == null) //Если пользователь у 1 консультанта
						{
							Users[UserIndex].Faculties.Add(ListOfConsultant[i].Faculty);
						}
						else //Иначе пользователь у N консультантов, находим у каких и добавляем их факультеты в список факультетов пользователя
						{
							for (var k = 0; k < Intersect.Count; k++)
							{
								if (Intersect[k].Contains(UserFromMutual))
								{
									Users[UserIndex].Faculties.Add(ListOfConsultant[k].Faculty);
								}
							}
						}
					}
				}
				return Users;
			});
		}
	}
}
