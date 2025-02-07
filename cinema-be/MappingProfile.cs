using AutoMapper;
using cinema_be.Entities;
using cinema_be.Models.DTO;
using cinema_be.Models.DTOs;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
      CreateMap<CreateMovieDto, Movie>();
      CreateMap<CreateSessionDto, Session>();
      CreateMap<CreateTicketDto, Ticket>();
      CreateMap<UpdateMovieDto, Movie>()
          .ForMember(dest => dest.Id, opt => opt.Ignore());
    }
}
