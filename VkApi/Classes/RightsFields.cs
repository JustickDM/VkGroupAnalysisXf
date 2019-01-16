using System;
using System.Collections.Generic;

using VkApi.Enums;
using VkApi.Extensions;

namespace VkApi.Classes
{
	/// <summary>
	/// Представляет класс для передачи прав доступа приложения.
	/// </summary>
	public class RightsFields
	{
		/// <summary>
		/// Словарь прав доступа приложения.
		/// </summary>
		private Dictionary<AccessRightsForUserType, string> rightsFields = new Dictionary<AccessRightsForUserType, string>()
		{
			[AccessRightsForUserType.Groups] = AccessRightsForUserType.Groups.GetDescription(),
			[AccessRightsForUserType.Offline] = AccessRightsForUserType.Offline.GetDescription()
		};

		/// <summary>
		/// Проверяет, установлено ли право доступа типа <paramref name="AccessRightsForUserType"/>.
		/// </summary>
		/// <param name="AccessRightsForUserType">Тип права доступа.</param>
		public bool IsSetRightsField(AccessRightsForUserType AccessRightsForUserType)
		{
			return rightsFields.ContainsKey(AccessRightsForUserType);
		}

		/// <summary>
		/// Добавляет право доступа указанного типа <paramref name="AccessRightsForUserType"/>.
		/// </summary>
		/// <param name="AccessRightsForUserType">Тип права доступа.</param>
		public RightsFields Set(AccessRightsForUserType AccessRightsForUserType)
		{
			rightsFields[AccessRightsForUserType] = AccessRightsForUserType.GetDescription();
			return this;
		}

		/// <summary>
		/// Удаляет право доступа указанного типа <paramref name="AccessRightsForUserType"/>.
		/// </summary>
		/// <param name="AccessRightsForUserType">Тип права доступа.</param>
		public RightsFields Remove(AccessRightsForUserType AccessRightsForUserType)
		{
			rightsFields.Remove(AccessRightsForUserType);
			return this;
		}

		/// <summary>
		/// Возвращает строку с правами доступа приложения в нужном формате.
		/// </summary>
		public override string ToString()
		{
			return String.Join(",", rightsFields.Values);
		}
	}
}