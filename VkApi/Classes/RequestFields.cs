using System;
using System.Collections.Generic;

using VkApi.Enums;
using VkApi.Extensions;

namespace VkApi.Classes
{
	/// <summary>
	/// Представляет класс для передачи дополнительных полей в HTTP-запрос, которые необходимо вернуть.
	/// </summary>
	public class RequestFields
	{
		/// <summary>
		/// Словарь дополнительных полей, используемых при отправке в HTTP-запросе.
		/// </summary>
		private Dictionary<RequestFieldType, string> requestFields = new Dictionary<RequestFieldType, string>()
		{
			[RequestFieldType.FirstName] = RequestFieldType.FirstName.GetDescription(),
			[RequestFieldType.LastName] = RequestFieldType.LastName.GetDescription(),
			[RequestFieldType.Photo100] = RequestFieldType.Photo100.GetDescription()
		};

		/// <summary>
		/// Проверяет, установлено ли дополнительное поле типа <paramref name="requestFieldType"/> в HTTP-запросе.
		/// </summary>
		/// <param name="requestFieldType">Тип дополнительного поля HTTP-запроса.</param>
		public bool IsSetRequestField(RequestFieldType requestFieldType)
		{
			return requestFields.ContainsKey(requestFieldType);
		}

		/// <summary>
		/// Добавляет дополнительное поле указанного типа <paramref name="requestFieldType"/> в HTTP-запрос.
		/// </summary>
		/// <param name="requestFieldType">Тип дополнительного поля HTTP-запроса.</param>
		public RequestFields Set(RequestFieldType requestFieldType)
		{
			requestFields[requestFieldType] = requestFieldType.GetDescription();
			return this;
		}

		/// <summary>
		/// Удаляет дополнительное поле указанного типа <paramref name="requestFieldType"/> из HTTP-запроса.
		/// </summary>
		/// <param name="requestFieldType">Тип дополнительного поля HTTP-запроса.</param>
		public RequestFields Remove(RequestFieldType requestFieldType)
		{
			requestFields.Remove(requestFieldType);
			return this;
		}

		/// <summary>
		/// Возвращает строку с дополнительными параметрами в нужном формате для HTTP-запроса API ВКонтакте.
		/// </summary>
		public override string ToString()
		{
			return String.Join(",", requestFields.Values);
		}
	}
}