using System.IO;
using System.Net;

namespace NGCS_Test_Task.Services.Search
{
	/// <summary>
	/// Реализация интерфейса поисковой службы
	/// </summary>
	public class SearchService : ISearchService
	{

		public string SearchAlbumsJson(string artistName)
		{
			return GetJson(GetResponse(GetLink(artistName)));
		}

		/// <summary>
		/// Возвращает ссылку, полученную из имени артиста
		/// </summary>
		/// <param name="artistName">имя артиста</param>
		/// <returns>Ссылка на ITunes</returns>
		private string GetLink(string artistName)
		{
			artistName = artistName.Trim().Replace(' ', '+');
			return "https://itunes.apple.com/search?term=" + artistName + "&entity=album&attribute=artistTerm&limit=200";
		}

		/// <summary>
		/// Возвращает WebResponse из линка
		/// </summary>
		/// <param name="link">ссылка, полученная от линкера</param>
		/// <returns>экземпляр WebResponse</returns>
		private WebResponse GetResponse(string link)
		{
			WebRequest request = WebRequest.Create(link);
			request.Method = "POST";
			return request.GetResponse();
		}

		/// <summary>
		/// Читает Json из респонса и возвращает его
		/// </summary>
		/// <param name="response">Экземпляр WebResponse</param>
		/// <returns>Сырой Json</returns>
		private string GetJson(WebResponse response)
		{
			string answer = string.Empty;
			using (Stream stream = response.GetResponseStream())
			{
				using (StreamReader reader = new StreamReader(stream))
				{
					answer = reader.ReadToEnd();
				}
			}
			response.Close();
			return answer;
		}
	}
}
