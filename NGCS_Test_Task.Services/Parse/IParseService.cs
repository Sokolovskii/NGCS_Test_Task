using NGCS_Test_Task.Models;

namespace NGCS_Test_Task.Services.Parse
{
	/// <summary>
	/// Интерфейс службы парсинга Json, полученного от ITunes
	/// </summary>
	public interface IParseService
	{
		/// <summary>
		/// Парсинг Json, полученного от ITunes
		/// </summary>
		/// <param name="json">объект Json</param>
		/// <returns>Объект распаршенного Json</returns>
		AlbumCollection ParseJson(string json);
	}
}
