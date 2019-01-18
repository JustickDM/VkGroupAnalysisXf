using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Text;

namespace VkGroupAnalysisXf
{
    public class ObservableCollectionFast<T> : ObservableCollection<T>
	{
		public ObservableCollectionFast() : base() { }

		public ObservableCollectionFast(IEnumerable<T> collection) : base(collection) { }

		public ObservableCollectionFast(List<T> list) : base(list) { }

		public void AddRange(IEnumerable<T> range)
		{
			foreach (var item in range)
			{
				Items.Add(item);
			}

			OnPropertyChanged(new PropertyChangedEventArgs("Count"));
			OnPropertyChanged(new PropertyChangedEventArgs("Item[]"));
			OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
		}
	}
}
