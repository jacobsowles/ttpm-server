using System.ComponentModel.DataAnnotations;

namespace TinyTwoProjectManager.Models
{
    public class ProductivityStatus : DatabaseTable
    {
        public string Name { get; set; }
        public int Rank { get; set; }
    }
}