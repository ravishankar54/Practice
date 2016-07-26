using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
namespace CodeFirstMappingDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            ENTRYfk121(args);
        }

        public static void ENTRYfk121(string[] args)
        {
            using (var ctx = new Context121())
            {
                // ctx.Database.Create();
                var cand = new Booking() { NAME = "New Booking1" };
                var cand1 = new Booking() { NAME = "New Booking2" };
                var cand2 = new Booking() { NAME = "New Booking3" };
                var cand3 = new Booking() { NAME = "New Booking4" };

                //ctx.Booking.Add(cand); ctx.Booking.Add(cand1); ctx.Booking.Add(cand2); ctx.Booking.Add(cand3);

                var candData1 = new RentalContract() { ADDRESS = "Contract1" };
                var candData2 = new RentalContract() { ADDRESS = "Contract1" };
                var candData3 = new RentalContract() { ADDRESS = "Contract1" };
                var candData4 = new RentalContract() { ADDRESS = "Contract1" };

                //ctx.RentalContracts.Add(candData1); ctx.RentalContracts.Add(candData2); ctx.RentalContracts.Add(candData3); ctx.RentalContracts.Add(candData4);
                //ctx.SaveChanges();
                var rentalContracts = ctx.RentalContracts.ToList();
              //  var bookings = ctx.Bookings.ToList();
            }
            System.Console.ReadKey();
        }
    }

    public class Booking
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]// best in Fluent API, In my opinion..
        public long BK_ID { get; set; }
        public string NAME { get; set; }
        //   public long CandidateDataId { get; set; }// DONT TRY THIS... Although DB will support EF cant deal with 1:1 and both as FKs
    //    public virtual RentalContract Contract { get; set; }  // Reverse navigation

    }
    public class RentalContract
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)] // best in Fluent API as it is EF/DB related 
        public long RC_ID { get; set; }   // is also a Foreign with EF and 1:1 when this is dependent
                                          // [Required]
                                          // public long CandidateId { get; set; }   // dont need this... PK is the FK to Principal in 1:1
        public string ADDRESS { get; set; }
        public long BK_ID { get; set; }
        public virtual Booking Booking { get; set; } // yes we need this
    }
    public class Context121 : DbContext
    {
        static Context121()
        {
            // Database.SetInitializer(new DropCreateDatabaseAlways<Context121>());
        }
        public Context121() : base()
        { }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<RentalContract> RentalContracts { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Booking>();
            //.HasOptional(c => c.Contract)
            //.WithRequired(b => b.Booking);

            modelBuilder.Entity<RentalContract>()
             // .HasKey(e => e.BK_ID);
             .HasRequired(c => c.Booking)
             .WithMany()
             .HasForeignKey(t =>t.BK_ID);

            //.HasOptional(q => q.Booking)
            // .WithMany()
            //.HasForeignKey(t => t.BK_ID);
            // .WithRequiredDependent(l => l.Contract);
            //.WithRequiredPrincipal(b => b.Contract); // this would be blank if reverse validation wasnt used, but here it is used
            //.Map(t => t.MapKey("BK_ID"));   // Only use MAP when the Foreign Key Attributes NOT annotated as attributes
        }
    }
}
