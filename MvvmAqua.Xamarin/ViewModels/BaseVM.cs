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

		protected virtual void NavigationServiceInitialization() { }
	}
}
