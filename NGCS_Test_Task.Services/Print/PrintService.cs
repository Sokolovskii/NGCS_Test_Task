using System;
using NGCS_Test_Task.Models;

namespace NGCS_Test_Task.Services.Print
{
	public class PrintService : IPrintService
	{
		public void PrintInfoAboutAlbums(AlbumCollection albumCollection)
		{
			Console.WriteLine("Количество альбомов: " + albumCollection.resultCount);
			Console.WriteLine();
			Console.WriteLine("==================================================");
			Console.WriteLine();
			foreach (var album in albumCollection.albums)
			{
				Console.WriteLine("Название исполнителя(группы): " + album.artistName);
				Console.WriteLine("Название альбома: " + album.albumName);
				Console.WriteLine("Цензурное название альбома: " + album.albumCensoredName);
				Console.WriteLine("Количество песен: " + album.trackCount);
				Console.WriteLine("Дата релиза: " + album.releaseDate.ToString("D"));
				Console.WriteLine("Страна: " + album.country);
				Console.WriteLine("Жанр: " + album.genre);
				Console.WriteLine("Цена: " + album.price + ' ' + album.currency);
				Console.WriteLine("Ссылка на альбом в магазине Apple: " + album.albumViewUrl);
				Console.WriteLine("Ссылка на артиста в магазине Apple: " + album.artistViewUrl);
				Console.WriteLine("Ссылка на обложку: " + album.artworkUrl60);
				Console.WriteLine("Еще одна ссылка на обложку: " + album.artworkUrl100);
				Console.WriteLine("Правообладатель: " + album.copyright);
				Console.WriteLine();
				Console.WriteLine("==================================================");
				Console.WriteLine();
			}
		}
	}
}
