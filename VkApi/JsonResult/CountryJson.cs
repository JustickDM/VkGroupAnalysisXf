using Newtonsoft.Json;

namespace VkApi.JsonResult
{
	/// <summary>
	/// Возвращаемая информация о стране.
	/// </summary>
	public class CountryJson
	{
		/// <summary>
		/// Идентификатор страны.
		/// </summary>
		[JsonProperty("id")]
		public int Id { get; set; }

		/// <summary>
		/// Наименование страны.
		/// </summary>
		[JsonProperty("title")]
		public string Title { get; set; }

		public override string ToString() => Title;
	}
}