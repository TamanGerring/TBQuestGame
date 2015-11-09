using System;
using System.Collections.Generic;
using TBQuestGame;
using TBQuestGame.Models;

namespace TBQuestGame
{
    public class NPC : Models.Character
    {

        ConsoleView _consoleView;

        public void TalkTo()
        {
            _consoleView.DisplayMessage("Hi.");
        }

        private List<TreasureItem> _inventory;

        public List<TreasureItem> Inventory
        {
            get { return _inventory; }
            set { _inventory = value; }
        }

        public NPC()
        {

        }

        public NPC(List<TreasureItem> inventory)
        {
            inventory = _inventory;
        }

    }
}