﻿using M120_226B_UTT_Project.Helper;


namespace M120_226B_UTT_Project.GamePlay.Model {
    public class BasicFieldModel : ObservableObject, IField {

        #region PrivateFields
        private IField[] _Fields;
        private FieldState _FieldState;
        private int _EmptySubFields;
        #endregion

        #region PublicDataFields
        public IField[] Fields {
            get {
                return _Fields;
            }
        }

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
        #endregion

        /// <summary>
        /// Field Model for Field with SubFields
        /// </summary>
        /// <param name="isUltimate">If True the SubFields will be BasicFields(containing SingleFields)</param>
        public BasicFieldModel(bool isUltimate = false) {

            _EmptySubFields = 9;

            if (isUltimate) {
                _Fields = new BasicFieldModel[9];
                for (int i = 0; i < 9; i++) {
                    BasicFieldModel subFieldModel = new BasicFieldModel();
                    subFieldModel.PropertyChanged += SingleFieldModel_PropertyChanged;
                    _Fields[i] = subFieldModel;
                }
            }
            else {
                _Fields = new SingleFieldModel[9];
                for (int i = 0; i < 9; i++) {
                    SingleFieldModel subFieldModel = new SingleFieldModel();
                    subFieldModel.Parent = this;
                    subFieldModel.PropertyChanged += SingleFieldModel_PropertyChanged;
                    _Fields[i] = subFieldModel;
                }
            }

            _FieldState = FieldState.Empty;

        }



        private void SingleFieldModel_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e) {
            if (e.PropertyName == "FieldState") {
                _EmptySubFields--;
            }
            if (_EmptySubFields <= 6 && _FieldState == FieldState.Empty) {
                FieldState before = _FieldState;
                _FieldState = Validator.ValidateFieldState(_Fields);
                if (_EmptySubFields == 0 && _FieldState == FieldState.Empty) {
                    _FieldState = FieldState.Tie;
                }
                if (before != _FieldState) {
                    RaisePropertyChanged("FieldState");
                }
            }
        }

        public void reset() {

            foreach (IField subComponent in Fields) {
                subComponent.reset();
            }
            _FieldState = FieldState.Empty;
            _EmptySubFields = 9;
            RaisePropertyChanged("FieldReset");

        }

    }
}
