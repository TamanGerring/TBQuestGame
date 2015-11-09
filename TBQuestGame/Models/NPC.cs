using System;
using System.Collections.Generic;
using TBQuestGame;
using TBQuestGame.Models;

namespace TBQuestGame
{
    public class NPC : Models.Character
    {

        public string TalkTo(NPC npc)
        {
            if (npc.Race == NPC.RaceType.Troll)
            {
                return "Grr!";
            }
            else if (npc.Race == NPC.RaceType.Beholder)
            {
                return "Left Justified!";
            }
            else if (npc.Race == NPC.RaceType.Goblin)
            {
                return "KEY!";
            }
            else
            {
                return "FOUND BUG!";
            }
        }

        private List<TreasureItem> _inventory = new List<TreasureItem>();

        public List<TreasureItem> Inventory
        {
            get { return _inventory; }
            set { _inventory = value; }
        }

        public NPC()
        {

        }

        public NPC(string name, Character.GenderType gender, Character.RaceType race, int caveNumber)
        {
            Name = name;
            Gender = gender;
            Race = race;
            CaveNumber = caveNumber;
        }

        public NPC(List<TreasureItem> inventory)
        {
            inventory = _inventory;
        }

    }
}