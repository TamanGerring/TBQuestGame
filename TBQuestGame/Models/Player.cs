using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TBQuestGame.Models;

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
            Exit,
            Search,
            Open,
            Talk
        }
        #endregion

        #region FIELDS
        private bool _inPass;
        private List<TreasureItem> _inventory = new List<TreasureItem>();

        #endregion

        #region Properties
        public bool inPass
        {
            get { return _inPass;  }
            set { _inPass = value; }
        }

        public List<TreasureItem> Inventory
        {
            get { return _inventory; }
            set { _inventory = value; }
        }
        #endregion
        //Display action options - Quit or Move

        //Get action choice

        //Echo action choice
    }
}
