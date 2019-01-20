﻿using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace VkGroupAnalysisXf.ViewModels.Base
{
	public abstract class ExtendedBindableObject : INotifyPropertyChanged
	{
		protected void SetProperty<T>(ref T property, T value, [CallerMemberName]string propertyName = null)
		{
			if (!EqualityComparer<T>.Default.Equals(property, value))
			{
				property = value;
				OnPropertyChanged(propertyName);
			}
		}

		protected void SetProperty<T>(ref T property, T value, Action onValueChanged, [CallerMemberName]string propertyName = null)
		{
			if (!EqualityComparer<T>.Default.Equals(property, value))
			{
				property = value;
				onValueChanged?.Invoke();
				OnPropertyChanged(propertyName);
			}
		}


		public event PropertyChangedEventHandler PropertyChanged;

		protected void OnPropertyChanged([CallerMemberName]string propertyName = null)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}