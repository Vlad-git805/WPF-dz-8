using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using System.Windows.Media;
using WpfApp1.Commands;

namespace WpfApp1
{
    public class ViewModel : INotifyPropertyChanged
    {
        private Color currentColor;
        private byte a = 100;
        private byte r = 150;
        private byte g = 75;
        private byte b = 33;
        private readonly ICollection<Color> colors = new ObservableCollection<Color>();

        private Command addNewColorCommand;
        private Command removeContactCommand;
        public ViewModel()
        {
            addNewColorCommand = new DelegateCommand(AddColorCommand);

            PropertyChanged += (sender, args) =>
            {
                if (args.PropertyName == nameof(CurrentColor))
                {
                    addNewColorCommand.RaiseCanExecuteChanged();
                }
            };
        }

        public IEnumerable<Color> Colors => colors;
        public Color CurrentColor
        {
            get => currentColor;
            set
            {
                currentColor = value;
                OnPropertyChanged();
            }
        }
        public Color ColorInBorder => Color.FromArgb(A, R, G, B);
        public byte A
        {
            get => a;
            set
            {
                a = Convert.ToByte(value);
                OnPropertyChanged();
                OnPropertyChanged(nameof(ColorInBorder));
            }
        }
        public byte R
        {
            get => r;
            set
            {
                r = Convert.ToByte(value);
                OnPropertyChanged();
                OnPropertyChanged(nameof(ColorInBorder));
            }
        }
        public byte G
        {
            get => g;
            set
            {
                g = Convert.ToByte(value);
                OnPropertyChanged();
                OnPropertyChanged(nameof(ColorInBorder));
            }
        }
        public byte B
        {
            get => b;
            set
            {
                b = Convert.ToByte(value);
                OnPropertyChanged();
                OnPropertyChanged(nameof(ColorInBorder));
            }
        }

        public ICommand AddNewColorCommand => addNewColorCommand;

        public void AddColorCommand()
        {
            colors.Add(ColorInBorder);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
