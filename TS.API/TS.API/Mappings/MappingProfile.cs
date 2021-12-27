using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TS.DAL.Entities;
using TS.DTO.Responses;

namespace TS.API.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserResponseDTO>();
            CreateMap<UserResponseDTO, User>();
        }
    }
}
