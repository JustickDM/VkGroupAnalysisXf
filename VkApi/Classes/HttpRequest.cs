using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

using VkApi.Enums;
using VkApi.Extensions;

namespace VkApi.Classes
{
	/// <summary>
	/// Предоставляет класс для построения HTTP-запросов к API ВКонтакте.
	/// </summary>
	internal class HttpRequest
	{
		/// <summary>
		/// Версия API ВКонтакте, используемая по умолчанию.
		/// </summary>
		public const string VersionVkApi = "5.9";

		/// <summary>
		/// Базовый адрес интернет-ресурса, используемого при отправке HTTP-запросов.
		/// По умолчанию https://api.vk.com/method - адрес API-сервиса ВКонтакте.
		/// </summary>
		public Uri BaseAddress { get; set; } = new Uri("https://api.vk.com/method");

		/// <summary>
		/// Словарь параметров, используемых при отправке HTTP-запросов.
		/// </summary>
		private Dictionary<ParamType, string> parameters = new Dictionary<ParamType, string>()
		{
			[ParamType.Version] = VersionVkApi
		};


		/// <summary>
		/// Инициализирует новый экземпляр класса HttpRequest с базовым адресом интернет-ресурса https://api.vk.com/method.
		/// </summary>
		public HttpRequest() { }

		/// <summary>
		/// Инициализирует новый экземпляр класса HttpRequest с указанным базовым адресом интернет-ресурса <paramref name="baseAddress"/>.
		/// </summary>
		/// <param name="baseAddress">Базовый адрес интернет-ресурса, используемого при отправке HTTP-запросов.</param>
		public HttpRequest(Uri baseAddress)
		{
			BaseAddress = baseAddress;
		}


		/// <summary>
		/// Отправка асинхронного HTTP-запроса POST по указаннному методу API ВКонтакте.
		/// </summary>
		/// <param name="methodType">Тип метода API ВКонтакте.</param>
		/// <returns>Ответ от метода в формате JSON</returns>
		public Task<string> PostAsync(MethodType methodType)
		{
			return Task.Run(() =>
			{
				var request = (HttpWebRequest)WebRequest.Create(GetMethodAddress(methodType));

				var bytes = Encoding.UTF8.GetBytes(GetParametersAddress());

				request.Method = "POST";
				request.ContentType = "application/x-www-form-urlencoded";
				request.ContentLength = bytes.Length;

				using (var newStream = request.GetRequestStream())
				{
					newStream.Write(bytes, 0, bytes.Length);
				}

				var response = request.GetResponse();

				return response != null
					? new StreamReader(response.GetResponseStream(), Encoding.UTF8).ReadToEnd()
					: string.Empty;
			});
		}

		/// <summary>
		/// Возвращает значение параметра HTTP-запроса указанного типа <paramref name="paramType"/>.
		/// </summary>
		/// <param name="paramType">Тип параметра HTTP-запроса.</param>
		/// <returns>Значение параметра HTTP-запроса.</returns>
		public string GetParam(ParamType paramType)
		{
			return parameters[paramType];
		}

		/// <summary>
		/// Добавляет параметр указанного типа <paramref name="paramType"/> 
		/// с указанным значением <paramref name="paramValue"/> к HTTP-запросу.
		/// </summary>
		/// <param name="paramType">Тип параметра HTTP-запроса.</param>
		/// <param name="paramValue">Значение параметра HTTP-запроса.</param>
		public HttpRequest AddParam<T>(ParamType paramType, T paramValue)
		{
			if (paramValue != null)
			{
				parameters[paramType] = paramValue.ToString();
			}
			return this;
		}

		/// <summary>
		/// Удаляет параметр указанного типа <paramref name="paramType"/> из HTTP-запроса.
		/// </summary>
		/// <param name="paramType">Тип параметра HTTP-запроса.</param>
		public HttpRequest RemoveParam(ParamType paramType)
		{
			parameters.Remove(paramType);
			return this;
		}

		/// <summary>
		/// Возвращает адрес HTTP-запроса к методу API ВКонтакте,
		/// используя базовый адрес интернет-ресурса и указанное наименование метода.
		/// </summary>
		/// <param name="methodType">Тип метода API ВКонтакте.</param>
		/// <returns>Адрес HTTP-запроса к методу API ВКонтакте.</returns>
		public string GetMethodAddress(MethodType methodType)
		{
			return $"{BaseAddress}/{methodType.GetDescription()}";
		}

		/// <summary>
		/// Возвращает список параметров в запросе к методу API ВКонтакте.
		/// </summary>
		/// <returns>Список параметров в запросе к методу API ВКонтакте.</returns>
		public string GetParametersAddress()
		{
			return $"{String.Join("&", parameters.Select(pair => $"{pair.Key.GetDescription()}={pair.Value}"))}";
		}
	}
}