using System;
using System.Windows.Input;

namespace Calculator.Core
{
    public class RelayCommand : ICommand
    {
        //mamy dwa delegaty. 1 to jest Action, który będzie przyjmował parametr object, a drugi Predicate,
        //który również może przyjmować parametr object i zwraca boola. 
        readonly Action<object> _execute;
        readonly Predicate<object> _canExecute;

        //KOnstruktor, tworząc nowy obiekt, tylko przekazuje metodę, która ma zostać powiązana z tą konkretną
        //akcją i wtedy jako drugi parametr zostaje przekazany null. 
        public RelayCommand(Action<object> execute)
            : this(execute, null)
        {
        }

        //jeżeli przekażemy jakąś metodę, która zwraca false, to ta akcja się nie wykona.
        public RelayCommand(Action<object> execute, Predicate<object> canExecute)
        {
            _execute = execute ?? throw new ArgumentNullException("execute");
            _canExecute = canExecute;
        }

        // metoda CanExecute, która jeżeli CanExecute będzie null'em lub będzie zwracała true,
        // to wtedy cała metoda CanExecute zwraca true.
        public bool CanExecute(object parameter)
        {
            return _canExecute == null || _canExecute(parameter);
        }

        public event EventHandler CanExecuteChanged
        {
            add
            {
                CommandManager.RequerySuggested += value;
            }
            remove
            {
                CommandManager.RequerySuggested -= value;
            }
        }

        //metoda wywołuje przekazaną wcześniej metodę
        public void Execute(object parameter)
        {
            _execute(parameter);
        }
    }
}
