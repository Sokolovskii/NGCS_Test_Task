using System.Linq;
using NGCS_Test_Task.Models;
using NGCS_Test_Task.Entity.Repository;

namespace NGCS_Test_Task.Services.Cache
{
	public class CacheService : ICacheService
	{
		private readonly IAlbumRepository _albumRepository;

		public CacheService(IAlbumRepository albumRepository)
		{
			_albumRepository = albumRepository;
		}
		public void AddOrUpdate(AlbumCollection albumCollection, string artistName)
		{
			albumCollection = FilterCollection(albumCollection, artistName);
			var albumCountInBase = _albumRepository.GetCountInBase(artistName);

			if(albumCountInBase != albumCollection.resultCount)
			{
				if (albumCountInBase != 0)
				{
					var comparer = new AlbumEqualityComparer();
					albumCollection.albums = albumCollection.albums.Except(_albumRepository.GetAlbums(artistName).albums, comparer).ToList();
				}
				_albumRepository.Add(albumCollection.albums);
			}
		}

		public AlbumCollection GetAlbumCollection(string artistName)
		{
			return _albumRepository.GetAlbums(artistName);
		}

		/// <summary>
		/// Метод фильтрации входной коллекции альбомов. Исключает альбомы, исполнители которых не содержат в себе исходную строку
		/// </summary>
		/// <param name="collection">Входная коллекция альбомов</param>
		/// <param name="artistName">Искомое название исполнителя</param>
		/// <returns>Отфильтрованная коллекция</returns>
		private static AlbumCollection FilterCollection(AlbumCollection collection, string artistName)
		{
			collection.albums.RemoveAll(t => !t.artistName.ToUpper().Contains(artistName.ToUpper()));
			collection.resultCount = collection.albums.Count();
			return collection;
		}
	}
}
