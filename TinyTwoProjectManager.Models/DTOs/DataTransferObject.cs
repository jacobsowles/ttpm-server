using System;
using System.ComponentModel.DataAnnotations;

namespace TinyTwoProjectManager.Models
{
    public abstract class DataTransferObject
    {
        public int Id { get; set; }
        public DateTime DateCreated { get; set; }
    }
}