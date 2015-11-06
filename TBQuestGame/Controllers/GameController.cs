﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TBQuestGame
{
    public class GameController
    {
        #region FIELDS

        Player _myPlayer;
        Pass _pass;
        NPCList _NPCList;

        #endregion

        #region PROPERTIES

        #endregion

        #region CONSTRUCTORS

        public GameController()
        {
            SetupGame();
            PlayGame();
        }

        #endregion

        #region METHODS

        private void SetupGame()
        {
            InitializePlayer();
            InitializePass();
            InitializeNPCList();
        }

        private void PlayGame()
        {
            ConsoleView _consoleView = new ConsoleView(_myPlayer, _pass, _NPCList);

            _consoleView.DisplayWelcomeScreen();

            _consoleView.DisplayPlayerOptions();

            //_consoleView.DisplayAllObjectInformation();

            _consoleView.DisplayReset();
            _consoleView.DisplayExitPrompt();
        }

        private void InitializePlayer()
        {
            _myPlayer = new Player()
            {
                Name = "Sindre",
                Gender = Models.Character.GenderType.Female,
                Race = Models.Character.RaceType.Elf
            };
        }

        private void InitializePass()
        {
            _pass = new Pass();

            for (int caveNumber = 0; caveNumber < 4; caveNumber++)
            {
                _pass.Caves[caveNumber] = new Cave();
            }

            _pass.Caves[0].Name = "Traveler's Shelter";
            _pass.Caves[0].Description = "You are in the well known Traveler's Shelter. You find the cave has been used recently, most likely from a caravan that passed by a week ago.";
            _pass.Caves[0].Type = Cave.TypeName.Cave;
            _pass.Caves[0].IsLighted = true;
            _pass.Caves[0].CanEnter = true;


            _pass.Caves[1].Name = "Hidden Cave";
            _pass.Caves[1].Description = "You have found a hidden cave. Be wary, goblins are known to dwell in hidden caves. You peer around the corner and see goblins sleeping around a campfire, behind a stalagmite you see a poorly hidden chest.";
            _pass.Caves[1].Type = Cave.TypeName.Cave;
            _pass.Caves[1].IsLighted = true;
            _pass.Caves[1].CanEnter = true;
            _pass.Caves[1].CaveNPC = new NPC
            {
                Name = "Gork the Stinky",
                Gender = NPC.GenderType.Male,
                Race = NPC.RaceType.Goblin,
            };
            //_pass.Caves[1].CaveNPC = new NPC
            //{
            //    Name = "Snouz the Sneak",
            //    Gender = NPC.GenderType.Male,
            //    Race = NPC.RaceType.Goblin,
            //};


            _pass.Caves[2].Name = "Abandoned Iron Mine";
            _pass.Caves[2].Description = "You are in an abandoned iron mine. The dwarves mined iron here for years, then one day they collapsed the tunnel and moved out in a hurry. Rumor has it they found something down there they didn't want to escape. There are some recent signs of active mining. Someone really wants to know whats down there.";
            _pass.Caves[2].Type = Cave.TypeName.Mine;
            _pass.Caves[2].IsLighted = false;
            _pass.Caves[2].CanEnter = true;


            _pass.Caves[3].Name = "Beholder's Cavern";
            _pass.Caves[3].Description = "You come to a cave entrance, and you attempt to enter but are repelled by an invisible barrier. You need a magical item to enter this cave.";
            _pass.Caves[3].Type = Cave.TypeName.Cavern;
            _pass.Caves[3].IsLighted = false;
            _pass.Caves[3].CanEnter = false;
        }

        private void InitializeNPCList()
        {
            _NPCList = new NPCList();

            int NPCNumber = 0;

            foreach (Cave cave in _pass.Caves)
            {
                if (cave.CaveNPC != null)
                {
                    _NPCList.NPCs[NPCNumber] = cave.CaveNPC;
                    NPCNumber++;
                }
            }
        }

        #endregion
    }
}
