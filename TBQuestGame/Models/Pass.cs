using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TBQuestGame
{
    public class Pass
    {

        #region ENUMERABLES

        #endregion

        #region FIELDS

        public const int MAX_CAVES = 4;

        private Cave[] _caves;


        #endregion

        #region PROPERTIES
        public Cave[] Caves
        {
            get { return _caves; }
            set { _caves = value; }
        }

        #endregion

        #region CONSTRUCTORS

        public Pass()
        {
            _caves = new Cave[MAX_CAVES];
            //InitializeCaves();
        }

        #endregion

        #region METHODS

        private void InitializeCaves()
        {
            for (int caveNumber = 0; caveNumber < MAX_CAVES; caveNumber++)
            {
                _caves[caveNumber] = new Cave();
            }

            _caves[0].Name = "Traveler's Shelter";
            _caves[0].Description = "You are in the well known Traveler's Shelter. You find the cave has been used recently, most likely from a caravan that passed by a week ago.";
            _caves[0].Type = Cave.TypeName.Cave;
            _caves[0].IsLighted = true;
            _caves[0].CanEnter = true;
            

            _caves[1].Name = "Hidden Cave";
            _caves[1].Description = "You have found a hidden cave. Be cautious there are Goblin footprints on the ground. You peer around the corner and see a goblin sleeping around a campfire, behind a stalagmite you see a poorly hidden chest.";
            _caves[1].Type = Cave.TypeName.Cave;
            _caves[1].IsLighted = true;
            _caves[1].CanEnter = true;
            _caves[1].CaveNPC = new NPC
            {
                Name = "Gork the Stinky",
                Gender = NPC.GenderType.Male,
                Race = NPC.RaceType.Goblin,

            };


            _caves[2].Name = "Abandoned Iron Mine";
            _caves[2].Description = "You are in an abandoned iron mine. The dwarves mined iron here for years, they even found some gold veins, then one day they collapsed the tunnel and moved out in a hurry. Rumor was they found something down there they didn't want to escape. There are some recent signs of active mining. Someone really wants to know whats down there.";
            _caves[2].Type = Cave.TypeName.Mine;
            _caves[2].IsLighted = false;
            _caves[2].CanEnter = true;


            _caves[3].Name = "Beholder's Cavern";
            _caves[3].Description = "You come to a cave entrance, and you attempt to enter but are repelled by an invisible barrier. You need a magical item to enter this cave.";
            _caves[3].Type = Cave.TypeName.Cavern;
            _caves[3].IsLighted = false;
            _caves[3].CanEnter = false;
        }

        #endregion

    }
}
