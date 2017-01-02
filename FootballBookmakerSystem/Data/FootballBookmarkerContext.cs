using Models;

namespace Data
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class FootballBookmarkerContext : DbContext
    {
        // Your context has been configured to use a 'FootballBookmarkerContext' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'Data.FootballBookmarkerContext' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'FootballBookmarkerContext' 
        // connection string in the application configuration file.
        public FootballBookmarkerContext()
            : base("name=FootballBookmarkerContext")
        {
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }
        public virtual DbSet<Team> Teams { get; set; }
        public virtual DbSet<Color> Colors { get; set; }
        public virtual DbSet<Town> Towns { get; set; }
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<Continent> Continents { get; set; }
        public virtual DbSet<Player> Players { get; set; }
        public virtual DbSet<Position> Positions { get; set; }
        public virtual DbSet<PlayerStatistic> PlayerStatistics { get; set; }
        public virtual DbSet<Game> Games { get; set; }
        public virtual DbSet<Round> Rounds { get; set; }
        public virtual DbSet<Competition> Competitions { get; set; }
        public virtual DbSet<CompetitionType> CompetitionTypes { get; set; }
        public virtual DbSet<BetGame> BetGames { get; set; }
        public virtual DbSet<Bet> Bets { get; set; }
        public virtual DbSet<ResultPrediction> ResultPredictions { get;set; }
        public virtual DbSet<User> Users { get; set; }

        




    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}