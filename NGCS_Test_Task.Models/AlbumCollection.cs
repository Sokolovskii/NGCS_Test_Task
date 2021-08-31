using Newtonsoft.Json;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace NGCS_Test_Task.Models
{
	public class AlbumCollection
	{
		[JsonProperty("resultCount")]
		public int resultCount { get; set; }

		[JsonProperty("results")]
		public List<Album> albums { get; set; }
	}
}
