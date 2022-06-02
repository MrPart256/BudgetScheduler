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
    internal class OperationsStatisticsViewModel : BaseViewModel
    {
        private List<Operation> _operations;
        public List<Operation> Operations
        {
            get
            {
                return _operations;
            }
            private set
            {
                _operations = value;
                OnPropertyChanged(nameof(Operations));
            }
        }

        private ICommand _week;
        public ICommand Week
        {
            get
            {
                if (_week == null)
                {
                    _week = new DelegateCommand(() => {
                       Operations = DBOperations.SelectOperations(DateTime.Today.AddDays(-7));
                    });
                }
                return _week;
            }
        }

        private ICommand _month;
        public ICommand Month
        {
            get
            {
                if (_month == null)
                {
                    _month = new DelegateCommand(() => {
                        Operations = DBOperations.SelectOperations(DateTime.Today.AddMonths(-1));
                    });
                }
                return _month;
            }
        }

        private ICommand _year;
        public ICommand Year
        {
            get
            {
                if (_year == null)
                {
                    _year = new DelegateCommand(() => {
                        Operations = DBOperations.SelectOperations(DateTime.Today.AddYears(-1));
                    });
                }
                return _year;
            }
        }
    }
}
