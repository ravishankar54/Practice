using System.Data.Entity;

namespace GloboMartDataAccessService.Models
{
    public class GloboMartContext : DbContext
    {
        static GloboMartContext()
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<GloboMartContext>());
        }
        public GloboMartContext()
            : base("GloboMartDataContext")
        {

        }
        public DbSet<Product> Products { get; set; }
    }
}
