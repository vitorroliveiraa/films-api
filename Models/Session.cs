using System.ComponentModel.DataAnnotations;

namespace films_api.Models;

public class Session
{
    public int? FilmId { get; set; }
    public virtual Film Film { get; set; }
    public int? CinemaId { get; set; }
    public virtual Cinema Cinema { get; set; }
}