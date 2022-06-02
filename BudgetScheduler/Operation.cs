using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetScheduler
{
    public struct Operation
    {
        public int id { get; set; }
        public float Summ { get; set; }
        public string Type { get; set; }
        public string Category { get; set; }
        public string Commentary { get; set; }
        public DateTime Date { get; set; }
    }
}
