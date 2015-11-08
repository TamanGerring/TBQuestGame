using System;
using TBQuestGame;

namespace TBQuestGame
{
    public class NPC : Models.Character
    {

        ConsoleView _consoleView;

        public void TalkTo()
        {
            _consoleView.DisplayMessage("Hi.");
        }
    }
}