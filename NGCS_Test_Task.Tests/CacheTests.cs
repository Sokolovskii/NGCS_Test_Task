using NUnit.Framework;
using Moq;
using NGCS_Test_Task.Entity.Repository;
using NGCS_Test_Task.Services.Cache;
using NGCS_Test_Task.Services.Exceptions;
using NGCS_Test_Task.Models;
using System.Collections.Generic;

namespace NGCS_Test_Task.Tests
{
	[TestFixture]
	public class CacheTests
	{
		private CacheService _cacheService;
		private readonly Mock<IAlbumRepository> _albumRepository = new Mock<IAlbumRepository>();

		[SetUp]
		public void Setup()
		{
			_cacheService = new CacheService(_albumRepository.Object);
		}

		/// <summary>
		/// Проверка штатной работы метода GetAlbumCollectionCorrect
		/// </summary>
		[Test]
		public void GetAlbumCollectionCorrect()
		{
			var artistName = "RAM";
			var collection = AlbumCollectionGenerator.GetCorrectAlbumCollection(artistName);

			_albumRepository.Setup(rep => rep.GetAlbums(artistName)).Returns(collection);

			Assert.DoesNotThrow(() => _cacheService.GetAlbumCollection(artistName));
		}

		/// <summary>
		/// Проверка нештатной работы метода GetAlbumCollectionCorrect
		/// </summary>
		[Test]
		public void GetAlbumCollectionNonCorrect()
		{
			var artistName = "RAM";
			var collection = new AlbumCollection
			{
				albums = new List<Album>(),
				resultCount = 0
			};

			_albumRepository.Setup(rep => rep.GetAlbums(artistName)).Returns(collection);

			Assert.Throws<ArtistAlbumsNotFoundInDataBase>(() => _cacheService.GetAlbumCollection(artistName));
		}
	}
}