using AutoMapper;
using cinema_be.Entities;
using cinema_be.Models.DTO;
using cinema_be.Models.DTOs;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<CreateSessionDto, Session>();
        CreateMap<Session, SessionDto>();

        CreateMap<CreateTicketDto, Ticket>();
        CreateMap<CreateHallDto, Hall>();
        CreateMap<CreateMovieDto, Movie>()
            .ForMember(dest => dest.Cast, opt => opt.MapFrom(src => src.Cast));

        CreateMap<UpdateMovieDto, Movie>()
            .ForMember(dest => dest.Id, opt => opt.Ignore())
            .ForMember(dest => dest.Cast, opt => opt.Ignore());

        CreateMap<Movie, MovieDto>()
            .ForMember(dest => dest.Cast, opt => opt.MapFrom(src => src.Cast))
            .ForMember(dest => dest.Sessions, opt => opt.MapFrom(src => src.Sessions));

        CreateMap<ActorDto, Actor>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name)); 

        CreateMap<Actor, ActorDto>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name)); 
    }
}
