using HandyTest.BL;
using System;
using System.Collections.Generic;
using System.IO;
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
    /// Interaction logic for ActivatePage.xaml
    /// </summary>
    public partial class ActivatePage : UserControl
    {
        ValidateTask validateTask = new ValidateTask();
        public ActivatePage()
        {
            InitializeComponent();
        }

        private void SetNewTaskLink(object sender, RoutedEventArgs e)
        {
            using (var sw = new StreamWriter("App.dll", false))
            {
                sw.WriteLine(FormatLink(linkTextBox.Text));
            }
            if (validateTask.ValidateLink())
                ChangePage();
            else
            {
                MessageBox.Show("Invalid link or task has expired!", "Access denied");
                //Application.Current.Shutdown();
            }
        }
        private string FormatLink(string text)
        {
            try
            {
                //var formattedText = "http://quizzes.enformatic.eu/quiz/check_challenge_time/" + ValidateTask.GetBetween(text, "challenge/", "/");
                //return formattedText;
                var stack = new Stack<char>();

                foreach (var c in text.Reverse())
                {
                    if ((text[text.Length-1]=='/' && stack.Count>0 && c == '/')||(text[text.Length - 1] != '/' && c == '/'))
                        break;
                    stack.Push(c);
                }

                return "http://quizzes.enformatic.eu/quiz/check_challenge_time/"+ new string(stack.ToArray());
            }
            catch
            {
                return "";
            }

        }
        public void ChangePage()
        {
            //PageNavigator.pageSwitcher = this;
            PageNavigator.Switch(new HomeView());
        }

        private void TerminateApp(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
