using System.ComponentModel.DataAnnotations;

namespace MediatorDemo.Models
{
    public class Player
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Level { get; set; }
    }
}
