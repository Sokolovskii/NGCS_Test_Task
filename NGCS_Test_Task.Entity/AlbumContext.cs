using Microsoft.EntityFrameworkCore;
using NGCS_Test_Task.Models;

namespace NGCS_Test_Task.Entity
{
	public class AlbumContext : DbContext
	{
		public DbSet<Album> Albums { get; set; }
		public string DbPath { get; private set; }
		public AlbumContext(){}

		protected override void OnConfiguring(DbContextOptionsBuilder options)
					=> options.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=NGCS_Test_Task_DB;Trusted_Connection=True;");
	}
}
