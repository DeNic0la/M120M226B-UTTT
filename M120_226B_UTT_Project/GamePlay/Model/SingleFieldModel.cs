using M120_226B_UTT_Project.Helper;

namespace M120_226B_UTT_Project.GamePlay.Model
{
    public class SingleFieldModel : ObservableObject, IField
    {
        public SingleFieldModel()
        {
            _FieldState = FieldState.Empty;
            //Postion = postition; //Probably not needed
        }
        private FieldState _FieldState;

        public FieldState FieldState
        {
            get
            {
                return _FieldState;
            }
            set
            {
                _FieldState = value;
                RaisePropertyChanged("FieldState");
            }
        }
        //public int Postion { get; } //Probably not needed

    }
}
