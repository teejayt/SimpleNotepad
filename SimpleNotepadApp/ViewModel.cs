using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SimpleNotepadApp
{
    public class ViewModel
    {
        private string _title;

        public string title
        {
            get { return _title; }
            set { 
                _title = value;
                OnPropertyChanged("title");
                 }
        }

       private ICommand _changeTextCommand;
       public ICommand changeTextCommand
        {
            get
            {
                if (_changeTextCommand == null)
                {
                    _changeTextCommand = new Command<string>(ChangeTitle, CanChangeTitle);
                }

                return _changeTextCommand;
            }
            set { _changeTextCommand = value; }
        }

        public void ChangeTitle(string text)
        {
            title = text;
        }
        public bool CanChangeTitle()
        {
            return true;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
