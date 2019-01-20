using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VkGroupAnalysisXf.ViewModels;
using Xamarin.Forms;

namespace VkGroupAnalysisXf
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();

			BindingContext = new MainViewModel(Navigation);
		}
	}
}