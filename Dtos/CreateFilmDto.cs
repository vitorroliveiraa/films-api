using System.ComponentModel.DataAnnotations;

namespace films_api.Dtos;

public class CreateFilmDto
{
    [Required(ErrorMessage = "O título do filme é obrigatório.")]
    public string Title { get; set; }
    [Required(ErrorMessage = "O Genero do filme é obrigatório.")]
    [StringLength(50, ErrorMessage = "O gênero do filme não pode exceder 50 caracteres.")]
    public string Gender { get; set; }
    [Required]
    [Range(70, 600, ErrorMessage = "A duração do filme deve ter entre 70 e 600 minutos.")]
    public int Duration { get; set; }
}