using Super_Cartes_Infinies.Models;

namespace Super_Cartes_Infinies.Combat
{
    public class PlayerDamageEvent : Event
    {
        public int PlayableCardId { get; set; }
        public int PlayerId { get; set; }

        // 
        public PlayerDamageEvent(Match match, PlayableCard attackCard, MatchPlayerData DefendingPlayerData)
        {
            Events = new List<Event>();

            
            if (attackCard.Attack < DefendingPlayerData.Health) { DefendingPlayerData.Health = DefendingPlayerData.Health - (attackCard.Attack); }
            else { PlayerDeathEvent playerDeathEvent = new PlayerDeathEvent(match, DefendingPlayerData);
                Events.Add(playerDeathEvent);
            }

            // TODO done PlayerDamageEvent
        }
    }
}
