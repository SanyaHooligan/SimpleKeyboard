using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleKeyboard
{
    public enum KeyboardCurrentState { eng, rus, symb }
    public class SimpleKeyboardViewModel : INotifyPropertyChanged
    {
        public SimpleKeyboardViewModel()
        {
            TopKeys = RusTopKeys;
            MiddleKeys = RusMiddleKeys;
            BottomKeys = RusBottomKeys;
            CurrentState = KeyboardCurrentState.rus;
            PreviousState = KeyboardCurrentState.rus;
            Visibility = "Visible";
            ChangeKeyboard();
        }

        public ObservableCollection<String> NumberKeys
        {
            get { return new ObservableCollection<string>() { "1", "2", "3", "4", "5", "6", "7", "8", "9", "0" }; }
        }

        public ObservableCollection<String> SymbolMiddleKeys
        {
            get { return new ObservableCollection<string>() { "@", "#", "$", "%", "&", "*", "(", ")", "-", "+", "=" }; }
        }

        public ObservableCollection<String> SymbolBottomKeys
        {
            get { return new ObservableCollection<string>() { "\"", "'", ":", ";", "!", "?", "\\", "|", "/", "№", "^" }; }
        }

        public ObservableCollection<String> RusTopKeys
        {
            get { return new ObservableCollection<string>() { "й", "ц", "у", "к", "е", "н", "г", "ш", "щ", "з", "х", "ъ" }; }
        }

        public ObservableCollection<String> RusMiddleKeys
        {
            get { return new ObservableCollection<string>() { "ф", "ы", "в", "а", "п", "р", "о", "л", "д", "ж", "э" }; }
        }

        public ObservableCollection<String> RusBottomKeys
        {
            get { return new ObservableCollection<string>() { "я", "ч", "с", "м", "и", "т", "ь", "б", "ю" }; }
        }

        public ObservableCollection<String> EngTopKeys
        {
            get { return new ObservableCollection<string>() { "q", "w", "e", "r", "t", "y", "u", "i", "o", "p" }; }
        }

        public ObservableCollection<String> EngMiddleKeys
        {
            get { return new ObservableCollection<string>() { "a", "s", "d", "f", "g", "h", "j", "k", "l" }; }
        }

        public ObservableCollection<String> EngBottomKeys
        {
            get { return new ObservableCollection<string>() { "z", "x", "c", "v", "b", "n", "m" }; }
        }

        private String _SearchRequest;
        public String SearchRequest
        {
            get { return _SearchRequest; }
            set
            {
                _SearchRequest = value;
                DoPropertyChanged("SearchRequest");
            }
        }

        public ObservableCollection<String> _TopKeys;
        public ObservableCollection<String> TopKeys
        {
            get { return _TopKeys; }
            set { _TopKeys = value; DoPropertyChanged("TopKeys"); }
        }

        public ObservableCollection<String> _MiddleKeys;
        public ObservableCollection<String> MiddleKeys
        {
            get { return _MiddleKeys; }
            set { _MiddleKeys = value; DoPropertyChanged("MiddleKeys"); }
        }

        public ObservableCollection<String> _BottomKeys;
        public ObservableCollection<String> BottomKeys
        {
            get { return _BottomKeys; }
            set { _BottomKeys = value; DoPropertyChanged("BottomKeys"); }
        }

        public void ChangeKeyboard()
        {
            WinApiInteraction.ChangeLanguage(CurrentState);
            switch (CurrentState)
            {
                case KeyboardCurrentState.eng:
                    TopKeys = EngTopKeys;
                    MiddleKeys = EngMiddleKeys;
                    BottomKeys = EngBottomKeys;
                    SymbolSwitcher = "123";
                    LanguageSwitcher = "RUS";
                    break;
                case KeyboardCurrentState.symb:
                    TopKeys = NumberKeys;
                    MiddleKeys = SymbolMiddleKeys;
                    BottomKeys = SymbolBottomKeys;
                    SymbolSwitcher = "ABC";
                    break;
                default:
                    TopKeys = RusTopKeys;
                    MiddleKeys = RusMiddleKeys;
                    BottomKeys = RusBottomKeys;
                    LanguageSwitcher = "ENG";
                    SymbolSwitcher = "123";
                    break;
            }
        }

        private String _Visibility;
        public String Visibility
        {
            get { return _Visibility; }
            set { _Visibility = value; DoPropertyChanged("Visibility"); }
        }

        private KeyboardCurrentState _CurrentState;
        public KeyboardCurrentState CurrentState
        {
            get { return _CurrentState; }
            set { _CurrentState = value; DoPropertyChanged("CurrentState"); }
        }

        private KeyboardCurrentState _PreviousState;
        public KeyboardCurrentState PreviousState
        {
            get { return _PreviousState; }
            set { _PreviousState = value; DoPropertyChanged("PreviousState"); }
        }

        private String _ShiftCoor;
        public String ShiftColor
        {
            get { return _ShiftCoor; }
            set { _ShiftCoor = value; DoPropertyChanged("ShiftColor"); }
        }

        private KeyboardCurrentState _GrandPreviousState;
        public KeyboardCurrentState GrandPreviousState
        {
            get { return _GrandPreviousState; }
            set { _GrandPreviousState = value; DoPropertyChanged("GrandPreviousState"); }
        }

        private String _LanguageSwitcher;
        public String LanguageSwitcher
        {
            get { return _LanguageSwitcher; }
            set { _LanguageSwitcher = value; DoPropertyChanged("LanguageSwitcher"); }
        }

        private String _SymbolSwitcher;
        public String SymbolSwitcher
        {
            get { return _SymbolSwitcher; }
            set { _SymbolSwitcher = value; DoPropertyChanged("SymbolSwitcher"); }
        }

        private Command _ChangeLanguageCommand;
        public Command ChangeLanguageCommand => _ChangeLanguageCommand ?? (_ChangeLanguageCommand = new Command(obj =>
        {
            if (CurrentState == KeyboardCurrentState.rus)
            {
                PreviousState = KeyboardCurrentState.rus;
                CurrentState = KeyboardCurrentState.eng;
                LanguageSwitcher = "RUS";
                SymbolSwitcher = "123";
            }
            else if (CurrentState == KeyboardCurrentState.eng)
            {
                PreviousState = KeyboardCurrentState.eng;
                CurrentState = KeyboardCurrentState.rus;
                LanguageSwitcher = "ENG";
                SymbolSwitcher = "123";
            }
            else
            {
                PreviousState = KeyboardCurrentState.eng;
                CurrentState = KeyboardCurrentState.rus;
                LanguageSwitcher = "ENG";
                SymbolSwitcher = "123";
            }
            ChangeKeyboard();
        }));
        private Command _ChangeSymbolCommand;
        public Command ChangeSymbolCommand => _ChangeSymbolCommand ?? (_ChangeSymbolCommand = new Command(obj =>
        {
            if (CurrentState == KeyboardCurrentState.rus || CurrentState == KeyboardCurrentState.eng)
            {
                Visibility = "Collapsed";
                if (CurrentState == KeyboardCurrentState.rus)
                    PreviousState = KeyboardCurrentState.rus;
                if (CurrentState == KeyboardCurrentState.eng)
                    PreviousState = KeyboardCurrentState.eng;
                CurrentState = KeyboardCurrentState.symb;
                LanguageSwitcher = "RUS";
                SymbolSwitcher = "ABC";
            }
            else if (CurrentState == KeyboardCurrentState.symb)
            {
                Visibility = "Visible";
                if (PreviousState == KeyboardCurrentState.rus)
                {
                    PreviousState = KeyboardCurrentState.symb;
                    CurrentState = KeyboardCurrentState.rus;
                    LanguageSwitcher = "ENG";
                }
                if (PreviousState == KeyboardCurrentState.eng)
                {
                    PreviousState = KeyboardCurrentState.symb;
                    CurrentState = KeyboardCurrentState.eng;
                    LanguageSwitcher = "RUS";
                }
                SymbolSwitcher = "123";
            }
            ChangeKeyboard();
        }));

        #region PropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        public void DoPropertyChanged(String Name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(Name));
            }
        }
        #endregion
    }
}
