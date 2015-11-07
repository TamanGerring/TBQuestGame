using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TBQuestGame.Models
{
    public class TreasureItem
    {
        #region FIELDS

        private int _rarity;
        private string _name;
        private bool _isShiny;
        private List<string> _nameList = new List<string> { "Lucky Medallion", "A Rock", "Gold Coin", "Rusty Spork", "Greatsword of Slaying", "A Twig" };

        #endregion

        #region PROPERTIES

        public int Rarity
        {
            get { return _rarity; }
            set { _rarity = value; }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public bool IsShiny
        {
            get { return _isShiny; }
            set { _isShiny = value; }
        }

        #endregion

        #region CONSTRUCTORS

        public TreasureItem(string name, int rarity, bool isShiny)
        {
            _name = name;
            _rarity = rarity;
            _isShiny = isShiny;
        }

        #endregion

        #region METHODS



        #endregion

    }
}
