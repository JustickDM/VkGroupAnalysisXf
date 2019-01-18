using System.Collections.ObjectModel;
using System.Linq;

using MvvmAqua.Xamarin.ViewModels;
using DataLayer.Converters;
using DataLayer.Models;
using VkApi;
using VkApi.Classes;
using VkApi.Enums;

namespace VkGroupAnalysisXf.ViewModels
{
	public class MainViewModel: BaseVM
	{
		private const string GroupId = "56222995";

		private const SortType SortTypeForUsersFaculty = SortType.TimeDesc;
		private const SortType SortTypeForUsersInGroup = SortType.IdAsc;

		private const int Offset = 0;
		private const int Count = 9999;

		private RequestFields RequestFields { get; } = new RequestFields()
			.Set(RequestFieldType.City)
			.Set(RequestFieldType.Country)
			.Set(RequestFieldType.Photo50)
			.Set(RequestFieldType.Deactivated)
			.Set(RequestFieldType.BirthDate);

		private string Token { get; set; } = "fbaa5316f045c40ad45578a9825ac70f2b01f919d52504aa8392d9091139c76dc59b809c4757a536773ae";

		private ObservableCollectionFast<User> users = new ObservableCollectionFast<User>();
		public ObservableCollectionFast<User> Users
		{
			get => users;
			set => SetProperty(ref users, value);
		}

		public MainViewModel()
		{
			UsersInGroupAsync();
		}

		/// <summary>
		/// Список пользователей группы.
		/// </summary>
		/// <returns></returns>
		private async void UsersInGroupAsync()
		{
			IsBusy = true;

			var vkApi = new VkApiMethods();

			Users.Clear();

			vkApi.GroupsGetMembersUpdated += (sender, args) =>
			{
				Users.AddRange(args.Users.Select(u => UserConverter.Convert(u)));
			};

			await vkApi.GroupsGetMembersAsync(Token, GroupId, SortTypeForUsersInGroup, fields: RequestFields);

			IsBusy = false;
		}
	}
}
