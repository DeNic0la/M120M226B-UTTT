using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M120_226B_UTT_Project {
    public class BasicFieldModel : ObservableObject, IField {

        private SingleFieldModel[] _Fields;
        private FieldState _FieldState;
        private int _EmptySubFields;

        public BasicFieldModel() {
            _EmptySubFields = 9;
            _Fields = new SingleFieldModel[9];
            for (int i = 0; i < 9; i++) {
                SingleFieldModel singleFieldModel = new SingleFieldModel();
                singleFieldModel.PropertyChanged += SingleFieldModel_PropertyChanged;
                _Fields[i] = singleFieldModel;
            }
            _FieldState = FieldState.Empty;

        }


        public FieldState FieldState {
            get {
                return _FieldState;
            }
            set {
                _FieldState = value;
                RaisePropertyChanged("FieldState");
            }
        }

        private void SingleFieldModel_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e) {
            //Check if FieldStateStillNeedsToBeEmptry
            //SingleFieldModel sfm = (SingleFieldModel)sender;
            /*try { //Activate if Errors are thrown 
                sfm = (SingleFieldModel)sender;
            }
            catch (Exception ignored) {
                return
            }*/
            if (e.PropertyName == "FieldState") {
                _EmptySubFields--;
            }
            if (_EmptySubFields <= 6) {
                _FieldState = Helper.ValidateFieldState(_Fields);
                if (_EmptySubFields == 0 && _FieldState == FieldState.Empty) {
                    _FieldState = FieldState.Tie;
                }
            }
        }
    }
}
