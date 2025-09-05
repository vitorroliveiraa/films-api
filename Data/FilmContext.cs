using films_api.Models;
using Microsoft.EntityFrameworkCore;

namespace films_api.Data;

public class FilmContext : DbContext
{
    public FilmContext(DbContextOptions<FilmContext> opt) : base(opt)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Session>()
            .HasKey(session => new { session.FilmId, session.CinemaId });

        modelBuilder.Entity<Session>()
            .HasOne(session => session.Cinema)
            .WithMany(cinema => cinema.Sessions)
            .HasForeignKey(session => session.CinemaId);

        modelBuilder.Entity<Session>()
            .HasOne(session => session.Film)
            .WithMany(film => film.Sessions)
            .HasForeignKey(session => session.FilmId);

        modelBuilder.Entity<Address>()
            .HasOne(address => address.cinena)
            .WithOne(cinema => cinema.Address)
            .OnDelete(DeleteBehavior.Restrict);
    }

    public DbSet<Film> Films { get; set; }
    public DbSet<Cinema> Cinemas { get; set; }
    public DbSet<Address> Addresses { get; set; }
    public DbSet<Session> Sessions { get; set; }
}