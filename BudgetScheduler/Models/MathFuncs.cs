using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetScheduler.Models
{
    internal class MathFuncs
    {
        public static float CalcSumm(List<Operation> operationList)
        {
            float summ = 0;
            foreach (Operation operation in operationList)
            {
                if (operation.Type == "Расход")
                {
                    summ -= operation.Summ;
                }
                else
                {
                    summ += operation.Summ;
                }
            }
            return summ;
        }
    }
}
