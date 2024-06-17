using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;

namespace ComplexMath
{
    public class ComplexCalculatorViewModel : INotifyPropertyChanged
    {
        private ComplexNumber _number1;
        private ComplexNumber _number2;
        private ComplexNumber _result;

        public ComplexNumber Number1
        {
            get => _number1;
            private set
            {
                _number1 = value;
                OnPropertyChanged();
            }
        }

        public ComplexNumber Number2
        {
            get => _number2;
            private set
            {
                _number2 = value;
                OnPropertyChanged();
            }
        }

        public ComplexNumber Result
        {
            get => _result;
            private set
            {
                _result = value;
                OnPropertyChanged();
            }
        }

        public ICommand AddCommand { get; }
        public ICommand MultiplyCommand { get; }
        public ICommand DivideCommand { get; }

        public event PropertyChangedEventHandler PropertyChanged;

        public ComplexCalculatorViewModel()
        {
            Number1 = new ComplexNumber(0, 0);
            Number2 = new ComplexNumber(0, 0);

            AddCommand = new RelayCommand(Add);
            MultiplyCommand = new RelayCommand(Multiply);
            DivideCommand = new RelayCommand(Divide);
        }

        private void Add()
        {
            Result = Number1 + Number2;
        }

        private void Multiply()
        {
            Result = Number1 * Number2;
        }

        private void Divide()
        {
            try
            {
                Result = Number1 / Number2;
            }
            catch (DivideByZeroException ex)
            {
                MessageBox.Show("Division by zero is not allowed.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}