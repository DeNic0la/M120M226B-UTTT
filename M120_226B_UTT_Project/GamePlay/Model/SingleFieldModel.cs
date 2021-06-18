using M120_226B_UTT_Project.Helper;

namespace M120_226B_UTT_Project.GamePlay.Model {
    public class SingleFieldModel : ObservableObject, IField {

        public BasicFieldModel Parent;
        public SingleFieldModel() {
            _FieldState = FieldState.Empty;

        }
        private FieldState _FieldState;

        /// <summary>
        /// The Status of the Field (if it belongs to a Player)
        /// </summary>
        public FieldState FieldState {
            get {
                return _FieldState;
            }
            set {
                _FieldState = value;
                RaisePropertyChanged("FieldState");
            }
        }

        public void reset() {
            FieldState = FieldState.Empty;
        }



    }
}
