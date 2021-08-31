namespace NGCS_Test_Task.Services.Search
{
	/// <summary>
	/// Интерфейс поисковой службы
	/// </summary>
	public interface ISearchService
	{
		/// <summary>
		/// Метод запроса Json из ITunes
		/// </summary>
		/// <param name="artistName">Название артиста</param>
		/// <returns>Json с альбомами артиста</returns>
		string SearchAlbumsJson(string artistName);
	}
}
