using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using HandyTest.BL;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using HandyTest.Pages;

namespace HandyTest.Views
{
    /// <summary>
    /// Interaction logic for ExplorativeTestView.xaml
    /// </summary>
    public partial class ExplorativeTestView : Window
    {
        public ExplorativeTestView()
        {
            InitializeComponent();
            SetCurrentData();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var desktopWorkingArea = System.Windows.SystemParameters.WorkArea;
            this.Left = desktopWorkingArea.Right - this.Width;
            this.Top = desktopWorkingArea.Bottom - this.Height;
        }

        private void PreviousWindowBtn(object sender, RoutedEventArgs e)
        {
            //this.Close();
            this.Hide();
        }

        private void AddPriorityItems(object sender, RoutedEventArgs e)
        {
            priorityCombo.Items.Add("Critical");
            priorityCombo.Items.Add("Major");
            priorityCombo.Items.Add("Medium");
            priorityCombo.Items.Add("Minor");
            priorityCombo.Items.Add("Cosmetics");
        }

        private void AddTypeItems(object sender, RoutedEventArgs e)
        {
            report_typeCombo.Items.Add("Task");
            report_typeCombo.Items.Add("Bug");
            report_typeCombo.Items.Add("Feature");
        }

        private void AddStateItems(object sender, RoutedEventArgs e)
        {
            stateCombo.Items.Add("Reported");
            stateCombo.Items.Add("Success");
            stateCombo.Items.Add("Failure");
            stateCombo.Items.Add("Won't Fix");
        }
        private void SetCurrentData()
        {
            var currentData = DateTime.Today;
            reportDateFile.Text = currentData.ToShortDateString();
        }
    }
}
