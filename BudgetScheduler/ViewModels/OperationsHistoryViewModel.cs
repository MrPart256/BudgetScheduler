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
    internal class OperationsHistoryViewModel : BaseViewModel
    {
        public List<Operation> Operations
        {
            get
            {
                return DBOperations.SelectOperations();
            }
        }
        public float Summ
        {
            get { return MathFuncs.CalcSumm(Operations); }
        }
    }
}
