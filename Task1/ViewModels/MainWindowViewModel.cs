using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Task1.Models;

namespace Task1.ViewModels
{
    class MainWindowViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged([CallerMemberName] string ProperyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(ProperyName));
        }

        private string valueTb="0";
        public string ValueTb
        {
            get => valueTb;
            set
            {
                valueTb = value;
                OnPropertyChanged();
            }
        }

        private double radius;
        public double Radius
        {
            get => radius;
            set
            {
                radius = value;
                OnPropertyChanged();
            }
        }

        private double circumference;
        public double Сircumference
        {
            get => circumference;
            set
            {
                circumference = value;
                OnPropertyChanged();
            }
        }

        public ICommand AddCommand { get; }
        private void OnAddCommandExecute(object parameter)
        {
            Radius = Convert.ToDouble(valueTb.Replace(".", ",").Replace(" ", ""));
            Сircumference = Ariph.GetCircumference(Radius);
        }
        private bool CanAddCommandExecuted(object parameter)
        {
            bool isNamber = Double.TryParse(valueTb.Replace(".", ",").Replace(" ", ""), out double n);
            if (isNamber)
            {
                if (n != 0)
                    return true;
                else
                    return false;
            }
            else
                return false;
        }
        public MainWindowViewModel()
        {
            AddCommand = new RelayCommand(OnAddCommandExecute, CanAddCommandExecuted);
        }
    }
    
}
