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
using System.Windows.Shapes;
using Hoodwink.Models;

namespace Hoodwink.Veiws
{
    /// <summary>
    /// Логика взаимодействия для EditClientVeiws.xaml
    /// </summary>
    public partial class EditClientVeiws : Window
    {
        Client _cl = new Client();
        bool isedit = false;
        public EditClientVeiws(Client cl = null)
        {
            InitializeComponent();
            if (cl == null)
            {
                isedit = false;
                Title = "Добавления";

            }
            else
            {
                isedit = true;
                Title = "Редактирования";
                _cl = cl;
            }
            grid1.DataContext = _cl;

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {


        }

        private void Okey_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (isedit == false)
                {
                    App.Entities.Client.Add(_cl);

                }
                App.Entities.SaveChanges();
                MessageBox.Show("Good");
                Close();
            }
            catch (Exception)
            {

                MessageBox.Show("Bad");
            }
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void genderCodeTextBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
