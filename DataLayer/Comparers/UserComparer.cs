using DataLayer.Models;

using System.Collections.Generic;

namespace DataLayer.Comparers
{
	/// <summary>
	/// Представляет операции сравнения пользователей.
	/// </summary>
	public class UserComparer : IEqualityComparer<User>
	{
		/// <summary>
		/// Позволяет определить, равны ли два пользователя.
		/// </summary>
		/// <param name="x">Пользователь, сравниваемый с параметром <paramref name="y"/>.</param>
		/// <param name="y">Пользователь, сравниваемый с параметром <paramref name="x"/>.</param>
		/// <returns>Значение true, если параметры x и y указывают на один и тот же объект 
		/// или если параметры x и y равны; в противном случае — значение false.</returns>
		public bool Equals(User x, User y)
		{
			return ReferenceEquals(x, y) || x != null && y != null && x.Id.Equals(y.Id);
		}

		/// <summary>
		/// Возвращает хэш-код указанного пользователя.
		/// </summary>
		/// <param name="userJson">Пользователь, хэш-код которого необходимо вычислить.</param>
		/// <returns>32-разрядный хэш-код, вычисленный на основе свойства Id пользователя.</returns>
		public int GetHashCode(User userJson)
		{
			const int p = 17;
			return (userJson.Id * p) % 1000;
		}
	}
}