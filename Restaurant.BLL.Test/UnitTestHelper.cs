using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant.BLL.Test
{
    internal static class UnitTestHelper
    {
        public static IMapper CreateMapperProfile()
        {
            var myProfile = new MapperProfile();

            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(myProfile));

            return new Mapper(configuration);
        }
    }
}
