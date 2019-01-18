using System;
using System.Collections.Generic;
using System.Text;

using MvvmAqua.Xamarin.Navigation;

namespace MvvmAqua.Xamarin.ViewModels
{
	public abstract class BaseVM : ExtendedBindableObject
	{
		private INavigationService navigationService;
		protected internal INavigationService NavigationService
		{
			get => navigationService;
			internal set
			{
				navigationService = value;
				NavigationServiceInitialization();
			}
		}

		/// <summary>
		/// Индикация, что выполняется продолжительная процедура и "форма занята"
		/// Отображается ActivityIndicator, элементы ввода недоступны для редактирования
		/// </summary>
		private bool isBusy;
		public bool IsBusy
		{
			get => isBusy;
			set => SetProperty(ref isBusy, value);
		}

		protected virtual void NavigationServiceInitialization() { }
	}
}
