using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace HandyTest.BL
{
    public static class PageNavigator
    {

        public static MainWindow pageSwitcher;
        static UserControl currentPage;
        public static void Switch(UserControl newPage)
        {
            pageSwitcher.Navigate(newPage);
            currentPage = newPage;
        }
        public static string GetCurrentPage()
        {
            return currentPage.Name;
        }

    }
}
