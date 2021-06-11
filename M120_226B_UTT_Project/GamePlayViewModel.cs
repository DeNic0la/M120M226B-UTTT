using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M120_226B_UTT_Project {
    public class GamePlayViewModel : ObservableObject {
        protected string _PlayerX;
        protected string _PlayerO;

        protected int _ScoreX;
        protected int _ScoreO;

        protected int _BotLevel;

        public enum Turn {
            X,
            O,
        }

        protected Turn _CurrentTurn;

        public GamePlayViewModel(GameSetupViewModel setupData) {
            _PlayerX = setupData.PlayerXName;
            if (setupData.Enemy_Player) {
                _PlayerO = setupData.PlayerOName;
            }
            else if (setupData.Enemy_Bot) {
                _BotLevel = setupData.BotDifficulty;
            }

            _ScoreX = 0;
            _ScoreO = 0;

            _CurrentTurn = setupData.First_X ? Turn.X : Turn.O;







        }
    }
}
