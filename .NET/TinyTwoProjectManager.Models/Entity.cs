using System;
using System.ComponentModel.DataAnnotations;

namespace TinyTwoProjectManager.Models
{
    public abstract class Entity
    {
        [Key]
        public int Id { get; set; }

        public DateTime DateCreated { get; set; }

        public Entity()
        {
            DateCreated = DateTime.Now;
        }
    }
}