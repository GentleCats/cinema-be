using AutoMapper;
using cinema_be.Entities;
using cinema_be.Models.DTO;
using cinema_be.Models.DTOs;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        // Create mapping for Create DTOs
        CreateMap<CreateHallDto, Hall>();
        CreateMap<CreateMovieDto, Movie>()
            .ForMember(dest => dest.Cast, opt => opt.MapFrom(src => src.Cast)); // Map Cast from DTO to Entity

        // Mapping for Update DTOs
        CreateMap<UpdateMovieDto, Movie>()
            .ForMember(dest => dest.Id, opt => opt.Ignore())
            .ForMember(dest => dest.Cast, opt => opt.MapFrom(src => src.Cast)); // Handle Cast mapping

        // Mapping between Movie and MovieDto
        CreateMap<Movie, MovieDto>()
            .ForMember(dest => dest.Cast, opt => opt.MapFrom(src => src.Cast))  // Map Cast correctly
            .ForMember(dest => dest.Sessions, opt => opt.MapFrom(src => src.Sessions));  // Map Sessions correctly

        // Actor mappings
        CreateMap<ActorDto, Actor>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name)); // Map ActorDto to Actor (customize as needed)

        CreateMap<Actor, ActorDto>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name)); // Actor to ActorDto mapping
    }
}
