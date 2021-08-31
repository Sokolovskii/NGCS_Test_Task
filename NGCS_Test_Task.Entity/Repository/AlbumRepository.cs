using System.Collections.Generic;
using NGCS_Test_Task.Models;
using System.Linq;

namespace NGCS_Test_Task.Entity.Repository
{
	/// <summary>
	/// Релизация интерфейса репозитория альбомов
	/// </summary>
	public class AlbumRepository : IAlbumRepository
	{
		private readonly AlbumContext _context;

		public AlbumRepository(AlbumContext albumContext)
		{
			_context = albumContext;
		}

		public void Add(List<Album> albums)
		{
			foreach(var album in albums)
			{
				_context.Add(album);
			}
			_context.SaveChanges();
		}

		public AlbumCollection GetAlbums(string artistName)
		{
			var albumCollection =  new AlbumCollection
			{
				albums = _context.Albums.Where(t => t.artistName.Contains(artistName)).ToList()
			};
			albumCollection.resultCount = albumCollection.albums.Count;
			return albumCollection;
		}

		public int GetCountInBase(string artistName)
		{
			return _context.Albums.Count(t => t.artistName.Contains(artistName));
		}

		public void Update(List<Album> albums, string artistName)
		{
			var comparer = new AlbumComparer();
			var newAlbums = albums.Except(_context.Albums.Where(t => t.artistName.Contains(artistName)).ToList(), comparer).ToList();
			foreach(var album in newAlbums)
			{
				_context.Add(album);
			}
			_context.SaveChanges();
		}
	}

	/// <summary>
	/// Класс, реализующий интерфейс IEqualityComparer для сравнения между собой экземпляров альбомов
	/// </summary>
	class AlbumComparer : IEqualityComparer<Album>
	{
		/// <summary>
		/// Метод сравнения двух экземпляров Album по значениям свойств
		/// </summary>
		public bool Equals(Album x, Album y)
		{
			return x.artistName == y.artistName &&
				x.albumName == y.albumName &&
				x.albumCensoredName == y.albumCensoredName &&
				x.albumViewUrl == y.albumViewUrl &&
				x.artistViewUrl == y.artistViewUrl &&
				x.artworkUrl100 == y.artworkUrl100 &&
				x.artworkUrl60 == y.artworkUrl60 &&
				x.copyright == y.copyright &&
				x.country == y.country &&
				x.currency == y.currency &&
				x.genre == y.genre &&
				x.price == y.price &&
				x.releaseDate == y.releaseDate &&
				x.trackCount == y.trackCount; 
		}

		/// <summary>
		/// Метод генерации хэш-кода для указанного экземпляра Album
		/// </summary>
		/// <param name="obj">Экземпляр класса Album</param>
		/// <returns>Хэш-код</returns>
		public int GetHashCode(Album obj)
		{
			var HashSource = obj.artistName + obj.albumCensoredName + obj.copyright;
			return HashSource.GetHashCode();
		}
	}
}
