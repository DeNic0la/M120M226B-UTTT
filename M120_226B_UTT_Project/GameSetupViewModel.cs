using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M120_226B_UTT_Project {
    class GameSetupViewModel {
        public string PlayerXName = "";
        public string PlayerOName = "";

        /*
         This Booleans are Virtual Properties acording to the Int.
            Only One of the RadioButtons can be active so:
        _EnemyPlayer = 0 => NoRadio Button Selected
        _EnemyPlayer = 1 => Enemy is Bot
        _EnemyPlayer = 2 => Enemy is Player
         */
        private int _EnemyPlayer = 0;

        public bool Enemy_Default {
            get { return _EnemyPlayer == 0; }
        }
        public bool Enemy_Bot {
            get { return _EnemyPlayer == 1; }
            set {
                if (value)
                    _EnemyPlayer = 1;

            }
        }
        public bool Enemy_Player {
            get { return _EnemyPlayer == 2; }
            set {
                if (value)
                    _EnemyPlayer = 2;
            }
        }

        /*
         Virtual PropertyBoolean for Bot Difficulty
         */
        private int _BotDifficulty = 0;


        public bool Bot_Level1 {
            get { return _BotDifficulty == 1; }
            set {
                if (value)
                    _BotDifficulty = 1;
            }
        }
        public bool Bot_Level2 {
            get { return _BotDifficulty == 2; }
            set {
                if (value)
                    _BotDifficulty = 2;
            }
        }
        public bool Bot_Level3 {
            get { return _BotDifficulty == 3; }
            set {
                if (value)
                    _BotDifficulty = 3;
            }
        }

        /*
         Virtual PropertyBoolean first Move
         */

        private int _FirstMove = 0;

        public bool First_X {
            get { return _FirstMove == 1; }
            set {
                if (value)
                    _FirstMove = 1;
            }
        }
        public bool First_O {
            get { return _FirstMove == 2; }
            set {
                if (value)
                    _FirstMove = 2;
            }
        }


    }
}
