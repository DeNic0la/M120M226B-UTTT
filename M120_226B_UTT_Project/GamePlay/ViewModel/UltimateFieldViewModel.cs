using M120_226B_UTT_Project.GamePlay.Model;
using M120_226B_UTT_Project.GameSetup.ViewModel;
using M120_226B_UTT_Project.Helper;
using System.Windows;
using System.Windows.Media;

namespace M120_226B_UTT_Project.GamePlay.ViewModel
{
    public class UltimateFieldViewModel : ObservableObject, IObserver
    {
        private BasicFieldViewModel[] SubViewModels;
        public BasicFieldViewModel SubModel1
        {
            get
            {
                return SubViewModels[0];
            }
        }
        public BasicFieldViewModel SubModel2
        {
            get
            {
                return SubViewModels[1];
            }
        }
        public BasicFieldViewModel SubModel3
        {
            get
            {
                return SubViewModels[2];
            }
        }
        public BasicFieldViewModel SubModel4
        {
            get
            {
                return SubViewModels[3];
            }
        }
        public BasicFieldViewModel SubModel5
        {
            get
            {
                return SubViewModels[4];
            }
        }
        public BasicFieldViewModel SubModel6
        {
            get
            {
                return SubViewModels[5];
            }
        }
        public BasicFieldViewModel SubModel7
        {
            get
            {
                return SubViewModels[6];
            }
        }
        public BasicFieldViewModel SubModel8
        {
            get
            {
                return SubViewModels[7];
            }
        }
        public BasicFieldViewModel SubModel9
        {
            get
            {
                return SubViewModels[8];
            }
        }

        private BasicFieldModel fieldModel;
        public UltimateFieldViewModel(BasicFieldModel fieldModel, GameSetupViewModel setupData)
        {
            GameManager.SetUp();
            GameManager.Subscribe(this);
            SubViewModels = new BasicFieldViewModel[9];
            for (int i = 0; i < fieldModel.Fields.Length; i++)
            {
                SubViewModels[i] = new BasicFieldViewModel((BasicFieldModel)fieldModel.Fields[i], i);
            }


            _PlayerX = setupData.PlayerXName;
            if (setupData.Enemy_Player)
            {
                _PlayerO = setupData.PlayerOName;
            }
            else if (setupData.Enemy_Bot)
            {
                _BotLevel = setupData.BotDifficulty;
            }

            _ScoreX = 0;
            _ScoreO = 0;

            GameManager.Turn = setupData.First_X ? Turn.X : Turn.O;
            GameManager.LastMovePostion = 10;

            fieldModel.PropertyChanged += FieldModel_PropertyChanged;
            this.fieldModel = fieldModel;


        }

        private void FieldModel_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "FieldState")
            {
                //TODO Check For Win and Update Stats
                if (fieldModel.FieldState == FieldState.X)
                {
                    _ScoreX++;
                    MessageBox.Show("X Hat gewonnen");
                }
                else if (fieldModel.FieldState == FieldState.O)
                {
                    _ScoreO++;
                    MessageBox.Show("O Hat gewonnen");
                }
                else if (fieldModel.FieldState == FieldState.Tie)
                {
                    MessageBox.Show("Es steht unentschieden");
                }
            }
        }

        public void ExecuteOnUpdate(string propertyName)
        {
            if (propertyName == "Turn")
            {
                RaisePropertyChanged("MoveTextDisplay");
                RaisePropertyChanged("BackgroundPlayerO");
                RaisePropertyChanged("BackgroundPlayerX");
            }
        }

        protected string _PlayerX;
        protected string _PlayerO;

        protected int _ScoreX;
        protected int _ScoreO;

        protected int _BotLevel;


        public string PlayerXDisplay
        {
            get
            {
                return "Spieler: " + _PlayerX + " (X)";
            }
        }
        public string PlayerODisplay
        {
            get
            {
                return "Spieler: " + _PlayerO + " (O)";
            }
        }
        public string MoveTextDisplay
        {
            get
            {
                return "Der Spieler " + (GameManager.Turn == Turn.X ? _PlayerX + " (X)" : _PlayerO + " (O)") + " ist am Zug.";
            }
        }
        public string ScoreXDisplay
        {
            get
            {
                return "X: " + _ScoreX;
            }
        }
        public string ScoreODisplay
        {
            get
            {
                return "O: " + _ScoreO;
            }
        }
        private SolidColorBrush defaultColor = new SolidColorBrush(Color.FromRgb(215, 215, 215));
        private SolidColorBrush selectedColor = new SolidColorBrush(Color.FromRgb(40, 226, 83));

        public SolidColorBrush BackgroundPlayerX
        {
            get
            {
                return GameManager.Turn == Turn.X ? selectedColor : defaultColor;
            }

        }
        public SolidColorBrush BackgroundPlayerO
        {
            get
            {
                return GameManager.Turn == Turn.O ? selectedColor : defaultColor;
            }

        }

    }
}
