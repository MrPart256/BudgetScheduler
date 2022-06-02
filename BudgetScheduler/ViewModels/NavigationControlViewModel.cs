using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;
using BudgetScheduler.Views;

namespace BudgetScheduler.ViewModels
{
    public class NavigationControlViewModel
    {
        public static void OnItemInvoked(NavigationView sender, NavigationViewItemInvokedEventArgs args)
        {
            switch (args.InvokedItemContainer.Content.ToString())
            {
                case "Добавить операцию":
                    sender.Content = new AddOperationControl();
                    break;

                case "Посмотреть операции":
                    sender.Content = new OperationsHistoryControl();
                    break;
                case "Посмотреть статистику":
                    sender.Content = new OperationsStatisticsControl();
                    break;

                default:
                    break;
            }
        }
    }
}

