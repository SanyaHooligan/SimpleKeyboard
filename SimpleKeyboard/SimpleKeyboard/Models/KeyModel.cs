using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimpleKeyboard.Models
{
    public class KeyModel : INotifyPropertyChanged
    {
        public KeyModel(String KeyName, Keys KeyCode)
        {
            this.KeyCode = KeyCode;
            this.KeyName = KeyName;
        }

        private String _KeyName;
        public String KeyName
        {
            get { return _KeyName; }
            set { _KeyName = value; DoPropertyChanged("KeyName"); }
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
