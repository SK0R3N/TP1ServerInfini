using Super_Cartes_Infinies.Models;

namespace Super_Cartes_Infinies.Combat
{
    public class DrawCardEvent : Event
    {

        public int PlayableCardId { get; set; }
        public int PlayerId { get; set; }

        public DrawCardEvent(Match match, MatchPlayerData playerData)
        {
            if (playerData.CardsPile.Count > 0)
            {
                int lastElementIndex = playerData.CardsPile.Count() - 1;
                var playableCard = playerData.CardsPile[lastElementIndex];

                PlayerId = playerData.PlayerId;
                PlayableCardId = playableCard.Card.Id;

                playerData.CardsPile.RemoveAt(lastElementIndex);
                playerData.Hand.Add(playableCard);
            }
            else
            {//meurt si ta pas de carte 

                playerData.Health = 0;
                //PlayerDamageEvent
                PlayerDeathEvent playerDeathEvent = new PlayerDeathEvent(match,playerData);
            }
        }
    }
}
