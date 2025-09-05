using System.ComponentModel.DataAnnotations;

namespace films_api.Dtos;

public class UpdateCinemaDto
{
    [Required(ErrorMessage = "O campo do nome é obrigatório.")]
    public string Name { get; set; }
}