using System.Collections.Generic;
using NGCS_Test_Task.Models;

namespace NGCS_Test_Task.Entity.Repository
{
	/// <summary>
	/// Интерфейс репозитория
	/// </summary>
	public interface IAlbumRepository
	{
		/// <summary>
		/// Добавляет коллекцию альбомов в базу
		/// </summary>
		/// <param name="albums">Коллекция альбомов</param>
		void Add(List<Album> albums);

		/// <summary>
		/// Возврат из БД всех альбомов указанного артиста
		/// </summary>
		/// <param name="artistName">Имя артиста</param>
		/// <returns>Коллекция альбомов</returns>
		AlbumCollection GetAlbums(string artistName);

		/// <summary>
		/// ВОзвращает количество альбомов в кэше
		/// </summary>
		/// <param name="artistName">Имя артиста</param>
		/// <returns>ЧИсло альбомов</returns>
		int GetCountInBase(string artistName);
	}
}
