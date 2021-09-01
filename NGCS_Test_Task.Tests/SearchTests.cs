using NUnit.Framework;
using NGCS_Test_Task.Services.Search;
using System.Net;

namespace NGCS_Test_Task.Tests
{
	[TestFixture]
	class SearchTests_GetJson
	{
		private SearchService searchService;
		private const string emptyJson = "\n\n\n{\n \"resultCount\":0,\n \"results\": []\n}\n\n\n";

		private static bool ChechInternetConnection()
		{
			var request = (HttpWebRequest)HttpWebRequest.Create("http://www.google.com");
			try
			{
				request.GetResponse();
				return true;
			}
			catch (WebException)
			{
				return false;
			}
		}
		[SetUp]
		public void Setup() 
		{
			searchService = new SearchService();
		}

		[Test]
		public void GetJson_Artist_NotZeroJson()
		{
			bool isConnected = ChechInternetConnection();

			var artistName = "RAM";

			if (isConnected)
			{
				Assert.AreNotEqual(emptyJson, searchService.SearchAlbumsJson(artistName));
				Assert.AreNotEqual("", searchService.SearchAlbumsJson(artistName));
			}
			else
			{
				Assert.Throws<WebException>(() => searchService.SearchAlbumsJson(artistName));
			}
			
		}

		[Test]
		public void GetJson_EmptyArtist_ZeroJson()
		{
			bool isConnected = ChechInternetConnection();

			var artistName = "";

			if (isConnected)
			{
				Assert.AreEqual(emptyJson, searchService.SearchAlbumsJson(artistName));
				Assert.AreNotEqual("", searchService.SearchAlbumsJson(artistName));
			}
			else
			{
				Assert.Throws<WebException>(() => searchService.SearchAlbumsJson(artistName));
			}

		}

		[Test]
		public void GetJson_RandomArtist_ZeroJson()
		{
			bool isConnected = ChechInternetConnection();

			var artistName = AlbumCollectionGenerator.GetRandomString(10);

			if (isConnected)
			{
				Assert.AreEqual(emptyJson, searchService.SearchAlbumsJson(artistName));
				Assert.AreNotEqual("", searchService.SearchAlbumsJson(artistName));
			}
			else
			{
				Assert.Throws<WebException>(() => searchService.SearchAlbumsJson(artistName));
			}
		}
	}
}
