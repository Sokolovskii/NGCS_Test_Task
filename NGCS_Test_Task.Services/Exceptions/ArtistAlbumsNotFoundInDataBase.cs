using System;

namespace NGCS_Test_Task.Services.Exceptions
{
	/// <summary>
	/// Класс исключения отсутствия альбомов в базе данных
	/// </summary>
	public class ArtistAlbumsNotFoundInDataBase : Exception
	{
		public ArtistAlbumsNotFoundInDataBase(string message) : base(message) { }
	}
}
