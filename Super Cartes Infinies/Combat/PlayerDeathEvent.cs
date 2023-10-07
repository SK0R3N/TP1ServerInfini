using Super_Cartes_Infinies.Models;

namespace Super_Cartes_Infinies.Combat
{
    public class PlayerDeathEvent : Event
    {
        public int PlayableCardId { get; set; }
        public int PlayerId { get; set; }

        // 
        public PlayerDeathEvent(Match match, MatchPlayerData DefendingPlayerData)
        {
            Events = new List<Event>();

            DefendingPlayerData.Health = 0;
            match.IsMatchCompleted = true;
            match.WinnerUserId = DefendingPlayerData.PlayerId.ToString();
        }
    }
}
