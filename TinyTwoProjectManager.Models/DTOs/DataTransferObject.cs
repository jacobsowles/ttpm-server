using System;

namespace TinyTwoProjectManager.Models
{
    public abstract class DataTransferObject
    {
        public int Id { get; set; }
        public DateTime DateCreated { get; set; }

        public DataTransferObject()
        {
            DateCreated = DateTime.Now;
        }
    }
}