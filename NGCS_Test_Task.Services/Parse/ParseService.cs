using Newtonsoft.Json;
using NGCS_Test_Task.Models;
using NGCS_Test_Task.Services.Exceptions;

namespace NGCS_Test_Task.Services.Parse
{
	public class ParseService : IParseService
	{
		public AlbumCollection ParseJson(string json)
		{
			var parsedJson = JsonConvert.DeserializeObject<AlbumCollection>(json);
			if(parsedJson.resultCount == 0)
			{
				throw new AlbumsNotFoundException("Альбомы артиста с данным названием не найдены, уточните название и повторите запрос");
			}
			return parsedJson;
		}
	}
}
