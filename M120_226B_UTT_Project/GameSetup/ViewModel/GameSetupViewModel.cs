using M120_226B_UTT_Project.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using M120_226B_UTT_Project.GamePlay.View;

namespace M120_226B_UTT_Project.GameSetup.ViewModel
{
    public class GameSetupViewModel : ObservableObject
    {
        GameSetupWindow windowForClosing;
        public GameSetupViewModel(GameSetupWindow windowToClose)
        {
            windowForClosing = windowToClose;
            StartGameCommand = new RelayCommand(command => StartGameButtonClick("StartGameButton"));
        }

        private string _PlayerX = "";
        public string PlayerXName
        {
            get { return _PlayerX; }
            set
            {
                _PlayerX = value;
                RaisePropertyChanged("PlayerXName");
            }
        }
        private string _PlayerO = "";
        public string PlayerOName
        {
            get { return _PlayerO; }
            set
            {
                _PlayerO = value;
                RaisePropertyChanged("PlayerOName");
            }
        }


        /*
         This Booleans are Virtual Properties acording to the Int.
            Only One of the RadioButtons can be active so:
        _EnemyPlayer = 0 => NoRadio Button Selected
        _EnemyPlayer = 1 => Enemy is Bot
        _EnemyPlayer = 2 => Enemy is Player
         */
        private int _EnemyPlayer = 0;

        public bool Enemy_Default
        {
            get { return _EnemyPlayer == 0; }
        }
        public bool Enemy_Bot
        {
            get { return _EnemyPlayer == 1; }
            set
            {
                if (value)
                {
                    _EnemyPlayer = 1;
                    RaisePropertyChanged("Enemy_Player");
                    RaisePropertyChanged("Enemy_Bot");
                }

            }
        }
        public bool Enemy_Player
        {
            get { return _EnemyPlayer == 2; }
            set
            {
                if (value)
                {
                    _EnemyPlayer = 2;
                    RaisePropertyChanged("Enemy_Player");
                    RaisePropertyChanged("Enemy_Bot");

                }
            }
        }

        /*
         Virtual PropertyBoolean for Bot Difficulty
         */
        private int _BotDifficulty = 0;
        public int BotDifficulty
        {
            get { return _BotDifficulty; }
        }


        public bool Bot_Level1
        {
            get { return _BotDifficulty == 1; }
            set
            {
                if (value)
                {
                    _BotDifficulty = 1;
                    RaisePropertyChanged("Bot_Level1");
                    RaisePropertyChanged("Bot_Level2");
                    RaisePropertyChanged("Bot_Level3");
                }

            }
        }
        public bool Bot_Level2
        {
            get { return _BotDifficulty == 2; }
            set
            {
                if (value)
                {
                    _BotDifficulty = 2;
                    RaisePropertyChanged("Bot_Level1");
                    RaisePropertyChanged("Bot_Level2");
                    RaisePropertyChanged("Bot_Level3");
                }

            }
        }
        public bool Bot_Level3
        {
            get { return _BotDifficulty == 3; }
            set
            {
                if (value)
                {
                    _BotDifficulty = 3;
                    RaisePropertyChanged("Bot_Level1");
                    RaisePropertyChanged("Bot_Level2");
                    RaisePropertyChanged("Bot_Level3");
                }

            }
        }

        /*
         Virtual PropertyBoolean first Move
         */

        private int _FirstMove = 0;

        public bool First_X
        {
            get { return _FirstMove == 1; }
            set
            {
                if (value)
                {
                    _FirstMove = 1;
                    RaisePropertyChanged("First_X");
                    RaisePropertyChanged("First_O");
                }

            }
        }
        public bool First_O
        {
            get { return _FirstMove == 2; }
            set
            {
                if (value)
                {
                    _FirstMove = 2;
                    RaisePropertyChanged("First_X");
                    RaisePropertyChanged("First_O");
                }

            }
        }


        public ICommand StartGameCommand { get; set; }

        private void StartGameButtonClick(object sender)
        {
            if (IsValidData())
            {

                // Pass Data To Game Window Here
                GameWindow gameWindow = new GameWindow(this);
                gameWindow.Show();

                //Close Current Windows, Setup is Complete
                windowForClosing.Close();
            }


        }

        private bool IsValidData()
        {
            List<string> errors = new List<string>();
            if (_PlayerX.Length < 1)
                errors.Add("Der Name des Spieler X ist nicht gültig");
            if (_FirstMove == 0)
            {
                _FirstMove = 1;
                RaisePropertyChanged("First_X");
            }
            if (_EnemyPlayer == 0)
            {
                errors.Add("Wählen Sie Ihren Gegner aus");
            }
            else if (_EnemyPlayer == 1)
            {// Gegner ist Bot
                if (_BotDifficulty == 0)
                {
                    errors.Add("Wählen Sie eine Schwirigkeitsstufe für den Bot an");
                }
            }
            else if (_EnemyPlayer == 2)
            {// Gegner ist Spieler
                if (PlayerOName.Length < 1)
                {
                    errors.Add("Der Name des Spieler O ist nicht gültig");
                }
            }
            if (errors.Count > 0)
            {
                MessageBox.Show("Es sind folgende Fehler aufgetreten: \n" + string.Join("\n", errors));
                return false;
            }
            else
                return true;
        }


    }
}
