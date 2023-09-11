using System.ComponentModel.DataAnnotations.Schema;

namespace Day5.Models
{
    public class Player
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [ForeignKey("FootballClup")]
        public int FC { get; set; }
        public FootballClub FootballClubs { get; set; }

    }
}
