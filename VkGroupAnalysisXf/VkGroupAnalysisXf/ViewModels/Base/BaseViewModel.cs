namespace MobileSubscriber.ViewModels.Base
{
	public class BaseViewModel : ExtendedBindableObject
	{
		#region Свойства

		/// <summary>
		/// Индикация, что выполняется продолжительная процедура и "форма занята"
		/// Отображается ActivityIndicator, элементы ввода недоступны для редактирования
		/// </summary>
		private bool _busy = false;
		public bool IsBusy
		{
			get { return _busy; }
			set
			{
				if (_busy == value)
                {
                    return;
                }

                _busy = value;
				RaisePropertyChanged(() => IsBusy);
			}
		}

		#endregion

		public BaseViewModel()
		{
			
		}
	}
}
