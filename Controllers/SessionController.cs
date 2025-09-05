using AutoMapper;
using films_api.Data;
using films_api.Dtos;
using films_api.Models;
using Microsoft.AspNetCore.Mvc;

namespace films_api.Controllers;

[ApiController]
[Route("[controller]")]
public class SessionController : ControllerBase
{
    private FilmContext _context;
    private IMapper _mapper;

    public SessionController(FilmContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpPost]
    public IActionResult CreateSession(CreateSessionDto sessionDto)
    {
        Session session = _mapper.Map<Session>(sessionDto);
        _context.Sessions.Add(session);
        _context.SaveChanges();
        return CreatedAtAction(
            nameof(GetSessionById),
            new { filmId = session.FilmId, cinemaId = session.CinemaId },
            session);
    }

    [HttpGet]
    public IEnumerable<ReadSessionDto> GetSessions()
    {
        return _mapper.Map<List<ReadSessionDto>>(_context.Sessions.ToList());
    }

    [HttpGet("{filmId}/{cinemaId}")]
    public IActionResult GetSessionById(int filmId, int cinemaId)
    {
        Session session = _context.Sessions.FirstOrDefault(session =>
            session.FilmId == filmId && session.CinemaId == cinemaId
        );
        if (session == null) return NotFound();

        ReadSessionDto sessionDto = _mapper.Map<ReadSessionDto>(session);
        return Ok(sessionDto);
    }
}