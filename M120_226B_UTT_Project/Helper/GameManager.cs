using System.Collections.Generic;

namespace M120_226B_UTT_Project.Helper {
    /// <summary>
    /// Static Helper Class with Information about the Game
    /// </summary>
    public static class GameManager {
        /// <summary>
        /// Static Property declaring the Player who may Play next.
        /// </summary>
        public static Turn Turn {
            get {
                return _Turn;
            }
            set {
                _Turn = value;
                NotifyObservers("Turn");
            }
        }
        private static Turn _Turn;

        /// <summary>
        /// Setup GameManager, needs to be called for GameManager to declare some stuff
        /// </summary>
        public static void SetUp() {
            Observers = new List<IObserver>();
            _CompletedFields = new List<int>();
            LastMovePostion = 10;
        }
        /// <summary>
        /// For Restarting a Game, Resets the Completed Fields
        /// </summary>
        public static void Restart() {
            _CompletedFields = new List<int>();
            LastMovePostion = 10;
        }

        /// <summary>
        /// The Postition(Index) of the Last played field, if 10 everywhere Playable
        /// </summary>
        public static int LastMovePostion {
            get {
                return _LastMovePosition;
            }
            set {
                if (_CompletedFields.Contains(value)) {
                    _LastMovePosition = 10;
                }
                else {
                    _LastMovePosition = value;
                }
                NotifyObservers("LastMovePosition");
            }
        }
        private static int _LastMovePosition;

        /// <summary>
        /// Register Completed Fields to GameManager
        /// </summary>
        public static int CompletedField {
            set {
                _CompletedFields.Add(value);
            }
        }
        private static List<int> _CompletedFields;

        #region ObserverLogic
        private static void NotifyObservers(string propertyName) {
            foreach (IObserver observer in Observers) {
                observer.ExecuteOnUpdate(propertyName);
            }
        }
        private static List<IObserver> Observers;
        public static void Subscribe(IObserver toAdd) {
            if (!Observers.Contains(toAdd)) {
                Observers.Add(toAdd);
            }
        }
        public static void Unsubscribe(IObserver toRemove) {
            if (Observers.Contains(toRemove)) {
                Observers.Remove(toRemove);
            }
        }
        #endregion


    }
}
