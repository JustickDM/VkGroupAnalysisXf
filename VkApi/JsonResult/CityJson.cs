using Newtonsoft.Json;

namespace VkApi.JsonResult
{
	/// <summary>
	/// Возвращаемая информация о городе.
	/// </summary>
	public class CityJson
	{
		/// <summary>
		/// Идентификатор города.
		/// </summary>
		[JsonProperty("id")]
		public int Id { get; set; }

		/// <summary>
		/// Наименование города.
		/// </summary>
		[JsonProperty("title")]
		public string Title { get; set; }

		public override string ToString() => Title;
	}
}