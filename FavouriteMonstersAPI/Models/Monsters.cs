﻿using System.ComponentModel.DataAnnotations;

namespace FavouriteMonstersAPI.Models
{
    public class Monsters
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public Element Element { get; set; }
        public string ImageUrl { get; set; }
    }

    public enum Element
    {
        Fire, Grass, Water
    }
}