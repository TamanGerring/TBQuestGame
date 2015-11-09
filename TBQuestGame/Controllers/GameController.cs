using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TBQuestGame.Models;

namespace TBQuestGame
{
    public class GameController
    {
        #region FIELDS

        Player _myPlayer;
        Pass _pass;
        NPCList _NPCList;
        ConsoleView _consoleView;
        Treasure _chest;
        Player.PlayerChoice _playerChoice;

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
            InitializeNPCList();
            InitializePass();
            InitializeLoot();
            InitializeConsoleView();
        }

        private void PlayGame()
        {

            _consoleView.DisplayWelcomeScreen();


            while (true)
            {
                if (_myPlayer.inPass)
                {
                    _consoleView.DisplayPassMessage();

                }
                else
                {
                    _consoleView.DisplayCaveMessage();
                }

                _playerChoice = _consoleView.GetPlayerAction();

                ImplementPlayerAction(_playerChoice);
            }


            //_consoleView.DisplayAllObjectInformation();
            // _consoleView.DisplayPlayerOptions();
            //_consoleView.DisplayReset();
            //_consoleView.DisplayExitPrompt();
        }

        private void InitializePlayer()
        {
            _myPlayer = new Player()
            {
                Name = "Sindre",
                Gender = Models.Character.GenderType.Female,
                Race = Models.Character.RaceType.Elf
            };

            _myPlayer.inPass = true;
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
            //_pass.Caves[1].CaveNPC = new List<NPC>()
            {
                //Name = "Gork the Stinky",
                //Gender = NPC.GenderType.Male,
                //Race = NPC.RaceType.Goblin,
            };
            _pass.Caves[1].CaveNPC = new NPC
            {
                Name = "Snouz the Sneak",
                Gender = NPC.GenderType.Male,
                Race = NPC.RaceType.Goblin,
            };


            _pass.Caves[2].Name = "Abandoned Iron Mine";
            _pass.Caves[2].Description = "You are in an abandoned iron mine. The dwarves mined iron here for years, then one day they collapsed the tunnel and moved out in a hurry. Rumor has it they found something down there they didn't want to escape. There are some recent signs of active mining. Someone really wants to know whats down there.";
            _pass.Caves[2].Type = Cave.TypeName.Mine;
            _pass.Caves[2].IsLighted = false;
            _pass.Caves[2].CanEnter = true;
            _pass.Caves[2].CaveNPC = new NPC
            {
                Name = "Ellehcem the Short",
                Gender = NPC.GenderType.Female,
                Race = NPC.RaceType.Troll,
            };


            _pass.Caves[3].Name = "Beholder's Cavern";
            _pass.Caves[3].Description = "You come to a cave entrance, and you attempt to enter but are repelled by an invisible barrier. You need a magical item to enter this cave.";
            _pass.Caves[3].Type = Cave.TypeName.Cavern;
            _pass.Caves[3].IsLighted = false;
            _pass.Caves[3].CanEnter = false;
            _pass.Caves[3].CaveNPC = new NPC
            {
                Name = "Alemap",
                Gender = Character.GenderType.None,
                Race = NPC.RaceType.Beholder,
            };

            for (int i = 0; i < _pass.Caves.Length - 1; i++)
            {
                _NPCList.NPCs.Add(_pass.Caves[i].CaveNPC);
            }
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

        private void InitializeConsoleView()
        {
            _consoleView = new ConsoleView(_myPlayer, _pass, _NPCList);
        }

        private void InitializeLoot()
        {
            Random rand = new Random();

            _chest = new Treasure(rand.Next(1, 11));

            _chest.GenerateItems();
        }

        private void ImplementPlayerAction(Player.PlayerChoice playerChoice)
        {
            switch (playerChoice)
            {
                case Player.PlayerChoice.None:

                case Player.PlayerChoice.Exit:
                    _consoleView.DisplayExitPrompt();
                    break;
                case Player.PlayerChoice.Move:
                    // player moves to hall
                    if (!_myPlayer.inPass)
                    {
                        _myPlayer.inPass = true;

                        _consoleView.DisplayPassMessage();
                    }
                    // player chooses room
                    else
                    {
                        int newCaveNumber = _consoleView.GetPlayerRoomNumberChoice();

                        _myPlayer.CaveNumber = newCaveNumber;
                        _myPlayer.inPass = false;
                    }
                    break;
                case Player.PlayerChoice.Search:
                    bool treasureFound = false, 
                         npcFound = false;

                    if (_myPlayer.CaveNumber == _chest.CaveNumber)
                    {
                        _consoleView.DisplayMessage("Treasure found!");
                        treasureFound = true;
                    }

                    foreach (NPC npc in _NPCList.NPCs)
                    {
                        if (npc.CaveNumber == _myPlayer.CaveNumber)
                        {
                            _consoleView.DisplayMessage(npc.Name + " the " + npc.Gender + " " + npc.Race + " has been found!");
                            npcFound = true;
                        }
                    }

                    if (treasureFound == false && npcFound == false)
                    {
                        _consoleView.DisplayMessage("There is nothing here...");
                    }
                    break;
                case Player.PlayerChoice.Open:
                    if (_chest.CaveNumber == _myPlayer.CaveNumber)
                    {
                        TreasureItem key = _myPlayer.Inventory.FirstOrDefault(item => item.Name == "Beholder's Key");

                        _chest.OpenContainer(key);
                    }
                    else
                    {
                        _consoleView.DisplayMessage("There is nothing here to open...");
                    }
                    break;
                case Player.PlayerChoice.Talk:
                    int i = 0;
                    foreach (NPC npc in _NPCList.NPCs)
                    {
                        if (npc.CaveNumber == _myPlayer.CaveNumber)
                        { 
                            npc.TalkTo();
                            i = 1;
                        }
                    }

                    if (i == 0)
                    {
                        _consoleView.DisplayMessage("There is no one here...");
                    }
                    break;
                default:
                    throw new System.ArgumentException("This ActionChoice has not been implemented in the switch.", "");
            }
        }
        #endregion
    }
}
