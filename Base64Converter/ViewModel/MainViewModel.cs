using System;
using System.ComponentModel;
using System.Windows.Input;
using Xamarin.Forms;
using System.Text;

namespace Base64Converter.ViewModel
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public ICommand EncodeCommand { protected set; get; }
        public ICommand DecodeCommand { protected set; get; }
        string sourceString = "";
        string base64String = "";
        private static readonly Encoding encoding = Encoding.UTF8;

        public MainViewModel()
        {
            EncodeCommand = new Command(() =>
            {
                Base64String = Encode(SourceString);
            });

            DecodeCommand = new Command(() =>
            {
                SourceString = Decode(Base64String);
            });
        }

        public string SourceString
        {
            set
            {
                if (sourceString != value)
                {
                    sourceString = value;
                    OnPropertyChanged("SourceString");
                }
            }
            get { return sourceString; }
        }

        public string Base64String
        {
            set
            {
                if (base64String != value)
                {
                    base64String = value;
                    OnPropertyChanged("Base64String");
                }
            }
            get { return base64String; }
        }

        string Encode(string sourceString)
        {
            return Convert.ToBase64String(encoding.GetBytes(sourceString));
        }

        string Decode(string base64String)
        {
            return encoding.GetString(Convert.FromBase64String(base64String));
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
