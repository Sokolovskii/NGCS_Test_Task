using NGCS_Test_Task.Models;

namespace NGCS_Test_Task.Services.Print
{
	/// <summary>
	/// Интерфейс вывода информации об альбомах
	/// </summary>
	public interface IPrintService
	{
		/// <summary>
		/// Печатает информацию об альбомах
		/// </summary>
		/// <param name="albumCollection">Коллекция альбомов с указанием их численности</param>
		void PrintInfoAboutAlbums(AlbumCollection albumCollection);
	}
}
