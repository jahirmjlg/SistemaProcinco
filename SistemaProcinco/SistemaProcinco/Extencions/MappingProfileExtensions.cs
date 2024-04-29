using AutoMapper;
using SistemaProcinco.Common.Models;
using SistemaProcinco.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaProcinco.API.Extencions
{
    public class MappingProfileExtensions : Profile 
    {
        public MappingProfileExtensions()
        {
            CreateMap<BlanckViewModel, BlankEntitie>().ReverseMap();

        }
    }
}
