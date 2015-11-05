namespace TBQuestGame
{
    public class NPCList
    {
        #region ENUMERABLES

        #endregion

        #region FIELDS

        public const int MAX_NUMBER_OF_NPCS = 4;

        private NPC[] _NPCList;
        //private  myVar;

        //public  MyProperty
        //{
        //    get { return myVar; }
        //    set { myVar = value; }
        //}



        #endregion

        #region PROPERTIES

        public NPC[] NPCs
        {
            get { return _NPCList; }
            set { _NPCList = value; }
        }

        #endregion
        
        #region CONSTRUCTORS

        public NPCList()
        {
            _NPCList = new NPC[MAX_NUMBER_OF_NPCS];
        }

        #endregion

        #region METHODS



        #endregion
    }
}