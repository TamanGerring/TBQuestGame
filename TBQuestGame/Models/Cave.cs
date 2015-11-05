using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TBQuestGame
{
    public class Cave
    {

        #region ENUMERABLES

        public enum TypeName
        {
            Cave,
            Mine,
            Cavern
        }

        #endregion

        #region FIELDS

        private string _name;
        private TypeName _type;

        private bool _isLighted;
        private bool _canEnter;

        private string _description;

        private NPC _caveNPC;
        private NPCList _caveNPCList;

        


        #endregion

        #region PROPERTIES

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public TypeName Type
        {
            get { return _type; }
            set { _type = value; }
        }


        public bool IsLighted
        {
            get { return _isLighted; }
            set { _isLighted = value; }
        }

        public bool CanEnter
        {
            get { return _canEnter; }
            set { _canEnter = value; }
        }

        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }

        public NPC CaveNPC
        {
            get { return _caveNPC; }
            set { _caveNPC = value; }
        }

        public NPCList CaveNPCList
        {
            get { return _caveNPCList; }
            set { _caveNPCList = value; }
        }


        #endregion

        #region CONSTRUCTORS

        public Cave()
        {

        }

        #endregion

        #region METHODS


        #endregion
    }

}
