using System.Collections.Generic;
using NGCS_Test_Task.Models;

namespace NGCS_Test_Task.Entity
{
	/// <summary>
	/// Класс, реализующий интерфейс IEqualityComparer для сравнения между собой экземпляров альбомов
	/// </summary>
	class AlbumEqualityComparer : IEqualityComparer<Album>
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
			var HashSource = obj.artistName +
				obj.albumName +
				obj.albumCensoredName +
				obj.albumViewUrl +
				obj.artistViewUrl +
				obj.artworkUrl100 +
				obj.artworkUrl60 +
				obj.copyright +
				obj.country +
				obj.currency +
				obj.genre +
				obj.price.ToString() +
				obj.releaseDate.ToString() +
				obj.trackCount.ToString();
			return HashSource.GetHashCode();
		}
	}
}
