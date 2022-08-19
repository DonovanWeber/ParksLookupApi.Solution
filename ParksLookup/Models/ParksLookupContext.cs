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

    }
  }
}