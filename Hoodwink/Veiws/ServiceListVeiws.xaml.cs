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

namespace Hoodwink.Veiws
{
    /// <summary>
    /// Логика взаимодействия для ServiceListVeiws.xaml
    /// </summary>
    public partial class ServiceListVeiws : Window
    {
        public ServiceListVeiws()
        {
            InitializeComponent();
        }

        void Refresh()
        {
            serviceDataGrid.DataContext = App.Entities.Client.ToList();
        }
        
        void Method()
        {
            var services = App.Entities.Service.AsQueryable();

            switch (Sortirovka.SelectedIndex)
            {
                case 1:
                    services = services.Where(x => x.Discount >= 0 && x.Discount < 5);
                    break;
                case 2:
                    services = services.Where(x => x.Discount >= 5 && x.Discount < 15);
                    break;
                case 3:
                    services = services.Where(x => x.Discount >= 15 && x.Discount < 30);
                    break;
                case 4:
                    services = services.Where(x => x.Discount >= 30 && x.Discount < 50);
                    break;
                case 5:
                    services = services.Where(x => x.Discount >= 50 && x.Discount < 70);
                    break;
                case 6:
                    services = services.Where(x => x.Discount >= 70 && x.Discount < 100);
                    break;
            }
            services = services.Where(x => x.Title.Contains(Filter.Text) || x.Description.Contains(Filter.Text));

            services = services.OrderBy(x=> x.Cost);

            serviceDataGrid.DataContext = services.ToList();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

     
        }

        private void Sortirovka_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Filter_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
