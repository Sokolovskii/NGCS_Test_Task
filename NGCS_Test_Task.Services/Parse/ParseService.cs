using Newtonsoft.Json;
using NGCS_Test_Task.Models;

namespace NGCS_Test_Task.Services.Parse
{
	public class ParseService : IParseService
	{
		public AlbumCollection ParseJson(string json)
		{
			return JsonConvert.DeserializeObject<AlbumCollection>(json);
		}
	}
}
