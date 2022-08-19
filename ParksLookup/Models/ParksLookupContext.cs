using System;
using Microsoft.EntityFrameworkCore;

namespace ParksLookup.Models
{
  public class ParksLookupContext : DbContext 
  {
    public ParksLookupContext(DbContextOptions<ParksLookupContext> options) : base(options)
    {

    }

    public DbSet<Park> Parks { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
      builder.Entity<Park>()
          .HasData(
              new Park { ParkId = 1, ParkName = "Yellowstone National Park", ParkDescription ="wilderness recreations area atop a volcanic hot spot" StateName = "Wyoming"},
              new Park { ParkId = 2, ParkName = "Yosemite National Park", ParkDescription ="Inside California's Sierra Nevada mountains" StateName = "California"},
              new Park { ParkId = 3, ParkName = "Grand Teton National Park", ParkDescription ="Popular summer destination for mountaineering, hiking, backcountry camping and fishing" StateName = "Wyoming"},
              new Park { ParkId = 4, ParkName = "Grand Canyon National Park", ParkDescription ="" StateName = "Arizona"},
              new Park { ParkId = 5, ParkName = "", ParkDescription ="" StateName = ""},
              new Park { ParkId = 6, ParkName = "", ParkDescription ="" StateName = ""},
              new Park { ParkId = 7, ParkName = "", ParkDescription ="" StateName = ""},
              new Park { ParkId = 8, ParkName = "", ParkDescription ="" StateName = ""},

          )

    }
  }
}