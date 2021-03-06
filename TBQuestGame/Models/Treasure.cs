﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TBQuestGame.Models
{
    public class Treasure
    {
        #region FIELDS

        private string _container = "Chest";
        private int _numItems;
        private bool _isLocked = true;
        private List<TreasureItem> _heldItems = new List<TreasureItem>();
        private List<TreasureItem> _genItems = new List<TreasureItem>();
        private List<TreasureItem> _keys = new List<TreasureItem>();
        private int caveNumber = 3;

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

        public int CaveNumber
        {
            get { return caveNumber; }
            set { caveNumber = value; }
        }

        public List<TreasureItem> Keys
        {
            get { return _keys; }
            set { _keys = value; }
        }

        #endregion

        #region CONSTRUCTORS

        public Treasure(int numberOfItems)
        {
            _numItems = numberOfItems;
        }

        #endregion

        #region METHODS

        public void GenerateItems()
        {
            Random rand = new Random();
            string name;
            int quality;
            bool isShiny;
            List<string> _nameList = new List<string> { "Lucky Medallion", "A Rock", "Gold Coin", "Rusty Spork", "Greatsword of Slaying", "A Twig" };

            for (int i = 0; i < 20; i++)
            {
                name = _nameList[rand.Next(_nameList.Count)];
                quality = rand.Next(3);

                if (rand.Next(0, 2) == 0)
                {
                    isShiny = false;
                }
                else
                {
                    isShiny = true;
                }

                _genItems.Add(new TreasureItem(name, quality, isShiny));
            }

            _keys.Add(new TreasureItem("Beholder's Key", 4, true));
        }

        public void PopulateContainer()
        {

            Random rand = new Random();

            for (int i = 0; i < _numItems; i++)
            {
                _heldItems.Add(_genItems[rand.Next(20)]);
            }
        }

        public List<TreasureItem> OpenContainer(TreasureItem Key = null)
        {
            if(Key != null)
            {
                return _heldItems;
            }
            else
            {
                return null;
            }
        }

        #endregion

    }
}
