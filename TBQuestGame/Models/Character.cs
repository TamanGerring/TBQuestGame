using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TBQuestGame.Models
{
    public class Character
    {
        #region ENUMERABLES

        public enum GenderType
        {
            Male,
            Female
        }

        public enum RaceType
        {
            Human,
            Elf,
            Dwarf,
            Goblin
        } 

        #endregion
        
        #region FIELDS

        private string _name;
        private GenderType _gender;
        private RaceType _race;
        private int _caveNumber;
        private int _lives;
        private int _charLevel;
        
        #endregion

        #region PROPERTIES
        //Character's Name
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        // Character's Gender
        public GenderType Gender
        {
            get { return _gender; }
            set { _gender = value; }
        }
        //Character's Race
        public RaceType Race
        {
            get { return _race; }
            set { _race = value; }
        }
        //Character's Location
        public int CaveNumber
        {
            get { return _caveNumber; }
            set { _caveNumber = value; }
        }
        //Character's Health
        public int Lives
        {
            get { return _lives; }
            set { _lives = value; }
        }
        //Character's Level
        public int CharLevel
        {
            get { return _charLevel; }
            set { _charLevel = value; }
        }

        #endregion

        #region CONSTRUCTORS

        public Character()
        {
            
        }

        #endregion

        #region METHODS

        #endregion

    }
}
