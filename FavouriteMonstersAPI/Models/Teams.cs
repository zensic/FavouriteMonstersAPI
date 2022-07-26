﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FavouriteMonstersAPI.Models
{
  public class Teams
  {
    [Key]
    public Guid Id { get; set; }
    [ForeignKey("Users")]
    public Guid UserId { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
  }
}
