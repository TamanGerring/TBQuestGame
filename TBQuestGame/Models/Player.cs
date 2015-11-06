using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TBQuestGame
{
    public class Player : Models.Character
    {
        public enum ActionChoice
        {
            None,
            QuitGame,
            Move
        }

        private int _actionCount = Enum.GetNames(typeof(ActionChoice)).Length;

        public int ActionCount
        {
            get { return _actionCount; }
        }
    }
}
