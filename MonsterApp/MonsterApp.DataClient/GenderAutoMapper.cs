using AutoMapper;
using MonsterApp.DataAccess.Models;
using MonsterApp.DataClient.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MonsterApp.DataClient
{
    public class GenderAutoMapper
    {
        private MapperConfiguration mapper = new MapperConfiguration(m => m.CreateMap<Gender, GenderDAO>()
            .ForMember(d => d.Id, o => o.MapFrom(s => s.GenderId)));

        public object MapTo(object o, object o1)
        {
            var m = mapper.CreateMapper();

            return m.Map(o, o1);
        }
    }
}