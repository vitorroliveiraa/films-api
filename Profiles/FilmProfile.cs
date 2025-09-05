using AutoMapper;
using films_api.Dtos;
using films_api.Models;

namespace films_api.Profiles;

public class FilmProfile : Profile
{
    public FilmProfile()
    {
        CreateMap<CreateFilmDto, Film>();
        CreateMap<UpdateFilmDto, Film>();
        CreateMap<Film, UpdateFilmDto>();
        CreateMap<Film, ReadFilmDto>()
            .ForMember(filmDto => filmDto.Sessions,
                opt => opt.MapFrom(film => film.Sessions));
    }
}