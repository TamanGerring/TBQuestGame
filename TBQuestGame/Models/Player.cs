using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TBQuestGame
{
    public class Player : Models.Character
    {
        #region ENUMERABLES
        //Add enumerable for player actions
        public enum PlayerChoice
        {
            None,
            Move,
            Exit
        }
        #endregion

        #region FIELDS
        private bool _inPass;

        #endregion

        #region Properties
        public bool inPass
        {
            get { return _inPass;  }
            set { _inPass = value; }
        }

        #endregion
        //Display action options - Quit or Move

        //Get action choice

        //Echo action choice
    }
}
