using NuGet.Packaging;
using Super_Cartes_Infinies.Models;

namespace Super_Cartes_Infinies.Combat
{
    public class PlayerTurnEvent : Event
    {
        public int PlayerId { get; set; }
        // L'évènement lorsqu'un joueur termine son tour
        public PlayerTurnEvent(Match match, MatchPlayerData currentPlayerData, MatchPlayerData opposingPlayerData)
        {
            this.PlayerId = currentPlayerData.PlayerId;
            this.Events = new List<Event>();

            this.Events.Add(new CombatEvent(match, currentPlayerData, opposingPlayerData));

            // TODO: Faire piger une carte à l'adversaire
            if (opposingPlayerData.CardsPile != null) {
                DrawCardEvent drawCardEvent = new DrawCardEvent(match, opposingPlayerData);
                this.Events.Add(drawCardEvent);

            }
            else
            {
                throw new Exception("opposingPlayerData is null");
            }
            
            
            // TODO: C'est la fin du tour du joueurCourrant, il faut mettre match à jour!

            
            foreach (var eventItem in Events)
            {
                match.AddEvent(eventItem);
            }
            match.IsPlayerATurn = !match.IsPlayerATurn;




        }

    }
}
