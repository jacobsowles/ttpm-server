using System;
using System.ComponentModel.DataAnnotations;

namespace TinyTwoProjectManager.Models
{
    public abstract class DatabaseTable
    {
        [Key]
        public int Id { get; set; }

        public DateTime DateCreated { get; set; }

        public DatabaseTable()
        {
            DateCreated = DateTime.Now;
        }
    }
}