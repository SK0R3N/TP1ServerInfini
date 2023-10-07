using Super_Cartes_Infinies.Models;
using Super_Cartes_Infinies.Combat;
using Microsoft.EntityFrameworkCore;

namespace Super_Cartes_Infinies.Combat
{
    public class CardActivationEvent : Event
    {
        public int PlayableCardId { get; set; }
        public int PlayerId { get; set; }

        //ont luis dit quelle carte attaque quelle carte et ce qui arrive arrivra C'est important d'avir un CardActivationEvent pour permettre de jouer une animation sur la carte quand elle s'active
        public CardActivationEvent(Match match, PlayableCard playableCard, PlayableCard? opposingCard, MatchPlayerData currentPlayerData, MatchPlayerData opposingPlayerData)
        {
            //
            Events = new List<Event>();

            PlayableCardId = playableCard.Id;
            PlayerId = currentPlayerData.PlayerId;
            


            // TODO: done Implémenter la logique de combat du jeu (Il faut créer de nombreux énênements comme CardDamageEvent, PlayerDamageEvent
            if (opposingCard != null)
            {

                CardDamageEvent cardDamageEvent = new CardDamageEvent(match, currentPlayerData, playableCard, opposingCard);
                Events.Add(cardDamageEvent);
                if (cardDamageEvent.Events != null)//chek if card death
                {
                    Events.Add(cardDamageEvent.Events[0]);
                }

            }
            else
            {
                PlayerDamageEvent playerDamageEvent = new PlayerDamageEvent(match, playableCard, opposingPlayerData);
                Events.Add(playerDamageEvent);
                if (playerDamageEvent.Events != null)//chek if player death
                {
                    Events.Add(playerDamageEvent.Events[0]); // it take care anoncing the winner
                }
            }

                 // update helt of card and player
              // pour les appeler cest  _context.Add(CardActivationEvent.Events);
            // no event to the match itself yet
          
        }
    }
}
  