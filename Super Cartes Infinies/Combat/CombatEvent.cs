using Microsoft.Extensions.Logging;
using Super_Cartes_Infinies.Models;

namespace Super_Cartes_Infinies.Combat
{
    public class CombatEvent : Event
    {
        public CombatEvent(Match match, MatchPlayerData currentPlayerData, MatchPlayerData opposingPlayerData)
        {
            Events = new List<Event>();

            // TODO: C'est le moment de faire s'affronter les cartes 
            // Pour chaque carte sur le BattleField du joueur courrant, il faut créer un CardActivationEvent
            // L'opposingCard c'est la carte qui a le même index sur le BattleField de l'adversaire
            // Si il n'y en a pas, on passe simplement null
            // oublie pas D'alterner de combat a combat qui est currentPlayerData et opposingPlayerData
            // Exemple: CardActivationEvent cardActivationEvent = new CardActivationEvent(match, currentPlayerData.BattleField[0], opposingPlayerData.BattleField[0]);
            int i = 0;//send all card to cardActivationEvent
            foreach(PlayableCard card in currentPlayerData.BattleField)
            {
                CardActivationEvent cardActivationEvent = new CardActivationEvent(match, currentPlayerData.BattleField[i], opposingPlayerData.BattleField.FirstOrDefault(), currentPlayerData, opposingPlayerData);
                // FirstOrDefault make sure that if there is a card to defent it will defend but if there is no card it will send null
                i++; 
                 Events.Add(cardActivationEvent);
                foreach (var item in cardActivationEvent.Events)
                {
                    Events.Add(item);
                }
            }
            int e = 0;//send all card to cardActivationEvent
            foreach (PlayableCard card in currentPlayerData.BattleField)
            {
                CardActivationEvent cardActivationEvent = new CardActivationEvent(match,opposingPlayerData.BattleField[i], currentPlayerData.BattleField.FirstOrDefault() ,opposingPlayerData ,currentPlayerData );
                // FirstOrDefault make sure that if there is a card to defent it will defend but if there is no card it will send null
                i++;
                Events.Add(cardActivationEvent);
                foreach (var item in cardActivationEvent.Events)
                {
                    Events.Add(item);
                }
            }

        }
    }
}
