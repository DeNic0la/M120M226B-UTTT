using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M120_226B_UTT_Project {
    public class UltimateFieldViewModel : ObservableObject {
        private BasicFieldViewModel[] SubViewModels;
        public BasicFieldViewModel SubModel1 {
            get {
                return SubViewModels[0];
            }
        }
        public BasicFieldViewModel SubModel2 {
            get {
                return SubViewModels[1];
            }
        }
        public BasicFieldViewModel SubModel3 {
            get {
                return SubViewModels[2];
            }
        }
        public BasicFieldViewModel SubModel4 {
            get {
                return SubViewModels[3];
            }
        }
        public BasicFieldViewModel SubModel5 {
            get {
                return SubViewModels[4];
            }
        }
        public BasicFieldViewModel SubModel6 {
            get {
                return SubViewModels[0];
            }
        }
        public BasicFieldViewModel SubModel7 {
            get {
                return SubViewModels[0];
            }
        }
        public BasicFieldViewModel SubModel8 {
            get {
                return SubViewModels[0];
            }
        }
        public BasicFieldViewModel SubModel9 {
            get {
                return SubViewModels[0];
            }
        }


        public UltimateFieldViewModel(BasicFieldModel fieldModel, GameSetupViewModel setupData) {
            SubViewModels = new BasicFieldViewModel[9];
            for (int i = 0; i < fieldModel.Fields.Length; i++) {
                SubViewModels[i] = new BasicFieldViewModel((BasicFieldModel)fieldModel.Fields[i]);
            }


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

        protected string _PlayerX;
        protected string _PlayerO;

        protected int _ScoreX;
        protected int _ScoreO;

        protected int _BotLevel;

        protected Turn _CurrentTurn;

        public string PlayerXDisplay {
            get {
                return "TEST";
            }
        }

    }
}
