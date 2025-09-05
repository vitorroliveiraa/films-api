using AutoMapper;
using films_api.Data;
using films_api.Dtos;
using films_api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace films_api.Controllers;

[ApiController]
[Route("[controller]")]
public class CinemaController : ControllerBase
{
    private FilmContext _context;
    private IMapper _mapper;

    public CinemaController(FilmContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpPost]
    public IActionResult CreateCinema([FromBody] CreateCinemaDto cinemaDto)
    {
        Cinema cinema = _mapper.Map<Cinema>(cinemaDto);
        _context.Cinemas.Add(cinema);
        _context.SaveChanges();
        return CreatedAtAction(nameof(GetCinemasById), new { id = cinema.Id }, cinemaDto);
    }

    [HttpGet]
    public IEnumerable<ReadCinemaDto> GetCinemas([FromQuery] int? addressId = null)
    {
        if (addressId == null)
        {
            var cinemasList = _mapper.Map<List<ReadCinemaDto>>(_context.Cinemas.ToList());
            return cinemasList;
        }

        return _mapper.Map<List<ReadCinemaDto>>(_context.Cinemas.FromSqlRaw(
                $"SELECT Id, Name, AddressId FROM Cinemas WHERE Cinemas.AddressId = {addressId}").ToList()
        );
    }

    [HttpGet("{id}")]
    public IActionResult GetCinemasById(int id)
    {
        Cinema cinema = _context.Cinemas.FirstOrDefault(c => c.Id == id);
        if (cinema == null)
        {
            return NotFound();
        }

        ReadCinemaDto cinemaDto = _mapper.Map<ReadCinemaDto>(cinema);
        return Ok(cinemaDto);
    }

    [HttpPut("{id}")]
    public IActionResult UpdateCinema(int id, [FromBody] UpdateCinemaDto cinemaDto)
    {
        Cinema cinema = _context.Cinemas.FirstOrDefault(c => c.Id == id);
        if (cinema == null) return NotFound();

        _mapper.Map(cinemaDto, cinema);
        _context.SaveChanges();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteCinema(int id)
    {
        Cinema cinema = _context.Cinemas.FirstOrDefault(c => c.Id == id);
        if (cinema == null) return NotFound();

        _context.Remove(cinema);
        _context.SaveChanges();
        return NoContent();
    }
}