﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M120_226B_UTT_Project.Helper
{
    public static class GameManager
    {
        public static Turn Turn;
        public static void SetUp()
        {
            Observers = new List<IObserver>();
            _CompletedFields = new List<int>();
        }
        public static int LastMovePostion
        {
            get
            {
                return _LastMovePosition;
            }
            set
            {
                if (_CompletedFields.Contains(value))
                {
                    _LastMovePosition = 10;
                }
                else
                {
                    _LastMovePosition = value;
                }
                notifyObservers("LastMovePosition");
            }
        }
        private static void notifyObservers(string propertyName)
        {
            foreach(IObserver observer in Observers)
            {
                observer.ExecuteOnUpdate(propertyName);
            }
        }
        private static List<IObserver> Observers;
        public static void Subscribe(IObserver toAdd)
        {
            if (!Observers.Contains(toAdd))
            {
                Observers.Add(toAdd);
            }
        }
        public static void Unsubscribe(IObserver toRemove)
        {
            if (Observers.Contains(toRemove))
            {
                Observers.Remove(toRemove);
            }
        }
        private static int _LastMovePosition;
        private static List<int> _CompletedFields;
        public static int CompletedField
        {
            set
            {
                _CompletedFields.Add(value);
            }
        }

    }
}
