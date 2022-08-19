using System;
using Microsoft.EntityFrameworkCore;

namespace ParksLookup.Models
{
  public class ParksLookupContext : DbContext 
  {
    public ParksLookupContext(DbContextOptions<ParksLookupContext> options) : base(options)
    {
    }


    protected override void OnModelCreating(ModelBuilder builder)
    {
      builder.Entity<Park>()
          .HasData(
              new Park { ParkId = 1, ParkName = "Yellowstone National Park", ParkDescription ="wilderness recreations area atop a volcanic hot spot", StateName = "Wyoming"},
              new Park { ParkId = 2, ParkName = "Yosemite National Park", ParkDescription ="Inside California's Sierra Nevada mountains", StateName = "California"},
              new Park { ParkId = 3, ParkName = "Grand Teton National Park", ParkDescription ="Popular summer destination for mountaineering, hiking, backcountry camping and fishing", StateName = "Wyoming"},
              new Park { ParkId = 4, ParkName = "Grand Canyon National Park", ParkDescription ="Wide views of canyons revealing layered bands of red rock" ,StateName = "Arizona"},
              new Park { ParkId = 5, ParkName = "Glacier National Park", ParkDescription ="Glacier carved peaks and valleys running to the Canadian border", StateName = "Montana"}
       

          );

    }
    public DbSet<Park> Parks { get; set; }
  }
}