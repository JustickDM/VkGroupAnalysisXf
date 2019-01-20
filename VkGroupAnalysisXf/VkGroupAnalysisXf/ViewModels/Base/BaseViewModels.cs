using Xamarin.Forms;

namespace VkGroupAnalysisXf.ViewModels.Base
{
	public abstract class BaseVM : ExtendedBindableObject
	{
		protected INavigation Navigation { get; set; }
			   
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
	}
}