using BudgetScheduler.Commands;
using BudgetScheduler.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BudgetScheduler.ViewModels
{
    internal class AddOperationControlViewModel : BaseViewModel
    {
        private float _operationSumm;
        public float OperationSumm
        {
            get
            {
                return _operationSumm;
            }
            set
            {
                _operationSumm = value;
                OnPropertyChanged(nameof(OperationSumm));
            }
        }

        #region OperationTypes
        public List<string> OperationTypes
        {
            get
            {
                return new List<string>()
                {
                    "Доход",
                    "Расход"
                };
            }
        }

        private string _selectedOperationType;
        public string SelectedOperationType
        {
            get
            {

                return _selectedOperationType;
            }
            set
            {
                _selectedOperationType = value;
                OperationCategory = (value == OperationTypes[0]) ? new List<string>()
                {
                    "Заработная плата",
                    "Возврат долга",
                    "Дивиденды "
                } : new List<string>()
                {
                    "Развлечения",
                    "Еда",
                    "Транспорт"
                };
                OnPropertyChanged(nameof(SelectedOperationType));
            }
        }
        #endregion

        #region OperationCategory
        private List<string> _operationCategory;
        public List<string> OperationCategory
        {
            get
            {
                return _operationCategory;
              
            }
            private set
            {
                _operationCategory = value;
                OnPropertyChanged(nameof(OperationCategory));
            }
        }

        

        private string _selectedOperationCategory;
        public string SelectedOperationCategory
        {
            get
            {
                return _selectedOperationCategory;
            }
            set
            {
                _selectedOperationCategory = value;
            }
        }
        #endregion

        private string _commentary;
        public string Commentary
        {
            get
            {
                return _commentary;
            }
            set
            {
                _commentary = value;
                OnPropertyChanged(nameof(Commentary));
            }
        }

        private ICommand command;
        public ICommand Command
        {
            get
            {
                if(command == null)
                {
                    command = new DelegateCommand(() => { DBOperations.AddOperation(new Operation { Type = SelectedOperationType, Category = SelectedOperationCategory,
                    Summ = OperationSumm , Commentary = Commentary, Date = DateTime.Today}); });
                }
                return command;
            }
        }
    }
}
