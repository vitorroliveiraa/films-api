using AutoMapper;
using films_api.Data;
using films_api.Dtos;
using films_api.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace films_api.Controllers;

[ApiController]
[Route("[controller]")]
public class FilmController : ControllerBase
{
    private FilmContext _context;
    private IMapper _mapper;

    public FilmController(FilmContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    /// <summary>
    /// Adiciona um filme ao banco de dados
    /// </summary>
    /// <param name="filmeDto">Objeto com os campos necessários para criação de um filme</param>
    /// <returns>IActionResult</returns>
    /// <response code="201">Caso inserção seja feita com sucesso</response>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public IActionResult AddFilm([FromBody] CreateFilmDto filmDto)
    {
        Film film = _mapper.Map<Film>(filmDto);
        _context.Films.Add(film);
        _context.SaveChanges();
        return CreatedAtAction(nameof(GetFilmById), new { id = film.Id }, film);
    }

    [HttpGet]
    public IEnumerable<ReadFilmDto> GetFilms(
        [FromQuery] int skip = 0,
        [FromQuery] int take = 50,
        [FromQuery] string? nameCinema = null
    )
    {
        if (nameCinema == null)
        {
            return _mapper.Map<List<ReadFilmDto>>(_context.Films.Skip(skip).Take(take).ToList());
        }


        return _mapper.Map<List<ReadFilmDto>>(_context.Films.Skip(skip).Take(take)
            .Where(film => film.Sessions.Any(session => session.Cinema.Name == nameCinema)).ToList());
    }

    [HttpGet("{id}")]
    public IActionResult GetFilmById(int id)
    {
        var film = _context.Films.FirstOrDefault(f => f.Id == id);
        if (film == null)
        {
            return NotFound();
        }

        var filmDto = _mapper.Map<ReadFilmDto>(film);
        return Ok(filmDto);
    }

    [HttpPut("{id}")]
    public IActionResult UpdateFilm(int id, [FromBody] UpdateFilmDto filmDto)
    {
        var film = _context.Films.FirstOrDefault(f => f.Id == id);
        if (film == null) return NotFound();
        _mapper.Map(filmDto, film);
        _context.SaveChanges();
        return NoContent();
    }

    [HttpPatch("{id}")]
    public IActionResult UpdatePartialFilm(int id, [FromBody] JsonPatchDocument<UpdateFilmDto> patch)
    {
        var film = _context.Films.FirstOrDefault(f => f.Id == id);
        if (film == null) return NotFound();

        UpdateFilmDto filmDtoToPatch = _mapper.Map<UpdateFilmDto>(film);

        patch.ApplyTo(filmDtoToPatch, ModelState);

        if (!TryValidateModel(filmDtoToPatch))
        {
            return ValidationProblem(ModelState);
        }

        _mapper.Map(filmDtoToPatch, film);
        _context.SaveChanges();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteFilm(int id)
    {
        var Film = _context.Films.FirstOrDefault(f => f.Id == id);
        if (Film == null) return NotFound();
        _context.Films.Remove(Film);
        _context.SaveChanges();
        return NoContent();
    }
}