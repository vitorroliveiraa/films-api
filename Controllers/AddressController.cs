using AutoMapper;
using films_api.Data;
using films_api.Dtos;
using films_api.Models;
using Microsoft.AspNetCore.Mvc;

namespace films_api.Controllers;

[ApiController]
[Route("[controller]")]
public class AddressController : ControllerBase
{
    private FilmContext _context;
    private IMapper _mapper;

    public AddressController(FilmContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpPost]
    public IActionResult CreateAddress([FromBody] CreateAddressDto addressDto)
    {
        Address address = _mapper.Map<Address>(addressDto);
        _context.Addresses.Add(address);
        _context.SaveChanges();
        return CreatedAtAction(nameof(GetAddressById), new { id = address.Id }, address);
    }

    [HttpGet]
    public IEnumerable<ReadAddressDto> GetAddresses()
    {
        return _mapper.Map<List<ReadAddressDto>>(_context.Addresses.ToList());
    }

    [HttpGet("{id}")]
    public IActionResult GetAddressById(int id)
    {
        Address address = _context.Addresses.FirstOrDefault(a => a.Id == id);
        if (address == null) return NotFound();

        ReadAddressDto addressDto = _mapper.Map<ReadAddressDto>(address);
        return Ok(addressDto);
    }

    [HttpPut("{id}")]
    public IActionResult UpdateAddress(int id, [FromBody] UpdateAddressDto addressDto)
    {
        Address address = _context.Addresses.FirstOrDefault(a => a.Id == id);
        if (address == null) return NotFound();

        _mapper.Map(addressDto, address);
        _context.SaveChanges();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteAddress(int id)
    {
        Address address = _context.Addresses.FirstOrDefault(a => a.Id == id);
        if (address == null) return NotFound();

        _context.Remove(address);
        _context.SaveChanges();
        return NoContent();
    }
}