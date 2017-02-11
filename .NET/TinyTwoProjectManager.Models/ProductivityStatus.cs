using System.ComponentModel.DataAnnotations;

namespace TinyTwoProjectManager.Models
{
    public class ProductivityStatus : Entity
    {
        public string Name { get; set; }
        public int Rank { get; set; }
    }
}