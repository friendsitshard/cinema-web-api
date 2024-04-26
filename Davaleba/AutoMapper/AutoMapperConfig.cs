using System;
using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KinapoiskiDAL;
using Davaleba.DTOs;

namespace Davaleba.AutoMapper
{
    public class AutoMapperConfig
    {
        private static readonly IMapper _mapper;

        static AutoMapperConfig()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Actor, ActorDTO>();
                cfg.CreateMap<ActorDTO, Actor>();
                cfg.CreateMap<Movy, MovieDTO>();
                cfg.CreateMap<MovieDTO, Movy>();
            });
            _mapper = config.CreateMapper();
        }

        public static IMapper Mapper => _mapper;
    }
}