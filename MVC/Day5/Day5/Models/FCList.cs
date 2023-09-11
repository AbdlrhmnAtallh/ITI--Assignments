using Day5.Models;

namespace Day5.Models
{
    public class FCList
    {
        public static List<FootballClub> footballClubs = new List<FootballClub>();
        
        static FCList()
        {
            footballClubs.Add(new FootballClub { Id = 1, Name = "PSG" });
            footballClubs.Add(new FootballClub { Id = 2, Name = "Liverpool" });
            footballClubs.Add(new FootballClub { Id = 3, Name = "NewCastle" });
            footballClubs.Add(new FootballClub { Id = 4, Name = "Bercalona" });
            footballClubs.Add(new FootballClub { Id = 5, Name = "Madrid" });

        }
    }
}
