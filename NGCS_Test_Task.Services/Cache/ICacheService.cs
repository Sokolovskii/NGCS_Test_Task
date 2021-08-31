using NGCS_Test_Task.Models;

namespace NGCS_Test_Task.Services.Cache
{
	/// <summary>
	/// Служба управления кешем в базе данных
	/// </summary>
	public interface ICacheService
	{
		/// <summary>
		/// Возвращает коллекцию альбомов из базы данных
		/// </summary>
		/// <param name="artistName">Имя артиста</param>
		/// <returns>Коллекция альбомов</returns>
		AlbumCollection GetAlbumCollection(string artistName);

		/// <summary>
		/// Добавляет данные в кэш или обновляет их
		/// </summary>
		/// <param name="albumCollection">Коллекция альбомов для добавления</param>
		/// <param name="artistName">Имя артиста</param>
		void AddOrUpdate(AlbumCollection albumCollection, string artistName);
	}
}
