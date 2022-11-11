﻿using AutoMapper;
using TestApp.DTOs;
using TestApp.Entities;

namespace TestApp.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Account, AccountDto>().ReverseMap();
            CreateMap<Contact, ContactDto>().ReverseMap();
            CreateMap<Incident, IncidentDto>().ReverseMap();
        }
    }
}
