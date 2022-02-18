using Microsoft.EntityFrameworkCore;
using Restaurant.DAL.EF;
using Restaurant.DAL.Entities;
using Restaurant.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant.DAL.Data
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(RestaurantDbContext context) : base(context, context.Users)
        {
        }
    }
}
