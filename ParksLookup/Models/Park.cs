using System;
using System.ComponentModel.DataAnnotations;

namespace ParksLookup.Models
{
  public class Park
  {
    public int ParkId { get; set; }
    public string ParkName { get; set; }
    public string ParkDescription { get; set; }
    public string StateName { get; set; }
  }
}