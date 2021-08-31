using Newtonsoft.Json;
using Microsoft.EntityFrameworkCore;
using System;

namespace NGCS_Test_Task.Models
{
	public class Album
	{
		public int Id { get; set; }

		[JsonProperty("artistName")]
		public string artistName { get; set; }

		[JsonProperty("collectionName")]
		public string albumName { get; set; }

		[JsonProperty("collectionCensoredName")]
		public string albumCensoredName { get; set; }

		[JsonProperty("artistViewUrl")]
		public string artistViewUrl { get; set; }

		[JsonProperty("collectionViewUrl")]
		public string albumViewUrl { get; set; }

		[JsonProperty("artworkUrl60")]
		public string artworkUrl60 { get; set; }

		[JsonProperty("artworkUrl100")]
		public string artworkUrl100 { get; set; }

		[JsonProperty("collectionPrice")]
		public float price { get; set; }

		[JsonProperty("trackCount")]
		public int trackCount { get; set; }

		[JsonProperty("copyright")]
		public string copyright { get; set; }

		[JsonProperty("country")]
		public string country { get; set; }

		[JsonProperty("currency")]
		public string currency { get; set; }

		[JsonProperty("releaseDate")]
		public DateTimeOffset releaseDate { get; set; }

		[JsonProperty("primaryGenreName")]
		public string genre { get; set; }
	}
}
