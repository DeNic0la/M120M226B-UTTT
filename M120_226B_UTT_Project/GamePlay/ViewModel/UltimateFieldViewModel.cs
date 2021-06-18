using M120_226B_UTT_Project.GamePlay.Model;
using M120_226B_UTT_Project.GameSetup.ViewModel;
using M120_226B_UTT_Project.Helper;
using System.Threading;
using System.Windows;
using System.Windows.Media;

namespace M120_226B_UTT_Project.GamePlay.ViewModel {
    public class UltimateFieldViewModel : ObservableObject, IObserver {

        #region SubViewModels
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
                return SubViewModels[5];
            }
        }
        public BasicFieldViewModel SubModel7 {
            get {
                return SubViewModels[6];
            }
        }
        public BasicFieldViewModel SubModel8 {
            get {
                return SubViewModels[7];
            }
        }
        public BasicFieldViewModel SubModel9 {
            get {
                return SubViewModels[8];
            }
        }
        #endregion

        #region DisplayPropertys
        public string PlayerXDisplay {
            get {
                return "Spieler: " + _PlayerX + " (X)";
            }
        }
        public string PlayerODisplay {
            get {
                return "Spieler: " + _PlayerO + " (O)";
            }
        }
        public string MoveTextDisplay {
            get {
                return "Der Spieler " + (GameManager.Turn == Turn.X ? _PlayerX + " (X)" : _PlayerO + " (O)") + " ist am Zug.";
            }
        }
        public string ScoreXDisplay {
            get {
                return "X: " + _ScoreX;
            }
        }
        public string ScoreODisplay {
            get {
                return "O: " + _ScoreO;
            }
        }

        public SolidColorBrush BackgroundPlayerX {
            get {
                return GameManager.Turn == Turn.X ? selectedColor : defaultColor;
            }

        }
        public SolidColorBrush BackgroundPlayerO {
            get {
                return GameManager.Turn == Turn.O ? selectedColor : defaultColor;
            }

        }
        #endregion

        #region PrivateValuesForProperty
        private string _PlayerX;
        private string _PlayerO;

        private int _ScoreX;
        private int _ScoreO;

        private BasicFieldModel fieldModel;

        //private int _BotLevel; Bot is Disabled

        private SolidColorBrush defaultColor = new SolidColorBrush(Color.FromRgb(215, 215, 215));
        private SolidColorBrush selectedColor = new SolidColorBrush(Color.FromRgb(40, 226, 83));
        #endregion



        public UltimateFieldViewModel(BasicFieldModel fieldModel, GameSetupViewModel setupData) {

            #region GameManagerSetup
            GameManager.SetUp();
            GameManager.Subscribe(this);
            GameManager.Turn = setupData.First_X ? Turn.X : Turn.O;
            #endregion

            SubViewModels = new BasicFieldViewModel[9];
            for (int i = 0; i < fieldModel.Fields.Length; i++) {
                SubViewModels[i] = new BasicFieldViewModel((BasicFieldModel)fieldModel.Fields[i], i);
            }


            _PlayerX = setupData.PlayerXName;
            if (setupData.Enemy_Player) {
                _PlayerO = setupData.PlayerOName;
            }/* Bot is Disabled
            else if (setupData.Enemy_Bot) {
                _BotLevel = setupData.BotDifficulty;
            }*/

            _ScoreX = 0;
            _ScoreO = 0;

            fieldModel.PropertyChanged += FieldModel_PropertyChanged;
            this.fieldModel = fieldModel;
        }

        #region EventHandlers
        private void FieldModel_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e) {
            if (e.PropertyName == "FieldState") {

                Thread.Sleep(100);//Wait for Gui to Display

                if (fieldModel.FieldState == FieldState.X) {
                    _ScoreX++;
                    MessageBox.Show("X Hat gewonnen");

                }
                else if (fieldModel.FieldState == FieldState.O) {
                    _ScoreO++;
                    MessageBox.Show("O Hat gewonnen");
                }
                else if (fieldModel.FieldState == FieldState.Tie) {
                    MessageBox.Show("Es steht unentschieden");
                }

                Thread resetField = new Thread(() => //Somehow Updating the Data for the View works great in a Thread
                {
                    fieldModel.reset();
                    GameManager.Restart();
                    GameManager.LastMovePostion = 10;
                    foreach (BasicFieldViewModel bfvm in SubViewModels) {
                        bfvm.ExecuteOnUpdate("LastMovePosition");
                    }

                });
                resetField.Start();

                RaisePropertyChanged("ScoreXDisplay");
                RaisePropertyChanged("ScoreODisplay");
            }
        }

        public void ExecuteOnUpdate(string propertyName) {
            if (propertyName == "Turn") {
                RaisePropertyChanged("MoveTextDisplay");
                RaisePropertyChanged("BackgroundPlayerO");
                RaisePropertyChanged("BackgroundPlayerX");
            }
        }
        #endregion

    }
}
