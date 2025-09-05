using AutoMapper;
using films_api.Dtos;
using films_api.Models;

namespace films_api.Profiles;

public class SessionProfile : Profile
{
    public SessionProfile()
    {
        CreateMap<CreateSessionDto, Session>();
        CreateMap<Session, ReadSessionDto>();
    }
}