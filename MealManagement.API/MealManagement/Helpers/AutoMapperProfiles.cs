using AutoMapper;
using MealManagement.Data.Models;
using MealManagement.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MealManagement.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<User, UserForDetailedDto>();

            CreateMap<UserForRegisterDto, User>();
        }
    }
}
