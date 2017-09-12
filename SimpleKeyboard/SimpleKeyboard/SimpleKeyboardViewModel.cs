using SimpleKeyboard.Models;
using SimpleKeyboard.Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Threading;

namespace SimpleKeyboard
{
    public enum KeyboardCurrentState { eng, rus, symb }
    public class SimpleKeyboardViewModel : INotifyPropertyChanged
    {
        DispatcherTimer timer;
        DispatcherTimer newtimer;
        public SimpleKeyboardViewModel()
        {
            TopKeys = RusTopKeys;
            MiddleKeys = RusMiddleKeys;
            BottomKeys = RusBottomKeys;
            CurrentState = KeyboardCurrentState.rus;
            PreviousState = KeyboardCurrentState.rus;
            TopCommand = NormalPressCommand;
            MiddleCommand = NormalPressCommand;
            BottomCommand = NormalPressCommand;
            Visibility = "Visible";
            ShiftFlag = false;
            ChangeKeyboard();
            WinApiInteraction.ChangeLanguage(KeyboardCurrentState.rus);
            timer = new DispatcherTimer { Interval = new TimeSpan(0, 0, 0, 0, 30) };
            newtimer = new DispatcherTimer { Interval = new TimeSpan(0, 0, 0, 0, 500) };
            newtimer.Tick += Newtimer_Tick;
            timer.Tick += Timer_ticket;
        }

        private void Newtimer_Tick(object sender, EventArgs e)
        {
            timer.Start();
        }

        private void Timer_ticket(object sender, EventArgs e)
        {
            if (newtimer.IsEnabled) newtimer.Stop();
            WinApiInteraction.HoldKey(Keys.Back);
            WinApiInteraction.ReleaseKey(Keys.Back);
        }

        #region Keys collections
        public ObservableCollection<KeyModel> NumberKeys
        {
            get
            {
                return new ObservableCollection<KeyModel>()
                {
                    new KeyModel("1", Keys.D1),
                    new KeyModel("2", Keys.D2),
                    new KeyModel("3", Keys.D3),
                    new KeyModel("4", Keys.D4),
                    new KeyModel("5", Keys.D5),
                    new KeyModel("6", Keys.D6),
                    new KeyModel("7", Keys.D7),
                    new KeyModel("8", Keys.D8),
                    new KeyModel("9", Keys.D9),
                    new KeyModel("0", Keys.D0),
                };
            }
        }

        public ObservableCollection<KeyModel> SymbolMiddleKeys
        {
            get
            {
                return new ObservableCollection<KeyModel>()
                {
                    new KeyModel("+", Keys.Oemplus),
                    new KeyModel("_", Keys.OemMinus),
                    new KeyModel("@", Keys.D2),
                    new KeyModel("#", Keys.D3),
                    new KeyModel("$", Keys.D4),
                    new KeyModel("%", Keys.D5),
                    new KeyModel("^", Keys.D6),
                    new KeyModel("&", Keys.D7),
                    new KeyModel("*", Keys.D8),
                    new KeyModel("(", Keys.D9),
                    new KeyModel(")", Keys.D0),
                    new KeyModel("!", Keys.D1),
                    new KeyModel("?", Keys.OemQuestion),
                };
            }
        }

        public ObservableCollection<KeyModel> FirstBottomSymbolKeys
        {
            get
            {
                return new ObservableCollection<KeyModel>() {
                new KeyModel("-", Keys.OemMinus),
                new KeyModel("=", Keys.Oemplus),
                new KeyModel("[", Keys.OemOpenBrackets),
                new KeyModel("]", Keys.OemCloseBrackets),
                new KeyModel("\\", Keys.OemBackslash),
                new KeyModel(";", Keys.OemSemicolon),
                new KeyModel("\'", Keys.OemQuotes),
                new KeyModel("/", Keys.OemQuestion)
            };
            }
        }

        public ObservableCollection<KeyModel> SecondBottomSymbolKeys
        {
            get
            {
                return new ObservableCollection<KeyModel>() {
                new KeyModel("\"", Keys.OemQuotes),
                new KeyModel("<", Keys.Oemcomma),
                new KeyModel(">", Keys.OemPeriod),
                new KeyModel("{", Keys.OemOpenBrackets),
                new KeyModel("}", Keys.OemCloseBrackets),
            };
            }
        }

        public ObservableCollection<KeyModel> RusTopKeys
        {
            get
            {
                return new ObservableCollection<KeyModel>()
                {
                    new KeyModel("й", Keys.Q),
                    new KeyModel("ц", Keys.W),
                    new KeyModel("у", Keys.E),
                    new KeyModel("к", Keys.R),
                    new KeyModel("е", Keys.T),
                    new KeyModel("н", Keys.Y),
                    new KeyModel("г", Keys.U),
                    new KeyModel("ш", Keys.I),
                    new KeyModel("щ", Keys.O),
                    new KeyModel("з", Keys.P),
                    new KeyModel("х", Keys.OemOpenBrackets),
                    new KeyModel("ъ", Keys.OemCloseBrackets)
                };
            }
        }
        
        public ObservableCollection<KeyModel> RusMiddleKeys
        {
            get
            {
                return new ObservableCollection<KeyModel>()
                {
                    new KeyModel("ф", Keys.A),
                    new KeyModel("ы", Keys.S),
                    new KeyModel("в", Keys.D),
                    new KeyModel("а", Keys.F),
                    new KeyModel("п", Keys.G),
                    new KeyModel("р", Keys.H),
                    new KeyModel("о", Keys.J),
                    new KeyModel("л", Keys.K),
                    new KeyModel("д", Keys.L),
                    new KeyModel("ж", Keys.OemSemicolon),
                    new KeyModel("э", Keys.OemQuotes)
                };
            }
        }
        
        public ObservableCollection<KeyModel> RusBottomKeys
        {
            get
            {
                return new ObservableCollection<KeyModel>()
                {
                    new KeyModel("я", Keys.Z),
                    new KeyModel("ч", Keys.X),
                    new KeyModel("с", Keys.C),
                    new KeyModel("м", Keys.V),
                    new KeyModel("и", Keys.B),
                    new KeyModel("т", Keys.N),
                    new KeyModel("ь", Keys.M),
                    new KeyModel("б", Keys.Oemcomma),
                    new KeyModel("ю", Keys.OemPeriod)
                };
            }
        }
        
        public ObservableCollection<KeyModel> EngTopKeys
        {
            get
            {
                return new ObservableCollection<KeyModel>()
                {
                    new KeyModel("q", Keys.Q),
                    new KeyModel("w", Keys.W),
                    new KeyModel("e", Keys.E),
                    new KeyModel("r", Keys.R),
                    new KeyModel("t", Keys.T),
                    new KeyModel("y", Keys.Y),
                    new KeyModel("u", Keys.U),
                    new KeyModel("i", Keys.I),
                    new KeyModel("o", Keys.O),
                    new KeyModel("p", Keys.P)
                };
            }
        }
        
        public ObservableCollection<KeyModel> EngMiddleKeys
        {
            get
            {
                return new ObservableCollection<KeyModel>()
                {
                    new KeyModel("a", Keys.A),
                    new KeyModel("s", Keys.S),
                    new KeyModel("d", Keys.D),
                    new KeyModel("f", Keys.F),
                    new KeyModel("g", Keys.G),
                    new KeyModel("h", Keys.H),
                    new KeyModel("j", Keys.J),
                    new KeyModel("k", Keys.K),
                    new KeyModel("l", Keys.L)
                };
            }
        }
        
        public ObservableCollection<KeyModel> EngBottomKeys
        {
            get
            {
                return new ObservableCollection<KeyModel>()
                {
                    new KeyModel("z", Keys.Z),
                    new KeyModel("x", Keys.X),
                    new KeyModel("c", Keys.C),
                    new KeyModel("v", Keys.V),
                    new KeyModel("b", Keys.B),
                    new KeyModel("n", Keys.N),
                    new KeyModel("m", Keys.M)
                };
            }
        }
        #endregion

        #region Changeble bound keys collection
        private ObservableCollection<KeyModel> _TopKeys;
        public ObservableCollection<KeyModel> TopKeys
        {
            get { return _TopKeys; }
            set { _TopKeys = value; DoPropertyChanged("TopKeys"); }
        }

        private ObservableCollection<KeyModel> _MiddleKeys;
        public ObservableCollection<KeyModel> MiddleKeys
        {
            get { return _MiddleKeys; }
            set { _MiddleKeys = value; DoPropertyChanged("MiddleKeys"); }
        }

        private ObservableCollection<KeyModel> _SecondBottomKeys;
        public ObservableCollection<KeyModel> SecondBottomKeys
        {
            get { return _SecondBottomKeys; }
            set { _SecondBottomKeys = value; DoPropertyChanged("SecondBottomKeys"); }
        }

        private ObservableCollection<KeyModel> _BottomKeys;
        public ObservableCollection<KeyModel> BottomKeys
        {
            get { return _BottomKeys; }
            set { _BottomKeys = value; DoPropertyChanged("BottomKeys"); }
        }
        #endregion

        #region Keyboard state changer
        public void ChangeKeyboard()
        {
            WinApiInteraction.ChangeLanguage(CurrentState);
            switch (CurrentState)
            {
                case KeyboardCurrentState.eng:
                    TopKeys = EngTopKeys;
                    MiddleKeys = EngMiddleKeys;
                    BottomKeys = EngBottomKeys;
                    SecondBottomKeys = new ObservableCollection<KeyModel>();
                    SymbolSwitcher = "123";
                    LanguageSwitcher = "RUS";
                    break;
                case KeyboardCurrentState.symb:
                    TopKeys = NumberKeys;
                    MiddleKeys = SymbolMiddleKeys;
                    BottomKeys = FirstBottomSymbolKeys;
                    SecondBottomKeys = SecondBottomSymbolKeys;
                    SymbolSwitcher = "ABC";
                    break;
                default:
                    TopKeys = RusTopKeys;
                    MiddleKeys = RusMiddleKeys;
                    BottomKeys = RusBottomKeys;
                    SecondBottomKeys = new ObservableCollection<KeyModel>();
                    LanguageSwitcher = "ENG";
                    SymbolSwitcher = "123";
                    break;
            }
        }
        #endregion

        #region toggle state properties
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

        private Boolean _ShiftFlag;
        public Boolean ShiftFlag
        {
            get { return _ShiftFlag; }
            set { _ShiftFlag = value; DoPropertyChanged("ShiftFlag"); }
        }
        #endregion

        #region Methods for toggle case state
        private void ToggleFlag()
        {
            if (ShiftFlag)
            {
                ShiftFlag = false;
            }
            else if (!ShiftFlag)
            {
                ShiftFlag = true;
            }
        }

        private ObservableCollection<KeyModel> GetToggleUpper(Boolean flag, ObservableCollection<KeyModel> collection)
        {
            var newCollection = new ObservableCollection<KeyModel>();
            if (flag)
                foreach (var item in collection)
                {
                    newCollection.Add(new KeyModel(item.KeyName.ToUpper(), item.KeyCode));
                }
            else
                foreach (var item in collection)
                {
                    newCollection.Add(new KeyModel(item.KeyName.ToLower(), item.KeyCode));
                }
            return newCollection;
        }

        private void ToggleShiftPress()
        {
            if (ShiftFlag)
            {
                ShiftColor = "#646464";
                TopCommand = PressWithShiftCommand;
                MiddleCommand = PressWithShiftCommand;
                BottomCommand = PressWithShiftCommand;
            }
            else if (!ShiftFlag)
            {
                ShiftColor = "Transparent";
                TopCommand = NormalPressCommand;
                MiddleCommand = NormalPressCommand;
                BottomCommand = NormalPressCommand;
            }
        }
        #endregion

        #region Uppercase Collections
        public ObservableCollection<KeyModel> UpperRusTopKeys { get { return GetToggleUpper(true, RusTopKeys); } }
        public ObservableCollection<KeyModel> UpperRusMiddleKeys { get { return GetToggleUpper(true, RusMiddleKeys); } }
        public ObservableCollection<KeyModel> UpperRusBottomKeys { get { return GetToggleUpper(true, RusBottomKeys); } }
        public ObservableCollection<KeyModel> UpperEngTopKeys { get { return GetToggleUpper(true, EngTopKeys); } }
        public ObservableCollection<KeyModel> UpperEngMiddleKeys { get { return GetToggleUpper(true, EngMiddleKeys); } }
        public ObservableCollection<KeyModel> UpperEngBottomKeys { get { return GetToggleUpper(true, EngBottomKeys); } }
        #endregion

        #region Changing keyboard state commands
        private Command _ChangeLanguageCommand;
        public Command ChangeLanguageCommand => _ChangeLanguageCommand ?? (_ChangeLanguageCommand = new Command(obj =>
        {
            ShiftFlag = false;
            ToggleShiftPress();
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
            ShiftFlag = false;
            ToggleShiftPress();
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
                TopCommand = NormalPressCommand;
                MiddleCommand = PressWithShiftCommand;
                BottomCommand = NormalPressCommand;
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
                TopCommand = NormalPressCommand;
                MiddleCommand = NormalPressCommand;
                BottomCommand = NormalPressCommand;
            }
            ChangeKeyboard();
        }));

        private Command _ShiftCommand;
        public Command ShiftCommand => _ShiftCommand ?? (_ShiftCommand = new Command(obj =>
        {
            ToggleFlag();
            TopKeys = GetToggleUpper(ShiftFlag, TopKeys);
            MiddleKeys = GetToggleUpper(ShiftFlag, MiddleKeys);
            BottomKeys = GetToggleUpper(ShiftFlag, BottomKeys);
            ToggleShiftPress();
        }));
        #endregion

        #region Changeble bound commands
        private Command _TopCommand;
        public Command TopCommand
        {
            get { return _TopCommand; }
            set { _TopCommand = value; DoPropertyChanged("TopCommand"); }
        }

        private Command _MiddleCommand;
        public Command MiddleCommand
        {
            get { return _MiddleCommand; }
            set { _MiddleCommand = value; DoPropertyChanged("MiddleCommand"); }
        }

        private Command _BottomCommand;
        public Command BottomCommand
        {
            get { return _BottomCommand; }
            set { _BottomCommand = value; DoPropertyChanged("BottomCommand"); }
        }
        #endregion

        #region Backspace commands
        private Command _BackspaceStartCommand;
        public Command BackspaceStartCommand => _BackspaceStartCommand ?? (_BackspaceStartCommand = new Command(obj =>
        {
            WinApiInteraction.HoldKey(Keys.Back);
            WinApiInteraction.ReleaseKey(Keys.Back);
            newtimer.Start();
        }));

        private Command _BackspaceStopCommand;
        public Command BackspaceStopCommand => _BackspaceStopCommand ?? (_BackspaceStopCommand = new Command(obj =>
        {
            timer.Stop();
            newtimer.Stop();
        }));
        #endregion

        #region Press commands
        private Command _NormalPressCommand;
        public Command NormalPressCommand => _NormalPressCommand ?? (_NormalPressCommand = new Command(obj =>
        {
            WinApiInteraction.ChangeLanguage(CurrentState);
            WinApiInteraction.HoldKey((Keys)obj);
            WinApiInteraction.ReleaseKey((Keys)obj);
        }));

        private Command _PressWithShiftCommand;
        public Command PressWithShiftCommand => _PressWithShiftCommand ?? (_PressWithShiftCommand = new Command(obj =>
        {
            WinApiInteraction.ChangeLanguage(CurrentState);
            WinApiInteraction.HoldKey(Keys.LShiftKey);
            WinApiInteraction.HoldKey((Keys)obj);
            WinApiInteraction.ReleaseKey((Keys)obj);
            WinApiInteraction.ReleaseKey(Keys.LShiftKey);
        }));

        private Command _PressWithLanguageChangeCommand;
        public Command PressWithLanguageChangeCommand => _PressWithLanguageChangeCommand ?? (_PressWithLanguageChangeCommand = new Command(obj =>
        {
            WinApiInteraction.ChangeLanguage(KeyboardCurrentState.eng);
            WinApiInteraction.HoldKey((Keys)obj);
            WinApiInteraction.ReleaseKey((Keys)obj);
        }));
        #endregion

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
