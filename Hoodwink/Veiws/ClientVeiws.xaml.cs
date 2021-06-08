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
    /// Логика взаимодействия для ClientVeiws.xaml
    /// </summary>
    public partial class ClientVeiws : Window
    {
        public ClientVeiws()
        {
            InitializeComponent();
            Refresh();
        }
        void Refresh()
        {
            clientDataGrid.DataContext = App.Entities.Client.ToList();
        }

        void Method()
        {
            var search  = App.Entities.Client.AsQueryable();

            search = search.Where(x => x.FirstName.Contains(FilterBox.Text) || x.LastName.Contains(FilterBox.Text));

            clientDataGrid.DataContext = search.ToList();

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            var window = new EditClientVeiws();
            window.ShowDialog();
            Refresh();
        }

        private void Del_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var item = clientDataGrid.SelectedItem as Client;
                if (item != null)
                {
                    App.Entities.Client.Remove(item);
                    App.Entities.SaveChanges();
                    Refresh();
                }
                else
                {
                    MessageBox.Show("Bad");
                }
            }
            catch (Exception)
            {

                MessageBox.Show("Batt");
            }
           
       
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            var item = clientDataGrid.SelectedItem as Client;
            if (item != null)
            {
                var window = new EditClientVeiws(item);
                window.ShowDialog();
                Refresh();
            }
        }

        private void FilterBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            Method();
        }
    }
}
