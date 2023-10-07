using Super_Cartes_Infinies.Models;

namespace Super_Cartes_Infinies.Combat
{
    public class CardDeathEvent : Event
    {
        public int PlayableCardId { get; set; }
        public int PlayerId { get; set; }

        
        public CardDeathEvent(Match match, MatchPlayerData currentPlayerData, PlayableCard Card) 
        {
            
            currentPlayerData.Graveyard.Add(Card);
            currentPlayerData.BattleField.Remove(Card);
            // TODO:CardDeathEvent done
        }
    }
}
