using System.ComponentModel;

namespace VkApi.Enums
{
	/// <summary>
	/// Типы падежей.
	/// </summary>
	public enum NameCaseType
	{
		/// <summary>
		/// Именительный.
		/// </summary>
		[Description("nom")]
		Nominative,

		/// <summary>
		/// Родительный.
		/// </summary>
		[Description("gen")]
		Genitive,

		/// <summary>
		/// Дательный.
		/// </summary>
		[Description("dat")]
		Dative,

		/// <summary>
		/// Винительный.
		/// </summary>
		[Description("acc")]
		Accusative,

		/// <summary>
		/// Творительный.
		/// </summary>
		[Description("ins")]
		Instrumental,

		/// <summary>
		/// Предложный.
		/// </summary>
		[Description("abl")]
		Prepositional
	}
}
