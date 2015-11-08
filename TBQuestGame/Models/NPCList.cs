using System.Collections.Generic;

namespace TBQuestGame
{
    public class NPCList
    {
        #region ENUMERABLES

        #endregion

        #region FIELDS

        public const int MAX_NUMBER_OF_NPCS = 4;

        //private NPC[] _NPCList;
        private List<NPC> _npc;

        public List<NPC> NPCs
        {
            get { return _npc; }
            set { _npc = value; }
        }



        #endregion

        #region PROPERTIES

        //public NPC[] NPCs
        //{
        //    get { return _NPCList; }
        //    set { _NPCList = value; }
        //}

        #endregion
        
        #region CONSTRUCTORS

        public NPCList()
        {
            //_NPCList = new NPC[MAX_NUMBER_OF_NPCS];
            _npc = new List<NPC>();
        }

        #endregion

        #region METHODS



        #endregion
    }
}