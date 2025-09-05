using System.ComponentModel.DataAnnotations;

namespace films_api.Dtos;

public class ReadFilmDto
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Gender { get; set; }
    public int Duration { get; set; }
    public DateTime AppointmentTime { get; set; } = DateTime.Now;
    public ICollection<ReadSessionDto> Sessions { get; set; }
}