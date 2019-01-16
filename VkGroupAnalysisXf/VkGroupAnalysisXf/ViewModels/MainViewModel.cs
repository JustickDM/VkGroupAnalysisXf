using DataLayer.Converters;
using DataLayer.Models;
using MobileSubscriber.ViewModels.Base;

using System.Collections.ObjectModel;
using VkApi;
using VkApi.Classes;
using VkApi.Enums;

namespace VkGroupAnalysisXf.ViewModels
{
	public class MainViewModel: BaseViewModel
    {
		private const string _groupId = "56222995";

		private const SortType _sortTypeForUsersFaculty = SortType.TimeDesc;
		private const SortType _sortTypeForUsersInGroup = SortType.IdAsc;

		private const int _offset = 0;
		private const int _count = 9999;

		private RequestFields _requestFields = new RequestFields()
			.Set(RequestFieldType.City)
			.Set(RequestFieldType.Country)
			.Set(RequestFieldType.Photo50)
			.Set(RequestFieldType.Deactivated)
			.Set(RequestFieldType.BirthDate);

		private string _token { get; set; } = "fbaa5316f045c40ad45578a9825ac70f2b01f919d52504aa8392d9091139c76dc59b809c4757a536773ae";

		private ObservableCollection<User> _users;
		public ObservableCollection<User> Users
		{
			get => _users;
			set { _users = value; RaisePropertyChanged(() => Users); }
		}

		public MainViewModel()
		{
			UsersInGroup();
		}

		/// <summary>
		/// Список пользователей группы.
		/// </summary>
		/// <returns></returns>
		private async void UsersInGroup()
		{
			IsBusy = true;

			var vkApi = new VkApiMethods();

			Users = new ObservableCollection<User>();

			vkApi.GroupsGetMembersUpdated += (sender, args) =>
			{
				args.Users.ForEach(u => Users.Add(UserConverter.Convert(u)));
			};

			await vkApi.GroupsGetMembersAsync(_token, _groupId, _sortTypeForUsersInGroup, fields: _requestFields);

			IsBusy = false;
		}
	}
}
