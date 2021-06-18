using M120_226B_UTT_Project.GamePlay.View;
using M120_226B_UTT_Project.Helper;
using M120_226B_UTT_Project.GameSetup.View;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;

namespace M120_226B_UTT_Project.GameSetup.ViewModel {
    public class GameSetupViewModel : ObservableObject {

        private GameSetupWindow windowForClosing;

        #region DisplayProperty

        public bool First_X {
            get { return _FirstMove == 1; }
            set {
                if (value) {
                    _FirstMove = 1;
                    RaisePropertyChanged("First_X");
                    RaisePropertyChanged("First_O");
                }

            }
        }
        public bool First_O {
            get { return _FirstMove == 2; }
            set {
                if (value) {
                    _FirstMove = 2;
                    RaisePropertyChanged("First_X");
                    RaisePropertyChanged("First_O");
                }

            }
        }
        /// <summary>
        /// Which Player may make the first Move
        /// <para>0 => Undefinded</para>
        /// <para>1 => PlayerX</para>
        /// <para>2 => PlayerO</para>
        /// </summary>
        private int _FirstMove = 0;


        /// <summary>
        /// Name of Player X as String
        /// </summary>
        public string PlayerXName {
            get { return _PlayerX; }
            set {
                _PlayerX = value;
                RaisePropertyChanged("PlayerXName");
            }
        }
        private string _PlayerX = "";

        /// <summary>
        /// Name of Player O as String
        /// </summary>
        public string PlayerOName {
            get { return _PlayerO; }
            set {
                _PlayerO = value;
                RaisePropertyChanged("PlayerOName");
            }
        }
        private string _PlayerO = "";



        public bool Enemy_Default {
            get { return _EnemyPlayer == 0; }
        }
        public bool Enemy_Bot {
            get { return _EnemyPlayer == 1; }
            set {
                if (value) {
                    _EnemyPlayer = 1;
                    RaisePropertyChanged("Enemy_Player");
                    RaisePropertyChanged("Enemy_Bot");
                }

            }
        }
        public bool Enemy_Player {
            get { return _EnemyPlayer == 2; }
            set {
                if (value) {
                    _EnemyPlayer = 2;
                    RaisePropertyChanged("Enemy_Player");
                    RaisePropertyChanged("Enemy_Bot");

                }
            }
        }
        /// <summary>
        /// Selected Enemy Player
        /// <para>0 => Nothing Selected,</para>
        /// <para>1 => Enemy is Bot,</para>
        /// <para>2 => Enemy is Player</para>
        /// </summary>
        private int _EnemyPlayer = 2; // Bot Disabled, Default Player



        #endregion

        public GameSetupViewModel(GameSetupWindow windowToClose) {
            windowForClosing = windowToClose;
            StartGameCommand = new RelayCommand(command => StartGameButtonClick("StartGameButton"));
        }

        #region Disabled
        /*
         Virtual PropertyBoolean for Bot Difficulty
         */
        // Bot is Disabled (Code Disabled)
        /*
        private int _BotDifficulty = 0;
        public int BotDifficulty {
            get { return _BotDifficulty; }
        }


        public bool Bot_Level1 {
            get { return _BotDifficulty == 1; }
            set {
                if (value) {
                    _BotDifficulty = 1;
                    RaisePropertyChanged("Bot_Level1");
                    RaisePropertyChanged("Bot_Level2");
                    RaisePropertyChanged("Bot_Level3");
                }

            }
        }
        public bool Bot_Level2 {
            get { return _BotDifficulty == 2; }
            set {
                if (value) {
                    _BotDifficulty = 2;
                    RaisePropertyChanged("Bot_Level1");
                    RaisePropertyChanged("Bot_Level2");
                    RaisePropertyChanged("Bot_Level3");
                }

            }
        }
        public bool Bot_Level3 {
            get { return _BotDifficulty == 3; }
            set {
                if (value) {
                    _BotDifficulty = 3;
                    RaisePropertyChanged("Bot_Level1");
                    RaisePropertyChanged("Bot_Level2");
                    RaisePropertyChanged("Bot_Level3");
                }

            }
        }*/
        #endregion


        public ICommand StartGameCommand { get; set; }

        private void StartGameButtonClick(object sender) {
            if (IsValidData()) {

                // Pass Data To Game Window Here
                GameWindow gameWindow = new GameWindow(this);
                gameWindow.Show();

                //Close Current Windows, Setup is Complete
                windowForClosing.Close();
            }


        }

        private bool IsValidData() {
            List<string> errors = new List<string>();
            if (_PlayerX.Length < 1) {
                errors.Add("Der Name des Spieler X ist nicht gültig");
            }

            if (_FirstMove == 0) {
                _FirstMove = 1;
                RaisePropertyChanged("First_X");
            }
            if (_EnemyPlayer == 0) {
                errors.Add("Wählen Sie Ihren Gegner aus");
            }
            // Bot is Disabled (Code Disabled)
            /*else if (_EnemyPlayer == 1)
            {// Gegner ist Bot
                if (_BotDifficulty == 0)
                {
                    errors.Add("Wählen Sie eine Schwirigkeitsstufe für den Bot an");
                }
            }*/
            else if (_EnemyPlayer == 2) {// Gegner ist Spieler
                if (PlayerOName.Length < 1) {
                    errors.Add("Der Name des Spieler O ist nicht gültig");
                }
            }
            if (errors.Count > 0) {
                MessageBox.Show("Es sind folgende Fehler aufgetreten: \n" + string.Join("\n", errors));
                return false;
            }
            else {
                return true;
            }
        }


    }
}
