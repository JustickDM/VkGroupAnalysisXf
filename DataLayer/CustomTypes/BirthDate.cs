using System;

namespace DataLayer.CustomTypes
{
	/// <summary>
	/// Представляет дату рождения пользователя ВКонтакте.
	/// </summary>
	public class BirthDate
	{
		private int day;
		private int month;
		private int? year;

		private string[] monthNames = new[] { "января", "февраля", "марта", "апреля", "мая", "июня", "июля", "августа", "сентября", "октября", "ноября", "декабря" };

		public int Day
		{
			get => day;
			set => day = value < 1 || value > 31 ? throw new ArgumentException("День должен принимать значение в диапазоне от 1 до 31.") : value;
		}

		public int Month
		{
			get => month;
			set => month = value < 1 || value > 12 ? throw new ArgumentException("Месяц должен принимать значение в диапазоне от 1 до 12.") : value;
		}

		public int? Year
		{
			get => year;
			set => year = value < 1 || value > 9999 ? throw new ArgumentException("Год должен принимать значение в диапазоне от 1 до 9999.") : value;
		}

		public BirthDate(int day, int month, int? year = null)
		{
			Day = day;
			Month = month;
			Year = year;
		}

		/// <summary>
		/// Возвращает строковое представление даты рождения, учитывая указан ли год рождения.
		/// </summary>
		public override string ToString()
		{
			return Year.HasValue ? $"{Day} {monthNames[Month - 1]} {year} г." : $"{Day} {monthNames[Month - 1]}";
		}
	}
}