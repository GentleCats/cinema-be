using AutoMapper;
using cinema_be.Entities;
using cinema_be.Models.DTO;
using cinema_be.Models.DTOs;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<CreateHallDto,Hall>();
        CreateMap<CreateMovieDto, Movie>();
        CreateMap<CreateSessionDto, Session>();
        CreateMap<CreateTicketDto, Ticket>();
        CreateMap<Movie, MovieDto>();
        CreateMap<UpdateMovieDto, Movie>()
          .ForMember(dest => dest.Id, opt => opt.Ignore());
        CreateMap<Movie, MovieDto>()
            .ForMember(dest => dest.Sessions, opt => opt.MapFrom(src => src.Sessions));

        CreateMap<Session, SessionDto>();
    }
}
