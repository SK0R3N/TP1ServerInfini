using Super_Cartes_Infinies.Models;

namespace Super_Cartes_Infinies.Combat
{
    public class CardDamageEvent : Event
    {
        public int PlayableCardId { get; set; }
        public int PlayerId { get; set; }

        
        public CardDamageEvent(Match match, MatchPlayerData currentPlayerData,  PlayableCard attackCard, PlayableCard defendCard) 
        {
            Events = new List<Event>();

            defendCard.Health = defendCard.Health - attackCard.Attack;

            if (defendCard.Health <= 0)
            {
                CardDeathEvent cardDeathEvent = new CardDeathEvent(match, currentPlayerData, defendCard);
                Events.Add(cardDeathEvent);
            }



             //TODO: CardDamageEvent done
        }
    }
}
