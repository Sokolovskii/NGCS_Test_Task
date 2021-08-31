using Microsoft.Extensions.DependencyInjection;
using NGCS_Test_Task.Services.Cache;
using NGCS_Test_Task.Services.Parse;
using NGCS_Test_Task.Services.Print;
using NGCS_Test_Task.Services.Search;
using NGCS_Test_Task.Entity.Repository;
using NGCS_Test_Task.Entity;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Builder;

namespace NGCS_Test_Task
{
	class Startup
	{
		public IConfiguration Configuration { get; }
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public void ConfigureServices(IServiceCollection services)
		{
			services.AddSingleton<AlbumContext>();
			services.AddSingleton<ISearchService, SearchService>();
			services.AddSingleton<IAlbumRepository, AlbumRepository>();
			services.AddSingleton<IParseService, ParseService>();
			services.AddSingleton<IPrintService, PrintService>();
			services.AddSingleton<ICacheService, CacheService>();
		}

		public void Configure(IApplicationBuilder app){}
	}
}
