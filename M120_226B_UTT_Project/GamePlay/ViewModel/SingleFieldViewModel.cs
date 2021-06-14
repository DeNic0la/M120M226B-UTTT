﻿using M120_226B_UTT_Project.GamePlay.Model;
using M120_226B_UTT_Project.Helper;
using System.Windows.Input;

namespace M120_226B_UTT_Project
{
    public class SingleFieldViewModel : ObservableObject
    {
        private FieldState _fieldState;
        private SingleFieldModel _Model;
        public bool FieldIsX
        {
            get
            {
                return _fieldState == FieldState.X;
            }
            set
            {
                if (value == true && _fieldState != FieldState.X)
                {
                    _fieldState = FieldState.X;
                    _Model.FieldState = _fieldState;
                    RaisePropertyChanged("FieldIsX");
                }
            }
        }
        public bool FieldIsO
        {
            get
            {
                return _fieldState == FieldState.O;
            }
            set
            {
                if (value == true && _fieldState != FieldState.O)
                {
                    _fieldState = FieldState.O;
                    _Model.FieldState = _fieldState;
                    RaisePropertyChanged("FieldIsO");
                }
            }
        }
        public bool FieldIsEmpty
        {
            get
            {
                return _fieldState == FieldState.Empty;
            }
            set
            {
                if (value == true && _fieldState != FieldState.Empty)
                {
                    _fieldState = FieldState.Empty;
                    _Model.FieldState = _fieldState;
                    RaisePropertyChanged("FieldIsEmpty");
                }
            }
        }
        private int ownPostion;
        private int parentPosition;
        public SingleFieldViewModel(SingleFieldModel model, int fieldPosition, int parentPosition)
        {
            ownPostion = fieldPosition;
            _fieldState = model.FieldState;

            model.PropertyChanged += Model_PropertyChanged;

            _Model = model;

            this.parentPosition = parentPosition;

            FieldClickCommand = new RelayCommand(command => fieldClick(_Model));


        }
        private ICommand _FieldClickCommand;
        public ICommand FieldClickCommand
        {
            get
            {
                return _FieldClickCommand;
            }
            set
            {
                _FieldClickCommand = value;
                RaisePropertyChanged("FieldClickCommand");
            }
        }



        public void fieldClick(SingleFieldModel field)
        {
            if (GameManager.LastMovePostion != 10)
            {
                if (GameManager.LastMovePostion != parentPosition)
                {
                    //MessageBox.Show("LastMovePosition:"+GameManager.LastMovePostion+"\nParentPosition:"+parentPosition+"\nOwnPosition:"+ownPostion);
                    return;
                }
            }
            if (GameManager.Turn == Turn.X)
            {
                field.FieldState = FieldState.X;
                GameManager.Turn = Turn.O;
                GameManager.LastMovePostion = ownPostion;

            }
            else if (GameManager.Turn == Turn.O)
            {
                field.FieldState = FieldState.O;
                GameManager.Turn = Turn.X;
                GameManager.LastMovePostion = ownPostion;
            }

        }

        private void Model_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (_Model.FieldState != _fieldState)
            {
                _fieldState = _Model.FieldState;
                RaisePropertyChanged("FieldIsEmpty");
                RaisePropertyChanged("FieldIsO");
                RaisePropertyChanged("FieldIsX");
            }

        }
    }
}