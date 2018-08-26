using HandyTest.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace HandyTest.Pages
{
    /// <summary>
    /// Interaction logic for ManualTestView.xaml
    /// </summary>
    public partial class ManualTestView : UserControl
    {
        public ManualTestView()
        {
            InitializeComponent();
        }

        
        private void WindowDragMove(object sender, MouseButtonEventArgs e)
        {
            WindowSettings set = new WindowSettings();
            set.Window_MouseDown(sender, e);
        }
    }
}
