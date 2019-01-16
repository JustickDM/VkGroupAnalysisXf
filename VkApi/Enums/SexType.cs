using System.ComponentModel;

namespace VkApi.Enums
{
	/// <summary>
	/// Тип пола.
	/// </summary>
	public enum SexType
	{
		/// <summary>
		/// Пол не указан.
		/// </summary>
		[Description("Пол не указан")]
		Unknown,

		/// <summary>
		/// Женский.
		/// </summary>
		[Description("Женский")]
		Female,

		/// <summary>
		/// Мужской.
		/// </summary>
		[Description("Мужской")]
		Male
	}
}