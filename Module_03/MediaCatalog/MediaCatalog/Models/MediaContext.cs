using Microsoft.EntityFrameworkCore;

namespace MediaCatalog.Models
{
	public class MediaContext : DbContext
    {
		public MediaContext(DbContextOptions<MediaContext> options) : base(options)
        {
        }
		public DbSet<MediaCatalog.Models.Media> Medias { get; set; }
    }
}
