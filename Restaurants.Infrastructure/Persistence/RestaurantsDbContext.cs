﻿using Microsoft.EntityFrameworkCore;
using Restaurants.Domain.Models;


namespace Restaurants.Infrastructure.Persistence
{
    internal class RestaurantsDbContext: DbContext
    {
        public RestaurantsDbContext(DbContextOptions<RestaurantsDbContext> options):base(options)
        {
            
        }

        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<Dish> Dishes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Restaurant>().OwnsOne(r => r.Address);

            modelBuilder.Entity<Restaurant>().HasMany(r => r.Dishes).WithOne().HasForeignKey(d => d.RestaurantId);
        }
    }
}
