using System;
using System.Collections.Generic;
using System.Text;
using NGCS_Test_Task.Models;

namespace NGCS_Test_Task.Tests
{
	public static class AlbumCollectionGenerator
	{

		public const string Alphabet = "QWERTYUIOPASDFGHJKLZXCVBNMqwertyuiopasdfghjklzxcvbnm";

		public static AlbumCollection GetCorrectAlbumCollection(string artistName)
		{
			var random = new Random();
			var albumList = new List<Album>();
			for(int i = 0; i < random.Next(10, 120); i++)
			{
				albumList.Add(GenerateCorrectAlbum(artistName));
			}
			return new AlbumCollection
			{
				albums = albumList,
				resultCount = albumList.Count
			};
		}

		public static AlbumCollection GetNonCorrectAlbumCollection()
		{
			var random = new Random();
			var albumList = new List<Album>();
			for (int i = 0; i < random.Next(10, 120); i++)
			{
				albumList.Add(GenerateNonCorrectAlbum());
			}
			return new AlbumCollection
			{
				albums = albumList,
				resultCount = albumList.Count
			};
		}

		public static Album GenerateCorrectAlbum(string artistName)
		{
			var random = new Random();
			return new Album 
			{
				albumCensoredName = GetRandomString(15),
				albumName = GetRandomString(15),
				artistName = artistName,
				albumViewUrl = GetRandomString(30),
				artistViewUrl = GetRandomString(30),
				artworkUrl100 = GetRandomString(30),
				artworkUrl60 = GetRandomString(30),
				copyright = GetRandomString(15),
				country = GetRandomString(15),
				currency = GetRandomString(10),
				genre = GetRandomString(15),
				Id = random.Next(),
				price = (float)random.NextDouble(),
				releaseDate = DateTimeOffset.Now,
				trackCount = random.Next(0, 15)
			};
		}

		public static Album GenerateNonCorrectAlbum()
		{
			var random = new Random();
			return new Album
			{
				albumCensoredName = GetRandomString(15),
				albumName = GetRandomString(15),
				artistName = GetRandomString(15),
				albumViewUrl = GetRandomString(30),
				artistViewUrl = GetRandomString(30),
				artworkUrl100 = GetRandomString(30),
				artworkUrl60 = GetRandomString(30),
				copyright = GetRandomString(15),
				country = GetRandomString(15),
				currency = GetRandomString(10),
				genre = GetRandomString(15),
				Id = random.Next(),
				price = (float)random.NextDouble(),
				releaseDate = DateTimeOffset.Now,
				trackCount = random.Next(0, 15)
			};
		}

		public static string GetRandomString(int lenght) 
		{
			var randomizer = new Random();
			var sb = new StringBuilder(lenght-1);
			int position = 0;

			for(int i = 0; i < lenght; i++)
			{
				position = randomizer.Next(0, Alphabet.Length - 1);
				sb.Append(Alphabet[position]);
			}
			return sb.ToString();
		}
	}
}
