namespace Linq.DataAccess
{
    using System;
    using System.Data.Entity;

    public class MoviesDB : DbContext
    {
        // Your context has been configured to use a 'MoviesDB' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'Linq.DataAccess.MoviesDB' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'MoviesDB' 
        // connection string in the application configuration file.
        public MoviesDB()
            : base("name=MoviesDB")
        {

        }

        static MoviesDB()
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<MoviesDB>());
        }

        public virtual DbSet<Review> Reviews { get; set; }
        public virtual DbSet<Movie> Movies { get; set; }
        public virtual DbSet<Video> Videos { get; set; }
    }

    public class Review
    {
        public int Id { get; set; }
        public int Rating { get; set; }
        public string ReviewerName { get; set; }
    }

    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime ReleaseDate { get; set; }
    }

    public class Video
    {
        public int Id { get; set; }
        public int Length { get; set; }
        public string FileType { get; set; }
    }
}