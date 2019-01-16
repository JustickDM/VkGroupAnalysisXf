using System.ComponentModel;

namespace VkApi.Enums
{
	/// <summary>
	/// Тип сортировки.
	/// </summary>
	public enum SortType
	{
		/// <summary>
		/// В порядке возрастания id.
		/// </summary>
		[Description("id_asc")]
		IdAsc,

		/// <summary>
		/// В порядке убывания id.
		/// </summary>
		[Description("id_desc")]
		IdDesc,

		/// <summary>
		/// В хронологическом порядке.
		/// </summary>
		[Description("time_asc")]
		TimeAsc,

		/// <summary>
		/// В антихронологическом порядке.
		/// </summary>
		[Description("time_desc")]
		TimeDesc
	}
}
