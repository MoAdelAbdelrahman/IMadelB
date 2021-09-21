using AutoMapper;
using rentee.DTOs;
using rentee.Models;

namespace rentee.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Domain to Dto
            Mapper.CreateMap<Customer, CustomerDto>();
            Mapper.CreateMap<Movie, MovieDto>();
            Mapper.CreateMap<MembershipType, membershipTypeDto>();
            Mapper.CreateMap<Category, CategoryDto>();
            


            // Dto to Domain
            Mapper.CreateMap<CustomerDto, Customer>()
                .ForMember(c => c.customerID, opt => opt.Ignore());

            Mapper.CreateMap<MovieDto, Movie>()
                .ForMember(c => c.movieID, opt => opt.Ignore());
        }
    }
}