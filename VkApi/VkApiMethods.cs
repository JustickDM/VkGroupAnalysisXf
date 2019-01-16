using Newtonsoft.Json;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using VkApi.Classes;
using VkApi.Enums;
using VkApi.EventArgs;
using VkApi.Extensions;
using VkApi.JsonResult;

namespace VkApi
{
	/// <summary>
	/// Предоставляет класс для работы с методами API ВКонтакте.
	/// </summary>
	public class VkApiMethods
	{
		#region События

		public event Action<object, UserUpdatedEventArgs> GroupsGetMembersUpdated;
		public event Action<object, UserUpdatedEventArgs> FriendsGetUpdated;
		public event Action<object, UserUpdatedEventArgs> UsersGetUpdated;

		protected virtual void OnGroupsGetMembersUpdated(UserUpdatedEventArgs args)
		{
			GroupsGetMembersUpdated?.Invoke(this, args);
		}

		protected virtual void OnFriendsGetUpdated(UserUpdatedEventArgs args)
		{
			FriendsGetUpdated?.Invoke(this, args);
		}

		protected virtual void OnUsersGetUpdated(UserUpdatedEventArgs args)
		{
			UsersGetUpdated?.Invoke(this, args);
		}

		#endregion

		#region Публичные методы, обрабатывающие один запрос к серверу Вконтакте.

		/// <summary>
		/// Возвращает информацию об участниках сообщества.
		/// </summary>
		public async Task<RootObject<List<UserJson>>> GroupsGetMembersAsync(string token, string groupId, SortType sortType = SortType.TimeDesc, int count = int.MaxValue, int offset = 0, RequestFields fields = null)
		{
			int? countTotalDownloadUsers = null;
			var result = new RootObject<List<UserJson>>() { Response = new List<UserJson>() };
			const int MaxCount = 1000;

			while (true)
			{
				var response = await GroupsGetMembersPrivateAsync(token, groupId, sortType, Math.Min(count, MaxCount), offset, fields);

				if (response.IsSuccess)
				{
					result.Response.AddRange(response.Response.Items);

					countTotalDownloadUsers = countTotalDownloadUsers ?? Math.Min(count, response.Response.Count);

					OnGroupsGetMembersUpdated(new UserUpdatedEventArgs
					{
						CountTotalUsers = countTotalDownloadUsers.Value,
						CountDownloadedUsers = result.Response.Count,
						Users = response.Response.Items
					});

					if (response.Response.Items.Count < MaxCount)
						break;

					count -= MaxCount;
					offset += MaxCount;
				}
				else
				{
					result.Error = response.Error;
					break;
				}
			}

			return result;
		}

		/// <summary>
		/// Возвращает информацию о друзьях пользователя.
		/// </summary>
		public async Task<RootObject<List<UserJson>>> FriendsGetAsync(string token, int userId, int count = int.MaxValue, int offset = 0, RequestFields fields = null)
		{
			int? countTotalDownloadUsers = null;
			var result = new RootObject<List<UserJson>>() { Response = new List<UserJson>() };
			const int MaxCount = 5000;

			while (true)
			{
				var response = await FriendsGetPrivateAsync(token, userId, Math.Min(count, MaxCount), offset, fields);

				if (response.IsSuccess)
				{
					result.Response.AddRange(response.Response.Items);

					countTotalDownloadUsers = countTotalDownloadUsers ?? Math.Min(count, response.Response.Count);

					OnFriendsGetUpdated(new UserUpdatedEventArgs
					{
						CountTotalUsers = countTotalDownloadUsers.Value,
						CountDownloadedUsers = result.Response.Count,
						Users = response.Response.Items
					});

					if (response.Response.Items.Count < MaxCount)
						break;

					count -= MaxCount;
					offset += MaxCount;
				}
				else
				{
					result.Error = response.Error;
					break;
				}
			}

			return result;
		}

		/// <summary>
		/// Возвращает информацию о пользователях.
		/// </summary>
		public async Task<RootObject<List<UserJson>>> UsersGetAsync(string token, List<int> userIds = null, NameCaseType nameCaseType = NameCaseType.Nominative, RequestFields fields = null)
		{
			var result = new RootObject<List<UserJson>>() { Response = new List<UserJson>() };
			var usersCount = userIds?.Count ?? 1;
			const int MaxCount = 900;

			for (var i = 0; i < usersCount; i += MaxCount)
			{
				var response = await UsersGetPrivateAsync(token, userIds?.Skip(i).Take(MaxCount).ToList(), nameCaseType, fields);

				if (response.IsSuccess)
				{
					result.Response.AddRange(response.Response);

					OnUsersGetUpdated(new UserUpdatedEventArgs
					{
						CountTotalUsers = usersCount,
						CountDownloadedUsers = result.Response.Count,
						Users = response.Response
					});
				}
				else
				{
					result.Error = response.Error;
					break;
				}
			}

			return result;
		}

		public async Task<RootObject<List<UserJson>>> SearchUsersAsync(string token, string q, string bD, string bM, string bY, string aF, string aT, string ht, NameCaseType nameCaseType = NameCaseType.Nominative)
		{
			var content = await new HttpRequest()
				.AddParam(ParamType.AccessToken, token)
				.AddParam(ParamType.NameCase, nameCaseType.GetDescription())
				.AddParam(ParamType.Q, q)
				.AddParam(ParamType.BirthDay, bD)
				.AddParam(ParamType.BirthMonth, bM)
				.AddParam(ParamType.BirthYear, bY)
				.AddParam(ParamType.AgeFrom, aF)
				.AddParam(ParamType.AgeTo, aT)
				.AddParam(ParamType.Hometown, ht)
				.PostAsync(MethodType.UsersSearch);

			var rootObject = JsonConvert.DeserializeObject<RootObject<ItemsJson<UserJson>>>(content);

			return rootObject.IsSuccess
				? new RootObject<List<UserJson>>() { Response = rootObject.Response.Items }
				: new RootObject<List<UserJson>>() { Error = rootObject.Error };
		}

		#endregion

		#region Приватные методы, обрабатывающие один запрос к серверу Вконтакте.

		private async Task<RootObject<ItemsJson<UserJson>>> GroupsGetMembersPrivateAsync(string token, string groupId, SortType sortType = SortType.TimeDesc, int count = 1000, int offset = 0, RequestFields fields = null)
		{
			var content = await new HttpRequest()
				.AddParam(ParamType.AccessToken, token)
				.AddParam(ParamType.GroupId, groupId)
				.AddParam(ParamType.Sort, sortType.GetDescription())
				.AddParam(ParamType.Count, count)
				.AddParam(ParamType.Offset, offset)
				.AddParam(ParamType.Fields, fields ?? new RequestFields())
				.PostAsync(MethodType.GroupsGetMembers);

			var rootObject = JsonConvert.DeserializeObject<RootObject<ItemsJson<UserJson>>>(content);
			return rootObject;
		}

		private async Task<RootObject<ItemsJson<UserJson>>> FriendsGetPrivateAsync(string token, int userId, int count = 5000, int offset = 0, RequestFields fields = null)
		{
			var content = await new HttpRequest()
				.AddParam(ParamType.AccessToken, token)
				.AddParam(ParamType.UserId, userId)
				.AddParam(ParamType.Count, count)
				.AddParam(ParamType.Offset, offset)
				.AddParam(ParamType.Fields, fields ?? new RequestFields())
				.PostAsync(MethodType.FriendsGet);

			var rootObject = JsonConvert.DeserializeObject<RootObject<ItemsJson<UserJson>>>(content);
			return rootObject;
		}

		private async Task<RootObject<List<UserJson>>> UsersGetPrivateAsync(string token, List<int> userIds = null, NameCaseType nameCaseType = NameCaseType.Nominative, RequestFields fields = null)
		{
			var content = await new HttpRequest()
				.AddParam(ParamType.AccessToken, token)
				.AddParam(ParamType.UserIds, userIds != null ? string.Join(",", userIds) : null)
				.AddParam(ParamType.NameCase, nameCaseType.GetDescription())
				.AddParam(ParamType.Fields, fields ?? new RequestFields())
				.PostAsync(MethodType.UsersGet);

			var rootObject = JsonConvert.DeserializeObject<RootObject<List<UserJson>>>(content);
			return rootObject;
		}

		#endregion
	}
}