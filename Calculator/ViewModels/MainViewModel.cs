using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Calculator.Core;
using System.Data;
using System;

namespace Calculator.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private DataTable _dataTable = new DataTable();
        private bool _isOperationClicked, _isDotClicked, _isEqualClicked;
        private string temp = "";
        public MainViewModel() 
        {
            NumberClickedCommand = new RelayCommand(NumberClicked);
            OperationClickedCommand = new RelayCommand(OperationClicked);
            ClearCommand = new RelayCommand(Clear);
            EqualClickedCommand = new RelayCommand(EqualClicked);
        }
        private string _resultVal;
        public string ResultVal
        {
            get { return _resultVal; }
            set
            {
                _resultVal = value;
                OnPropertChanged();
            }
        }
        private string _equationVal;
        public string EquationVal
        {
            get { return _equationVal; }
            set
            {
                _equationVal = value;
                OnPropertChanged();
            }
        }
        public void NumberClicked(object obj)
        {
            if (_isEqualClicked)
            {
                EquationVal = (string)obj;
                ResultVal = null;
                _isEqualClicked = false;
            }
            else
            {
                if (EquationVal != null)
                {
                    if (EquationVal.Length < 15)
                    {
                        EquationVal += (string)obj;
                    }
                }
                else
                {
                    EquationVal += (string)obj;
                }
            }

            _isOperationClicked = false;
            _isDotClicked = false;
        }
        public void OperationClicked(object obj)
        {
            if (EquationVal != null || (string)obj == "-")
            {
                if ((string)obj == "." && !_isDotClicked && EquationVal.Length < 15)
                {
                    EquationVal += (string)obj;
                    _isDotClicked = true;
                }
                else if (!_isOperationClicked && EquationVal.Length < 15)
                {
                    EquationVal += (string)obj;
                    _isOperationClicked = true;
                }
                else
                {
                    EquationVal = EquationVal.Remove(EquationVal.Length - 1) + (string)obj;
                }
                _isEqualClicked = false;
            }
        }
        public void Clear(object obj)
        {
            EquationVal = null;
            ResultVal = null;
            _isOperationClicked = false;
            _isDotClicked = false;
            _isEqualClicked = false;
        }
        public void EqualClicked(object obj)
        {
            if (!_isOperationClicked && !_isDotClicked && EquationVal != null)
            {
                ResultVal = Math.Round(Convert.ToDouble(_dataTable.Compute(EquationVal.Replace(",", "."), "")), 4).ToString();
                _isEqualClicked = true;
            }
        }

        public ICommand NumberClickedCommand { get; set; }
        public ICommand OperationClickedCommand { get; set; }
        public ICommand ClearCommand { get; set; }
        public ICommand EqualClickedCommand { get; set; }
        //event wywoływany gdy zmieni się jakaś property
        public event PropertyChangedEventHandler PropertyChanged;

        //Do metody OnPropertyChanged przekazujemy tylko nazwę właściwości (propertyName), która powinna zostać odświeżona,
        //domyślnie jest to null. Dodatkowo ten parametr został oznaczony atrybutem CallerMemberName, dzięki któremu domyślnie
        //zostanie do tej metody przekazana nazwa właściwości, w której metoda zostanie wywołana.
        //Czyli jeżeli wywołamy metodę w set właściwości o nazwie np. FirstName, bez przekazania parametru, to do metody i tak
        //zostanie przekazany FirstName. Także będzie trochę mniej kodu do napisania.
        private void OnPropertChanged([CallerMemberName] string propertyName = null)
        {
            //Wewnątrz metody za pomocą Invoke wyzwalamy event PropertyChanged, jeżeli nie jest null'em.
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
