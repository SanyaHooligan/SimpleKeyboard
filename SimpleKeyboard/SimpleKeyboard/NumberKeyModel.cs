using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimpleKeyboard
{
    public class NumberKeyModel : INotifyPropertyChanged
    {
        public NumberKeyModel(Char KeyName, Keys KeyCode)
        {
            this.KeyCode = KeyCode;
            this.KeyName = KeyName;
        }

        private Char _KeyName;
        public Char KeyName
        {
            get { return _KeyName; }
            set { _KeyName = value; DoPropertyChanged("KeyName"); }
        }

        private Char _FirstSymbol;
        public Char FirstSymbol
        {
            get { return _FirstSymbol; }
            set { _FirstSymbol = value; DoPropertyChanged("FirstSymbol"); }
        }

        private Char _SecondSymbol;
        public Char SecondSymbol
        {
            get { return _SecondSymbol; }
            set { _SecondSymbol = value; DoPropertyChanged("SecondSymbol"); }
        }

        private Keys _KeyCode;
        public Keys KeyCode
        {
            get { return _KeyCode; }
            set { _KeyCode = value; DoPropertyChanged("KeyCode"); }
        }

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
