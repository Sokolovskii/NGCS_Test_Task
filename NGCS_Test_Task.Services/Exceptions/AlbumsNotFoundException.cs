using System;

namespace NGCS_Test_Task.Services.Exceptions
{
	/// <summary>
	/// Класс исключения отсутствия альбомовв коллекции
	/// </summary>
	public class AlbumsNotFoundException : Exception
	{
		public AlbumsNotFoundException(string message) : base(message) { }
	}
}
