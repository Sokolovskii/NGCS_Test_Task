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
	}
}
