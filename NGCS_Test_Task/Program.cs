using Microsoft.Extensions.DependencyInjection;
using NGCS_Test_Task.Services.Cache;
using NGCS_Test_Task.Services.Parse;
using NGCS_Test_Task.Services.Print;
using NGCS_Test_Task.Services.Search;
using NGCS_Test_Task.Models;
using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore;

namespace NGCS_Test_Task
{
	class Program
	{
		static void Main(string[] args)
		{
			var host = CreateHostBuilder(args).Build();

			var serviceProvider = host.Services.CreateScope().ServiceProvider;

			var searchService = serviceProvider.GetRequiredService<ISearchService>();
			var parseService = serviceProvider.GetRequiredService<IParseService>();
			var printService = serviceProvider.GetRequiredService<IPrintService>();
			var cacheService = serviceProvider.GetRequiredService<ICacheService>();
			var albumCollection = new AlbumCollection();

			while (true){
				Console.Write("Введите название артиста: ");
				string artistName = Console.ReadLine();
				try
				{
					albumCollection = parseService.ParseJson(searchService.SearchAlbumsJson(artistName));
					cacheService.AddOrUpdate(albumCollection, artistName);
				}
				catch
				{
					Console.WriteLine("Соединение с сетью нарушено, данные будут извлечены из кэша");
					albumCollection = cacheService.GetAlbumCollection(artistName);
				}
				finally
				{
					if (albumCollection.resultCount != 0)
					{
						printService.PrintInfoAboutAlbums(albumCollection);
					}
					else
					{
						Console.WriteLine("Исполнитель не найден. Проверьте подключение к сети и уточните запрос");
					}
				}
			}
		}

		public static IWebHostBuilder CreateHostBuilder(string[] args)
		{
			return WebHost.CreateDefaultBuilder(args).UseStartup<Startup>();
		}

	}
}
