using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TBQuestGame.Models
{
    class Treasure
    {
        #region FIELDS

        private string _container;
        private int _numItems;
        private bool _isLocked;
        private List<TreasureItem> _heldItems = new List<TreasureItem>();

        #endregion

        #region PROPERTIES

        public string Container
        {
            get { return _container; }
            set { _container = value; }
        }

        public int NumberOfItems
        {
            get { return _numItems; }
            set { _numItems = value; }
        }

        public bool IsLocked
        {
            get { return _isLocked; }
            set { _isLocked = value; }
        }

        public List<TreasureItem> HeldItems
        {
            get { return _heldItems; }
            set { _heldItems = value; }
        }

        #endregion

        #region CONSTRUCTORS

        public Treasure()
        {

        }

        #endregion

        #region METHODS

        public void PopulateContainer()
        {

        }

        public void OpenContainer()
        {

        }

        #endregion

    }
}
